using System;
using System.Collections.Generic;
using System.Numerics;
using KnowledgeCheck1_Calculator.Logic;
using KnowledgeCheck1_Calculator.UserInteraction;

namespace KnowledgeCheck1_Calculator
{
    public class App(IDataReaderWriter dataReaderWriter)
    {
        private readonly IDataReaderWriter _consoleDataReaderWriter = dataReaderWriter;
        private readonly string _invalidString = "invalid";
        private readonly string _exitMessage = "Goodbye!";

        public void Run()
        {
            _consoleDataReaderWriter.DisplayHeader();

            string input;

            do
            {
                _consoleDataReaderWriter.DisplayOptions();
                _consoleDataReaderWriter.DisplayMessage(
                    "Please choose from the options above.");
                _consoleDataReaderWriter.DisplayMessage(
                    "You may enter either the number or the action letter.");
                input = _consoleDataReaderWriter.GetUserInput();
                HandleUserInput(input);

                _consoleDataReaderWriter.DisplayMessageInline(
                    "Do you want to do another operation? (y/n): ");
                var continueSelection = _consoleDataReaderWriter.GetUserInput();
                if (string.Equals(continueSelection, "n")) break;
            } while (!string.Equals(input, "e") && !string.Equals(input, "5"));

            _consoleDataReaderWriter.DisplayMessage(_exitMessage);

        }

        private void HandleUserInput(string input)
        {
            string choice = ParseUserChoice(input);
            ExecuteUserChoice(choice);
        }

        private void ExecuteUserChoice(string choice)
        {
            if (choice == string.Empty)
            {
                _consoleDataReaderWriter.DisplayMessage(_exitMessage);
                Environment.Exit(0);
                return;
            }
            else if (choice == _invalidString)
            {
                _consoleDataReaderWriter.DisplayError("Invalid selection.");
            }
            else
            {
                var numbers = GetNumbersFromUser();

                if (numbers == null || numbers.Count < 2)
                {
                    _consoleDataReaderWriter.DisplayError(
                        "Not enough numbers entered. Aborting operation...");
                    return;
                }

                switch (choice)
                {
                    case "add":
                        DisplayResult("sum", numbers, 
                            Calculator.Add(numbers));
                        break;

                    case "subtract":
                        DisplayResult("difference", numbers, 
                            Calculator.Subtract(numbers));
                        break;

                    case "multiply":
                        DisplayResult("product", numbers,
                            Calculator.Multiply(numbers));
                        break;

                    case "divide":
                        DisplayResult("quotient", numbers,
                            Calculator.Divide(numbers));
                        break;
                }
            }
        }

        private void DisplayResult(string operationResultTerm, 
            IEnumerable<int> numbers, object result)
        {
            string resultString = $"The {operationResultTerm} of " +
                $"{string.Join(',', numbers)} is {result}.";
            _consoleDataReaderWriter.DisplayMessage(resultString);
        }

        private List<int> GetNumbersFromUser()
        {
            string input;
            var numbers = new List<int>();

            do
            {
                _consoleDataReaderWriter.DisplayMessageInline(
                    "Enter an integer (enter 'q' to finalize): ");
                input = _consoleDataReaderWriter.GetUserInput();
                if (string.Equals(input, "q"))
                {
                    break;
                }
                else if (!IsValidInteger(input))
                {
                    _consoleDataReaderWriter.DisplayError("Invalid input.");
                }
                else
                {
                    numbers.Add(int.Parse(input));
                }
            } while (!string.Equals(input, "q"));

            return numbers;
        }

        private static bool IsValidInteger(string input)
        {
            return int.TryParse(input, out _);
        }

        private string ParseUserChoice(string input)
        {
            return input.ToLower() switch
            {
                "1" or "a" => "add",
                "2" or "s" => "subtract",
                "3" or "m" => "multiply",
                "4" or "d" => "divide",
                "5" or "e" => string.Empty,
                _ => _invalidString,
            };
        }
    }
}

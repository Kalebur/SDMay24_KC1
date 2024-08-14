using System;
using System.Collections.Generic;

namespace KnowledgeCheck1_Calculator
{
    public class App
    {
        private readonly IDataReaderWriter _consoleDataReaderWriter;
        private readonly string _invalidString = "invalid";

        public App(IDataReaderWriter dataReaderWriter)
        {
            _consoleDataReaderWriter = dataReaderWriter;
        }

        public void Run()
        {
            _consoleDataReaderWriter.DisplayHeader();

            string input;

            do
            {
                _consoleDataReaderWriter.DisplayOptions();
                _consoleDataReaderWriter.DisplayMessage("Please choose from the options above.");
                _consoleDataReaderWriter.DisplayMessage("You may enter either the number or the action letter.");
                input = _consoleDataReaderWriter.GetUserInput();
                HandleUserInput(input);
            } while (input.ToLower() != "e" && input != "5");

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
                _consoleDataReaderWriter.DisplayMessage("Goodbye!");
                return;
            }
            else if (choice == _invalidString)
            {
                _consoleDataReaderWriter.DisplayError("Invalid selection.");
            }
        }

        private string ParseUserChoice(string input)
        {
            switch (input.ToLower())
            {
                case "1":
                case "a":
                    return "add";

                case "2":
                case "s":
                    return "subtract";

                case "3":
                case "m":
                    return "multiply";

                case "4":
                case "d":
                    return "divide";

                case "5":
                case "e":
                    return string.Empty;

                default:
                    return _invalidString;
            }
        }
    }
}

using System;

namespace KnowledgeCheck1_Calculator
{
    public class App
    {
        private readonly IDataReaderWriter _consoleDataReaderWriter;

        public App(IDataReaderWriter dataReaderWriter)
        {
            _consoleDataReaderWriter = dataReaderWriter;
        }

        public void Run()
        {
            _consoleDataReaderWriter.DisplayHeader();

            var input = string.Empty;

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
            string choice = string.Empty;

            switch (input.ToLower())
            {
                case "1":
                case "a":
                    choice = "add";
                    break;

                case "2":
                case "s":
                    choice = "subtract";
                    break;

                case "3":
                case "m":
                    choice = "multiply";
                    break;

                case "4":
                case "d":
                    choice = "divide";
                    break;

                case "5":
                case "e":
                    _consoleDataReaderWriter.DisplayMessage("Goodbye!");
                    break;

                default:
                    _consoleDataReaderWriter.DisplayError($"\"{input}\" is not a valid option");
                    break;
            }

            if (choice !=  string.Empty)
            {
                _consoleDataReaderWriter.DisplayMessage("Cherry Pie");
            }
        }
    }
}

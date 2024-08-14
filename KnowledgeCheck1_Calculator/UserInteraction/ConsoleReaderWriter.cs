﻿using System;
using System.Text;
using KnowledgeCheck1_Calculator.Logic;

namespace KnowledgeCheck1_Calculator.UserInteraction
{
    internal class ConsoleReaderWriter : IDataReaderWriter
    {
        private readonly ICustomStringBuilder _stringBuilder;
        private readonly int _totalLineLength = 40;
        private readonly char _dividerCharacter = '*';
        private string _header;

        public ConsoleReaderWriter(ICustomStringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
            BuildHeader();
        }

        public void DisplayHeader()
        {
            Console.WriteLine(_header);
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayMessageInline(string message)
        {
            Console.Write(message);
        }

        public void DisplayError(string message)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
            Console.WriteLine();
        }

        public void DisplayOptions()
        {
            DisplayMessage("1. [A]ddition");
            DisplayMessage("2. [S]ubtraction");
            DisplayMessage("3. [M]ultiplication");
            DisplayMessage("4. [D]ivision");
            DisplayMessage("5. [E]xit");
            DisplayMessage("");
        }

        public int GetIntegerFromUser()
        {
            bool validIntegerEntered;

            DisplayMessageInline("Enter an integer: ");
            validIntegerEntered = int.TryParse(Console.ReadLine(),
                out int userInput);

            while (!validIntegerEntered)
            {
                DisplayMessage("Invalid input. " +
                    "Only whole numbers will be accepted.");
                DisplayMessageInline("Enter an integer: ");
                validIntegerEntered = int.TryParse(Console.ReadLine(),
                    out userInput);
            }

            return userInput;
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        private void BuildHeader()
        {
            AppendLineOfCharacters(_dividerCharacter);
            AppendDecoratedLine(_dividerCharacter, "");
            AppendDecoratedLine(_dividerCharacter, "Code:You Calculator");
            AppendDecoratedLine(_dividerCharacter, "Version 1.0");
            AppendDecoratedLine(_dividerCharacter, "");
            AppendLineOfCharacters(_dividerCharacter);
            _header = _stringBuilder.ToString();
        }

        private void AppendLineOfCharacters(char character)
        {
            for (int i = 0; i < _totalLineLength; i++)
            {
                _stringBuilder.Append(character.ToString());
            }

            _stringBuilder.Append(Environment.NewLine);
        }

        private void AppendDecoratedLine(char character, string text)
        {
            int totalBlanks = GetNeededBlankCount(text);
            int paddingLength = totalBlanks / 2;
            _stringBuilder.Append(character.ToString());

            if (totalBlanks % 2 == 0)
            {
                AppendCharacterXTimes(' ', paddingLength);
            }
            else
            {
                AppendCharacterXTimes(' ', paddingLength + 1);
            }

            _stringBuilder.Append(text);

            AppendCharacterXTimes(' ', paddingLength);
            _stringBuilder.Append(character.ToString());
            _stringBuilder.Append(Environment.NewLine);
        }

        private void AppendCharacterXTimes(char character, int repeatCount)
        {
            for (int i = 0; i < repeatCount; i++)
            {
                _stringBuilder.Append(character.ToString());
            }
        }

        private int GetNeededBlankCount(string text)
        {
            return _totalLineLength - 2 - text.Length;
        }
    }
}

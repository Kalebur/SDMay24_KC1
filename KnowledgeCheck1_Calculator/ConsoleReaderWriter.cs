using System;
using System.Text;

namespace KnowledgeCheck1_Calculator
{
    internal class ConsoleReaderWriter : IDataReaderWriter
    {
        private readonly ICustomStringBuilder _stringBuilder;
        private int _totalLineLength = 40;
        private char _dividerCharacter = '*';
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
            throw new System.NotImplementedException();
        }

        public void GetNumberFromUser()
        {
            throw new System.NotImplementedException();
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
            } else
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
            return (_totalLineLength - 2 - text.Length);
        }
    }
}

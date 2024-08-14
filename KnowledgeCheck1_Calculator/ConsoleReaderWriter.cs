using System.Text;

namespace KnowledgeCheck1_Calculator
{
    internal class ConsoleReaderWriter : IDataReaderWriter
    {
        private readonly ICustomStringBuilder _stringBuilder;

        public ConsoleReaderWriter(ICustomStringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }
        public void DisplayMenu()
        {
            
        }

        public void DisplayMessage(string message)
        {
            throw new System.NotImplementedException();
        }

        public void GetNumberFromUser()
        {
            throw new System.NotImplementedException();
        }

        private void PrintLineOfCharacters(char character, int count)
        {
            for (int i = 0; i < count; i++)
            {
                _stringBuilder.Append(character.ToString());
            }
        }
    }
}

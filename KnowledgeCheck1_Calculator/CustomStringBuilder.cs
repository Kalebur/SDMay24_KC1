using System.Text;

namespace KnowledgeCheck1_Calculator
{
    public class CustomStringBuilder : ICustomStringBuilder
    {
        private readonly StringBuilder _stringBuilder;
        public CustomStringBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        public void Append(string text)
        {
            throw new System.NotImplementedException();
        }

        public void AppendLine(string lineText)
        {
            throw new System.NotImplementedException();
        }
    }
}

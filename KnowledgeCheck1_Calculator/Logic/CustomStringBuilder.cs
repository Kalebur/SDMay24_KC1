using System.Text;

namespace KnowledgeCheck1_Calculator.Logic
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
            _stringBuilder.Append(text);
        }

        public void AppendLine(string lineText)
        {
            _stringBuilder.AppendLine(lineText);
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}

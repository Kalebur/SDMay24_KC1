namespace KnowledgeCheck1_Calculator
{
    public interface ICustomStringBuilder
    {
        string ToString();
        void Append(string text);
        void AppendLine(string lineText);
    }
}
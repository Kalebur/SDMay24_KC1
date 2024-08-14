namespace KnowledgeCheck1_Calculator.Logic
{
    public interface ICustomStringBuilder
    {
        string ToString();
        void Append(string text);
        void AppendLine(string lineText);
    }
}
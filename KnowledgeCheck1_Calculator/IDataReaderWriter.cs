namespace KnowledgeCheck1_Calculator
{
    public interface IDataReaderWriter
    {
        void DisplayHeader();
        int GetIntegerFromUser();
        void DisplayMessage(string message);
    }
}
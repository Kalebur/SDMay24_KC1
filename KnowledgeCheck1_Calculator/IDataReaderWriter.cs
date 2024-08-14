namespace KnowledgeCheck1_Calculator
{
    public interface IDataReaderWriter
    {
        void DisplayHeader();
        void DisplayOptions();
        int GetIntegerFromUser();
        string GetUserInput();
        void DisplayMessage(string message);
        void DisplayMessageInline(string message);
        void DisplayError(string message);
    }
}
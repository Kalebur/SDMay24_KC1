namespace KnowledgeCheck1_Calculator.UserInteraction
{
    public interface IUserInteractor
    {
        void DisplayHeader();
        void DisplayOptions();
        string GetUserInput();
        void DisplayMessage(string message);
        void DisplayMessageInline(string message);
        void DisplayError(string message);
    }
}
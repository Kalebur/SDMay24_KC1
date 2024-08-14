namespace KnowledgeCheck1_Calculator
{
    public class App
    {
        public void Run()
        {
            var consoleInteractor = new ConsoleReaderWriter(new CustomStringBuilder());
            consoleInteractor.DisplayHeader();
        }
    }
}

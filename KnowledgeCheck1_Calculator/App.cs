using System;

namespace KnowledgeCheck1_Calculator
{
    public class App
    {
        public void Run()
        {
            var consoleInteractor = new ConsoleReaderWriter(new CustomStringBuilder());
            consoleInteractor.DisplayHeader();

            var input = consoleInteractor.GetIntegerFromUser();

            consoleInteractor.DisplayMessage($"You entered {input}");
        }
    }
}

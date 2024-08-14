using System;
using System.Text;

namespace KnowledgeCheck1_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new App(
                new ConsoleReaderWriter(
                    new CustomStringBuilder()
                    )
                );

            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred and the application must close.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
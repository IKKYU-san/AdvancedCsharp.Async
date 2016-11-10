
namespace AdvancedCsharp.Async
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            SetupConsoleWindow();

            new AsyncAssignement().Run();

            StopAndWaitForUser();
        }


        static public void SetupConsoleWindow()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowWidth = 60;
            Console.WindowHeight = 30;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }

        private static void StopAndWaitForUser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Slut");
            Console.ReadKey();
        }
    }
}


/*

Tid (medianvärde) efter att ha testat 10 anrop:

    AsyncExample1   	            539
    AsyncExample1BadWithResult 	    543
    AsyncExample1BadWithWaitAll 	568
    AsyncExample1Bad 	            651

*/

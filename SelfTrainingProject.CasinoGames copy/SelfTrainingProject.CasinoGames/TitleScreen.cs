using System;
namespace SelfTrainingProject.CasinoGames
{
    public class TitleScreen
    {
        // contains functionaltity to display a title screen
        public void RunTitleScreen()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***************************************************************************************");
            Console.Write("*");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("                                                                                     ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("*");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("                            HUNTER TECHNICIAL SOLUTIONS!                             ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("*");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("                                   Casino Games!                                     ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*");

            Console.Write("*");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("                                                                                     ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***************************************************************************************\n\n");

            Console.ResetColor();
        }
    }
}

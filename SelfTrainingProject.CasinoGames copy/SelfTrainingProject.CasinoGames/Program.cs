using System;

namespace SelfTrainingProject.CasinoGames
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate title file
            TitleScreen title = new TitleScreen();
            string errorMessage = "Invalid input";

            // Run login process
            while (ProgramLogin.j < 2)
            {
                // clear screen and display title screen
                Console.Clear();
                title.RunTitleScreen();
                Console.WriteLine("Please enter 1 to login or type \"quit\" to exit : ");
                string entry = Console.ReadLine();
                if (string.Equals(entry.ToLower(), "quit"))
                {
                    System.Environment.Exit(1);
                }
                else if (string.Equals(entry, ""))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                    Console.Beep();
                    Console.ResetColor();
                } 
                // if entry equal to 1, carry out login attempt
                try
                {
                    int userEntry = int.Parse(entry);
                    if (userEntry == 1)
                    {
                        ProgramLogin.loginAttempt();
                    }
                    //else display error and restart loop
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(errorMessage);
                        Console.Beep();
                        Console.ResetColor();
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage + " Exception handled!");
                    Console.Beep();
                    Console.ResetColor();
                }
                // depending on the outcome of the login process:
                if (ProgramLogin.j == 2)// run admin user options
                {
                    AdminProfile.RunAdminProfile();
                }
                else if (ProgramLogin.j == 3)// or general user options
                {
                    UserProfile.RunUserProfile();
                    Menu menu = new Menu();
                    menu.RunMenu();
                }
                else if (ProgramLogin.j == 4)// or John Doe/general user options
                {
                    ExampleProfile.RunExampleProfile();
                    Menu menu = new Menu();
                    menu.RunMenu();
                }
                ProgramLogin.j = 0;
            }
        }
    }
}

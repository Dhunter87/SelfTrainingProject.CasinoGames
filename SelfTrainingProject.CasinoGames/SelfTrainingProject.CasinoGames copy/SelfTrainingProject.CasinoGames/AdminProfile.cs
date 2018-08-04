using System;
namespace SelfTrainingProject.CasinoGames
{
    public class AdminProfile
    {
        public static string ProfileName;
        public static string errorMessage = "Invalid input";
        public static readonly string adminUserName = "Admin123";
        public static readonly string adminPassword = "Admin321";
        public AdminProfile()
        {

        }
        public static void RunAdminProfile()
        {
            Console.WriteLine("Please enter 1 add new profile or type \"quit\" to exit : ");
            string entry = Console.ReadLine();
            if (string.Equals(entry.ToLower(), "quit"))
            {
                System.Environment.Exit(1);
            }
            else if (string.Equals(entry, ""))
            {
                Console.WriteLine(errorMessage);
            }
            try
            {
                int userEntry = int.Parse(entry);
                if (userEntry == 1)
                {
                    Console.WriteLine("Please enter profile name : ");
                    ProfileName = Console.ReadLine();
                    NewProfile.addNewProfile(ProfileName);

                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(errorMessage + " Exception handled!");
            }
        }
    }
}

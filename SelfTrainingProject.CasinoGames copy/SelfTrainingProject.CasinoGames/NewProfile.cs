using System;

namespace SelfTrainingProject.CasinoGames
{
    // contains functionallity for admin profile to store a new user profile
    public class NewProfile
    {
        public static int UserCount;


        public NewProfile()
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter users first name : ");
            UserProfile.FirstName = Console.ReadLine().Trim();
            Console.WriteLine("Please enter users last name  : ");
            UserProfile.LastName = Console.ReadLine().Trim();
            Console.WriteLine("Please enter users date of birth  : ");
            UserProfile.DateOfBirth = Console.ReadLine().Trim();

            Console.WriteLine("Please enter users user name  : ");
            UserProfile.UserName = Console.ReadLine().Trim();
            Console.WriteLine("Please enter users password   : ");
            UserProfile.Password = Console.ReadLine().Trim();

        }
        public static void addNewProfile(string profileName)
        {
            NewProfile profile = new NewProfile();
        }
    }
}

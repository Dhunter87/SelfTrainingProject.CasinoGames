using System;
namespace SelfTrainingProject.CasinoGames
{
    public class ExampleProfile
    {
        public double Credits { get; private set; } = 100;
        public double DecreaseCredits(double value) => Credits -= value;
        public double AddCredits(double value) => Credits += value;
        public static string errorMessage = "Invalid input";

        public ExampleProfile()
        {

        }
        public static void RunExampleProfile()
        {
            ExampleProfile.GetAccountDetails();
        }

        public static readonly string FirstName = "John";
        public static readonly string LastName = "Doe";
        public static readonly string DateOfBirth = "10/11/1990";
        public static readonly string UserName = "JD1990";
        public static readonly string Password = "123";


        public static void GetAccountDetails()
        {
            Console.WriteLine("");
            Console.WriteLine("First name     : " + FirstName);
            Console.WriteLine("Last name      : " + LastName);
            Console.WriteLine("DOB            : " + DateOfBirth);
            Console.WriteLine("User name      : " + UserName);

            Console.WriteLine("");

        }

    }
}

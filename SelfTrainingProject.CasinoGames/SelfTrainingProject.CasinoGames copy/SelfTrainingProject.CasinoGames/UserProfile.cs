using System;
namespace SelfTrainingProject.CasinoGames
{
    public class UserProfile
    {
        public double Credits { get; private set;  } = 100;
        public double DecreaseCredits(double value) =>  Credits -= value;
        public double  AddCredits(double value) => Credits += value;

        public static string errorMessage = "Invalid input";

        private static string firstName;
        public static string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private static string lastName;
        public static string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private static string dateOfBirth;
        public static string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        private static string address;
        public static string Address
        {
            get { return address; }
            set { address = value; }
        }
        private static string phoneNumber;
        public static string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        private static string userName;
        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private static string password;
        public static string Password
        {
            get { return password; }
            set { password = value; }
        }
        private static string initialBalance;
        public static string InitialBalance
        {
            get { return initialBalance; }
            set { initialBalance = value; }
        }
        private static string eMailAddress;
        public static string EMailAddress
        {
            get { return eMailAddress; }
            set { eMailAddress = value; }
        }
        public UserProfile()
        {

        }
        public static void RunUserProfile()
        {
            UserProfile.GetAccountDetails();
        }
        public static void GetAccountDetails()
        {
            Console.WriteLine("");
            Console.WriteLine("First name     : " + firstName);
            Console.WriteLine("Last name      : " + lastName);
            Console.WriteLine("DOB            : " + DateOfBirth);
            Console.WriteLine("User name      : " + userName);
            Console.WriteLine("Address        : " + Address);
            Console.WriteLine("Phone number   : " + PhoneNumber);
            Console.WriteLine("");

        }
    }
}

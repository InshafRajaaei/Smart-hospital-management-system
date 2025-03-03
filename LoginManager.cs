using System;

namespace HospitalManagementSystem
{
    class LoginManager
    {
        private readonly string username = "group";
        private readonly string password = "0021";

        public bool ShowLoginMenu()
        {
            Console.WriteLine("Welcome to Hospital Management System\n\n");
            string inputUsername = Utility.GetNonEmptyString("Enter Username: ");
            string inputPassword = Utility.GetNonEmptyString("Enter Password: ");

            if (inputUsername == username && inputPassword == password)
            {
                Console.WriteLine("\nLogin successful!");
                return true;
            }
            else
            {
                Console.WriteLine("\nInvalid credentials. Exiting...");
                return false;
            }
        }
    }
}
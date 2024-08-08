using GymProject.Models;
using GymProject.Services.Validations;
using System;

namespace GymProject.Services.Inputs
{
    /// <summary>
    /// Gets input from user and validates it with the 'Validation' class
    /// </summary>
    class Input
    {
        /// <summary>
        /// Gets input from user and fills out all the fields of a client object
        /// </summary>
        /// <returns>Client object</returns>
        public static Client GetClient()
        {
            Client c = new Client
            {
                Id = GetId(),
                FirstName = GetFirstName(),
                LastName = GetLastName(),
                Gender = GetGender(),
                DateOfBirth = GetDateOfBirth("Client"),
                City = GetCity(),
                Address = GetAddress(),
                Phone = GetPhone(),
                Email = GetEmail(),
                Height = GetHeight(),
                Weight = GetWeight()
            };
            c.Bmi = Math.Round(c.Weight / (Math.Pow(c.Height, 2)), 2);
            c.IsActive = true;
            return c;
        }

        /// <summary>
        /// Gets input from user and fills out all the fields of a coach object
        /// </summary>
        /// <returns>Coach object</returns>
        public static Coach GetCoach()
        {
            Coach c = new Coach
            {
                Id = GetId(),
                FirstName = GetFirstName(),
                LastName = GetLastName(),
                Gender = GetGender(),
                DateOfBirth = GetDateOfBirth("Coach"),
                City = GetCity(),
                Address = GetAddress(),
                Phone = GetPhone(),
                Email = GetEmail(),
                BankAccount = GetBankDetails(),
                Profession = GetProfession(),
                IsActive = true
            };
            return c;
        }

        /// <summary>
        /// Recieves input until user enters a number between x-y
        /// </summary>
        /// <param name="x">Lower limit</param>
        /// <param name="y">Upper limit</param>
        /// <param name="message">Prompt</param>
        /// <returns>Integer between x-y</returns>
        public static int GetIntInRange(int x, int y, string message)
        {
            int input;
            do
            {
                int.TryParse(Console.ReadLine(), out input);
            } while (!Validation.CheckIntRange(x, y, input, message));
            return input;
        }

        /// <summary>
        /// Eecieves input until user enters a 9 digit string
        /// </summary>
        /// <returns>9 digit string</returns>
        public static string GetId()
        {
            string input;
            do
            {
                Console.WriteLine("1. ID Number:\nPlease enter ID (9 digits)");
                input = Console.ReadLine();
            } while (!Validation.CheckId(input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'First Name'
        /// </summary>
        /// <returns>Letter only string</returns>
        public static string GetFirstName()
        {
            string input;
            do
            {
                Console.Write($"2. First Name\nPlease enter first name: ");
                input = Console.ReadLine();
            } while (!Validation.CheckString("First Name", input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'Last Name'
        /// </summary>
        /// <returns>Letter only string</returns>
        public static string GetLastName()
        {
            string input;
            do
            {
                Console.Write($"3. Last Name\nPlease enter last name: ");
                input = Console.ReadLine();
            } while (!Validation.CheckString("Last Name", input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'Gender'
        /// </summary>
        /// <returns>'F'/'M'/'O'</returns>
        public static char GetGender()
        {
            char input;
            do
            {
                Console.WriteLine("4. Gender:\nPlease enter gender (F/M/O)");
                char.TryParse(Console.ReadLine(), out input);
            } while (!Validation.CheckGender(input));
            return char.ToUpper(input);
        }

        /// <summary>
        /// recieves input until user enters a valid 'date of birth' dd/mm/yyyy
        /// </summary>
        /// <param name="obj">Coach/Client</param>
        /// <returns>Date of birth string in format of dd/mm/yyyy</returns>
        public static string GetDateOfBirth(string obj)
        {
            string input;
            do
            {
                Console.WriteLine("5. Date Of Birth:\nPlease enter date of birth (dd/mm/yyyy)");
                input = Console.ReadLine();
            } while (!Validation.CheckDateOfBirth(obj, input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'City'
        /// </summary>
        /// <returns>Letter only string</returns>
        public static string GetCity()
        {
            string input;
            do
            {
                Console.Write($"6. City\nPlease enter city: ");
                input = Console.ReadLine();
            } while (!Validation.CheckString("City", input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'Address'
        /// </summary>
        /// <returns>String longer than 0</returns>
        public static string GetAddress()
        {
            string input;
            do
            {
                Console.Write($"7. Address\nPlease enter Address: ");
                input = Console.ReadLine();
            } while (!Validation.CheckString("Address", input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'phone'
        /// </summary>
        /// <returns>10 digit string starting with '0'</returns>
        public static string GetPhone()
        {
            string input;
            do
            {
                Console.Write($"8. Phone\nPlease enter phone: ");
                input = Console.ReadLine();
            } while (!Validation.CheckInt("Phone", input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'email'
        /// </summary>
        /// <returns>String with only one '@' and doesnt end/start with '@'</returns>
        public static string GetEmail()
        {
            string input;
            do
            {
                Console.Write($"9. E-mail\nPlease enter e-mail: ");
                input = Console.ReadLine();
            } while (!Validation.CheckEmail(input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'height'
        /// </summary>
        /// <returns>Double between 1-3</returns>
        public static double GetHeight()
        {
            double input;
            do
            {
                Console.Write($"10. Height\nPlease enter height (in meters)\n");
                double.TryParse(Console.ReadLine(), out input);
            } while (!Validation.CheckDouble("Height", input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'weight'
        /// </summary>
        /// <returns>Double between 40-500</returns>
        public static double GetWeight()
        {
            double input;
            do
            {
                Console.Write($"11. Weight\nPlease enter Weight (in kilos)\n");
                double.TryParse(Console.ReadLine(), out input);
            } while (!Validation.CheckDouble("Weight", input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters valid details for bank account
        /// </summary>
        /// <returns>Bank object</returns>
        public static Bank GetBankDetails()
        {
            Bank b = new Bank
            {
                BankName = GetBankName(),
                BankBranch = GetBankBranch(),
                BankAccount = GetBankAccount()
            };
            return b;
        }

        /// <summary>
        /// recieves input until user enters a valid 'bank name'
        /// </summary>
        /// <returns>String longer than 0 characters</returns>
        public static string GetBankName()
        {
            string input;
            do
            {
                Console.Write($"10. Bank Account\nPlease enter bank name: ");
                input = Console.ReadLine();
            } while (!Validation.CheckString("Bank Name", input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'Bank Branch'
        /// </summary>
        /// <returns>Digit only string</returns>
        public static string GetBankBranch()
        {
            string input;
            do
            {
                Console.Write($"10. Bank account\nPlease enter branch number: ");
                input = Console.ReadLine();
            } while (!Validation.CheckInt("Bank Branch", input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'Bank Account'
        /// </summary>
        /// <returns>Digit only string</returns>
        public static string GetBankAccount()
        {
            string input;
            do
            {
                Console.Write($"10. Bank account\nPlease enter account number: ");
                input = Console.ReadLine();
            } while (!Validation.CheckInt("Bank Account", input));
            return input;
        }

        /// <summary>
        /// Recieves input until user enters a valid 'Profession'
        /// </summary>
        /// <returns>String longer than 3 characters</returns>
        public static string GetProfession()
        {
            string input;
            do
            {
                Console.Write($"11. Profession\nPlease enter profession: ");
                input = Console.ReadLine();
            } while (!Validation.CheckString("Profession", input));
            return input;
        }
    }
}

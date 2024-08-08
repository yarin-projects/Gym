using System;

namespace GymProject.Services.Validations
{
    /// <summary>
    /// Validates user input taken from the 'Input' class
    /// </summary>
    internal class Validation
    {
        /// <summary>
        /// Returns true if the given 'ID' is a 9 digit string
        /// </summary>
        /// <param name="id">Input</param>
        public static bool CheckId(string id)
        {
            if (id.Length > 9)
            {
                Console.Clear();
                Console.WriteLine("ID can't be longer than 9 digits!\n");
                return false;
            }//error message for input longer than 9 digits
            if (id.Length < 9)
            {
                Console.Clear();
                Console.WriteLine("ID can't be shorter than 9 digits!\n");
                return false;
            }//error message for input shorter than 9 digits
            for (int i = 0; i < id.Length; i++)
            {
                if (!char.IsDigit(id[i]))//character that isnt a digit
                {
                    Console.Clear();
                    Console.WriteLine("ID has to contain 9 digits only!\n");//input doesnt contain 9 digits
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Returns true if 'input' passes the checks of a given 'field'
        /// </summary>
        /// <param name="field">"First Name"/"Last Name"/"City"/"Address"/"Bank Name"/"Profession"</param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool CheckString(string field, string input)
        {
            bool isProfession = false;
            bool isBankNameOrAddress = false;
            switch (field.ToLower())
            {
                case "address":
                    isBankNameOrAddress = true;
                    break;
                case "bank name":
                    isBankNameOrAddress = true;
                    break;
                case "profession":
                    isProfession = true;
                    break;
            }//turning on the needed booleans for the given 'field'
            if (string.IsNullOrEmpty(input))//checks for empty string
            {
                Console.Clear();
                Console.WriteLine($"{field} can't be empty.\n");
                return false;
            }
            if (isBankNameOrAddress)
            {
                return true;
            }//bank name/address needs more than 0 characters
            if (isProfession && input.Length < 3)
            {
                Console.Clear();
                Console.WriteLine($"{field} has to contain atleast 4 charcters!\n");
                return false;
            }
            if (isProfession)
            {
                return true;
            }//profession is valid if it contains more than 4 characters
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))//checks if character in spot 'i' isnt a letter
                {
                    Console.Clear();
                    Console.WriteLine($"Invalid {field.ToLower()}.\n{field} can only contain letters!\n");
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Returns true if user enters 'F'/'f'/'M'/'m'/'O'/'o'
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static bool CheckGender(char gender)
        {
            switch (char.ToLower(gender))
            {
                case 'f':
                case 'm':
                case 'o':
                    return true;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid gender\nYou entered an unknown character\n");
                    return false;
            }
        }


        /// <summary>
        /// returns true if user enters valid date of birth 'dd/mm/yyyy'
        /// </summary>
        /// <param name="obj">"Coach"/"Client"</param>
        /// <param name="dateOfBirth">Input</param>
        /// <returns></returns>
        public static bool CheckDateOfBirth(string obj, string dateOfBirth)
        {
            int ageLimit = 0;
            switch (obj.ToLower())
            {
                case "client":
                    ageLimit = 14;
                    break;
                case "coach":
                    ageLimit = 18;
                    break;
            }//setting age limit for coach/client
            if (string.IsNullOrEmpty(dateOfBirth))
            {
                Console.Clear();
                Console.WriteLine("Invalid date of birth.\n");
                return false;
            }
            //error message for empty string

            string[] date = dateOfBirth.Split('/');
            if (date.Length > 3 || date.Length < 3)
            {
                Console.Clear();
                Console.WriteLine("Invalid date of birth.\n");
                return false;
            }
            //error message if there are too many '/'

            if (!int.TryParse(date[0], out int day) ||
                !int.TryParse(date[1], out int month) ||
                !int.TryParse(date[2], out int year))
            {
                Console.Clear();
                Console.WriteLine("Invalid date of birth.\n");
                return false;
            }
            //error message if one of the strings doesnt parse to integer

            if (month > 12 || month < 1)
            {
                Console.Clear();
                Console.WriteLine("Invalid month.\n");
                return false;
            }
            //error message if month doesnt exist

            if (year > 9999 || year < 1)
            {
                Console.Clear();
                Console.WriteLine($"Invalid year.\n{obj} must be between {ageLimit}-120 years old\n");
                return false;
            }
            //checks if year is too big/small for the DaysInMonth() method

            if (DateTime.DaysInMonth(year, month) < day || 1 > day)
            {
                Console.Clear();
                Console.WriteLine("Invalid day.\n");
                return false;
            }
            //error message if day doesnt exist

            if (year > DateTime.Today.Year - ageLimit || year < DateTime.Today.Year - 120)
            {
                Console.Clear();
                Console.WriteLine($"Invalid year.\n{obj} must be between {ageLimit}-120 years old\n");
                return false;
            }
            //error message if year too big or too small
            return true;
        }


        /// <summary>
        /// Returns true if 'input' passes the checks of a given 'field'
        /// </summary>
        /// <param name="field">"Phone"/"Bank Branch"/"Bank Account"</param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool CheckInt(string field, string input)
        {
            bool isPhone = false;
            if (field.ToLower() == "phone")
                isPhone = true;
            //setting values to be able to print different messages for each 'field'

            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Console.WriteLine($"{field} can't be empty!\n");
                return false;
            }//checks for empty input
            if (isPhone && input.Length != 10)
            {
                Console.Clear();
                Console.WriteLine("Phone has to contain 10 digits!\n");
                return false;
            }//checks if input contains 9 digits
            if (isPhone && input[0] != '0')
            {
                Console.Clear();
                Console.WriteLine("Phone has to start with 0!\n");
                return false;
            }//checks if input starts with 0

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    Console.Clear();
                    Console.WriteLine($"{field} can only contain digits!\n");
                    return false;
                }//breaks from loop when a character that isnt a digit is found
            }
            return true;
        }


        /// <summary>
        /// Returns true if user enters string containing only one '@' and doesnt end/start with '@'
        /// </summary>
        /// <param name="email">Input</param>
        public static bool CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                Console.Clear();
                Console.WriteLine("E-mail can't be empty!\n");
                return false;
            }
            //checks if input is empty and presents error message

            if (!email.Contains("@"))
            {
                Console.Clear();
                Console.WriteLine("E-mail has to contain '@'!\n");
                return false;
            }
            //checks if input contains atleast one '@' and presents error message

            if (email.Split('@').Length > 2)
            {
                Console.Clear();
                Console.WriteLine("E-mail can only contain one '@'!\n");
                return false;
            }
            //checks if input contains more than one '@' and presents error message

            if (email.IndexOf("@") == 0 || email.IndexOf("@") == email.Length - 1)
            {
                Console.Clear();
                Console.WriteLine("E-mail can't end/start with '@'!\n");
                return false;
            }
            return true;
        }


        /// <summary>
        /// Returns true if user enters valid height/weight
        /// </summary>
        /// <param name="field">"Height"/"Weight"</param>
        /// <param name="input"></param>
        public static bool CheckDouble(string field, double input)
        {
            double upperLimit = 0;
            double lowerLimit = 0;
            switch (field.ToLower())
            {
                case "height":
                    upperLimit = 3;
                    lowerLimit = 1;
                    break;
                case "weight":
                    upperLimit = 500;
                    lowerLimit = 40;
                    break;

            }//setting values for upper/lower limit depending on field
            if (input <= upperLimit && input >= lowerLimit)//checks height is in range
            {
                return true;
            }
            Console.Clear();
            if (input > upperLimit)
                Console.WriteLine($"{field} is too high!\n{field} must be between {lowerLimit}-{upperLimit}\n");
            else
                Console.WriteLine($"{field} is too low!\n{field} must be between {lowerLimit}-{upperLimit}\n");
            return false;
        }

        /// <summary>
        /// returns true if user enters number between x-y
        /// </summary>
        /// <param name="x">Lower limit</param>
        /// <param name="y">Upper limit</param>
        /// <param name="input"></param>
        /// <param name="message"></param>
        public static bool CheckIntRange(int x, int y, int input, string message)
        {
            if (input >= x && input <= y)
            {
                return true;
            }
            Console.Clear();
            Console.WriteLine($"Invalid number\nEnter a number between {x}-{y}\n\n");
            Console.WriteLine(message);
            return false;
        }
    }
}

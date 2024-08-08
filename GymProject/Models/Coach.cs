
namespace GymProject.Models
{
    internal class Coach : Person
    {
        public Bank BankAccount { get; set; }
        public string Profession { get; set; }

        public override string ToString()
        {
            string gend = "";
            string status = "";
            switch (char.ToLower(Gender))
            {
                case 'f':
                    gend = "female";
                    break;
                case 'm':
                    gend = "male";
                    break;
                case 'o':
                    gend = "other";
                    break;
            }
            switch (IsActive)
            {
                case true:
                    status = "active";
                    break;
                case false:
                    status = "inactive";
                    break;
            }
            return $"ID = {Id}\n" +
                   $"First name = {FirstName}\n" +
                   $"Last name = {LastName}\n" +
                   $"Gender = {gend}\n" +
                   $"Date of birth = {DateOfBirth}\n" +
                   $"City = {City}\n" +
                   $"Address = {Address}\n" +
                   $"Phone = {Phone}\n" +
                   $"E-mail = {Email}\n" +
                   $"{BankAccount}\n" +
                   $"Profession = {Profession}\n" +
                   $"Status = {status}";
        }//returns string with all the properties of a client
    }
}

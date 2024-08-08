
namespace GymProject.Models
{
    internal class Client : Person
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Bmi { get; set; }

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
                   $"Height = {Height}\n" +
                   $"Weight = {Weight}\n" +
                   $"BMI = {Bmi}\n" +
                   $"Status = {status}";
        }//returns string with all the properties of a client
    }
}

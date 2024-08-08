
namespace GymProject.Models
{
    class Bank
    {
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }

        public override string ToString()
        {
            return $"Bank name = {BankName}\n" +
                   $"Bank branch = {BankBranch}\n" +
                   $"Bank account = {BankAccount}";
        }
    }
}

using GymProject.Models;
using GymProject.Services.Files;
using GymProject.Services.Inputs;
using GymProject.Services.Repository;
using GymProject.UI.Fancy;
using GymProject.UI.Standard;
using System;
using System.IO;

namespace GymProject.Services.Utils
{
    internal class ManagementUtils
    {
        /// <summary>
        /// Adds a new client to the 'Clients' folder
        /// </summary>
        public static void AddClient()
        {
            Client c = Input.GetClient();
            while (FileHandler.SearchClient(c.Id))
            {
                Console.Clear();
                Console.WriteLine("There's already a client with the same ID\nPlease enter a new ID");
                c.Id = Input.GetId();
            }
            Console.Clear();
            FileHandler.SaveClient(c);
        }

        /// <summary>
        /// Presents user with reactivate menu for the client object in 'clients[index]' if inactive
        /// </summary>
        /// <param name="clients"></param>
        /// <param name="index"></param>
        /// <param name="fancyClientMenu"></param>
        private static void FancyMenuIsClientInactive(Client[] clients, int index, FancyClientMenu fancyClientMenu)
        {
            if (!clients[index].IsActive)
            {
                Console.Clear();
                fancyClientMenu.ReactivatePrompts();
                Console.CursorVisible = false;
                int selectedIndex = ConsoleUtils.MenuSelectedIndex(fancyClientMenu.Title, fancyClientMenu.Options, fancyClientMenu.SelectedIndex);
                Console.Clear();
                switch (selectedIndex)
                {
                    case 0:
                        clients[index].IsActive = true;
                        break;
                    case 1:
                        fancyClientMenu.ResetPrompts();
                        fancyClientMenu.Start();
                        break;
                }
            }
        }

        /// <summary>
        /// Presents user with fancy menu for editing client
        /// </summary>
        public static void FancyMenuEditClient()
        {
            FancyClientMenu fancyClientMenu = new FancyClientMenu();
            if (IsClientsEmpty())
            {
                Console.Write("Press any key to go back to the client menu...");
                Console.ReadKey(true);
                return;
            }
            int index = SearchClientIndex("edit");
            Client[] clients = FileHandler.LoadClients();
            FancyMenuIsClientInactive(clients, index, fancyClientMenu);
            fancyClientMenu.EditPrompts();
            while (true)
            {
                Console.CursorVisible = false;
                Console.Clear();
                int selectedIndex = ConsoleUtils.MenuSelectedIndex(clients[index].ToString() + "\n", fancyClientMenu.Options, fancyClientMenu.SelectedIndex);
                Console.CursorVisible = true;
                switch (selectedIndex)
                {
                    case 0:
                        Console.CursorVisible = false;
                        FileHandler.SaveClient(clients[index]);
                        return;
                    case 1:
                        clients[index].FirstName = Input.GetFirstName();
                        break;
                    case 2:
                        clients[index].LastName = Input.GetLastName();
                        break;
                    case 3:
                        clients[index].Gender = Input.GetGender();
                        break;
                    case 4:
                        clients[index].DateOfBirth = Input.GetDateOfBirth("Client");
                        break;
                    case 5:
                        clients[index].City = Input.GetCity();
                        break;
                    case 6:
                        clients[index].Address = Input.GetAddress();
                        break;
                    case 7:
                        clients[index].Phone = Input.GetPhone();
                        break;
                    case 8:
                        clients[index].Email = Input.GetEmail();
                        break;
                    case 9:
                        clients[index].Height = Input.GetHeight();
                        clients[index].Bmi = Math.Round(clients[index].Weight / (Math.Pow(clients[index].Height, 2)), 2);
                        break;
                    case 10:
                        clients[index].Weight = Input.GetWeight();
                        clients[index].Bmi = Math.Round(clients[index].Weight / (Math.Pow(clients[index].Height, 2)), 2);
                        break;
                }
            }
        }

        /// <summary>
        /// Presents user with fancy menu for reactivating coach object in 'coaches[index]'
        /// </summary>
        /// <param name="coaches"></param>
        /// <param name="index"></param>
        /// <param name="fancyCoachMenu"></param>
        private static void FancyMenuIsCoachInactive(Coach[] coaches, int index, FancyCoachMenu fancyCoachMenu)
        {
            if (!coaches[index].IsActive)
            {
                Console.Clear();
                fancyCoachMenu.ReactivatePrompts();
                Console.CursorVisible = false;
                int selectedIndex = ConsoleUtils.MenuSelectedIndex(fancyCoachMenu.Title, fancyCoachMenu.Options, fancyCoachMenu.SelectedIndex);
                Console.Clear();
                switch (selectedIndex)
                {
                    case 0:
                        coaches[index].IsActive = true;
                        break;
                    case 1:
                        fancyCoachMenu.ResetPrompts();
                        fancyCoachMenu.Start();
                        break;
                }
            }
        }

        /// <summary>
        /// Presents user with fancy menu for editing coach
        /// </summary>
        public static void FancyMenuEditCoach()
        {
            FancyCoachMenu fancyCoachMenu = new FancyCoachMenu();
            if (IsCoachesEmpty())
            {
                Console.Write("Press any key to go back to the coach menu...");
                Console.ReadKey(true);
                return;
            }
            int index = SearchCoachIndex("edit");
            Coach[] coaches = FileHandler.LoadCoaches();
            FancyMenuIsCoachInactive(coaches, index, fancyCoachMenu);
            fancyCoachMenu.EditPrompts();
            while (true)
            {
                Console.CursorVisible = false;
                Console.Clear();
                int selectedIndex = ConsoleUtils.MenuSelectedIndex(coaches[index].ToString() + "\n", fancyCoachMenu.Options, fancyCoachMenu.SelectedIndex);
                Console.CursorVisible = true;
                switch (selectedIndex)
                {
                    case 0:
                        Console.CursorVisible = false;
                        FileHandler.SaveCoach(coaches[index]);
                        return;
                    case 1:
                        coaches[index].FirstName = Input.GetFirstName();
                        break;
                    case 2:
                        coaches[index].LastName = Input.GetLastName();
                        break;
                    case 3:
                        coaches[index].Gender = Input.GetGender();
                        break;
                    case 4:
                        coaches[index].DateOfBirth = Input.GetDateOfBirth("Coach");
                        break;
                    case 5:
                        coaches[index].City = Input.GetCity();
                        break;
                    case 6:
                        coaches[index].Address = Input.GetAddress();
                        break;
                    case 7:
                        coaches[index].Phone = Input.GetPhone();
                        break;
                    case 8:
                        coaches[index].Email = Input.GetEmail();
                        break;
                    case 9:
                        Console.Clear();
                        Console.CursorVisible = false;
                        FancyMenuEditBankAccount(coaches, index);
                        break;
                    case 10:
                        coaches[index].Profession = Input.GetProfession();
                        break;
                }
            }
        }

        /// <summary>
        /// Presents user with fancy menu for editing bank account
        /// </summary>
        /// <param name="coaches"></param>
        /// <param name="index"></param>
        private static void FancyMenuEditBankAccount(Coach[] coaches, int index)
        {
            Bank b = coaches[index].BankAccount;
            while (true)
            {
                Console.Clear();
                string[] options = ManagementRepo.FancyMenuEditBankAccountOptions();
                int selectedOption= ConsoleUtils.MenuSelectedIndex(b + "\n", options, index);
                Console.Clear();
                switch (selectedOption)
                {
                    case 0:
                        coaches[index].BankAccount = b;
                        return;
                    case 1:
                        b.BankName = Input.GetBankName();
                        break;
                    case 2:
                        b.BankBranch = Input.GetBankBranch();
                        break;
                    case 3:
                        b.BankAccount = Input.GetBankAccount();
                        break;
                }
            }
        }

        /// <summary>
        /// Edits a client from the existing clients in the 'Clients' folder
        /// </summary>
        public static void EditClient()
        {
            if (IsClientsEmpty())
            {
                Console.Write("Press any key to go back to the client menu...");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            int index = SearchClientIndex("edit");
            Client[] clients = FileHandler.LoadClients();
            Console.Clear();
            IsClientInactive(clients, index);
            while (true)
            {
                Console.WriteLine(clients[index] + "\n");
                string message = ManagementRepo.EditClientOptions();
                Console.WriteLine(message);
                int selectedOption = Input.GetIntInRange(1, 11, message);
                Console.Clear();
                switch (selectedOption)
                {
                    case 1:
                        FileHandler.SaveClient(clients[index]);
                        return;
                    case 2:
                        clients[index].FirstName = Input.GetFirstName();
                        break;
                    case 3:
                        clients[index].LastName = Input.GetLastName();
                        break;
                    case 4:
                        clients[index].Gender = Input.GetGender();
                        break;
                    case 5:
                        clients[index].DateOfBirth = Input.GetDateOfBirth("Client");
                        break;
                    case 6:
                        clients[index].City = Input.GetCity();
                        break;
                    case 7:
                        clients[index].Address = Input.GetAddress();
                        break;
                    case 8:
                        clients[index].Phone = Input.GetPhone();
                        break;
                    case 9:
                        clients[index].Email = Input.GetEmail();
                        break;
                    case 10:
                        clients[index].Height = Input.GetHeight();
                        clients[index].Bmi = Math.Round(clients[index].Weight / (Math.Pow(clients[index].Height, 2)), 2);
                        break;
                    case 11:
                        clients[index].Weight = Input.GetWeight();
                        clients[index].Bmi = Math.Round(clients[index].Weight / (Math.Pow(clients[index].Height, 2)), 2);
                        break;
                }
            }
        }

        /// <summary>
        /// Changes a client's status to inactive
        /// </summary>
        public static void DeleteClient()
        {
            if (IsClientsEmptyOrInactive())
            {
                Console.Write("Press any key to go back to the client menu...");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            int index = SearchClientIndex("delete");
            Client[] clients = FileHandler.LoadClients();
            Console.Clear();
            clients[index].IsActive = false;
            FileHandler.SaveClient(clients[index]);
        }

        /// <summary>
        /// Lists all active clients
        /// </summary>
        public static void ListAllClients()
        {
            if (IsClientsEmptyOrInactive())
            {
                Console.Write("Press any key to go back to the client menu...");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            Client[] clients = FileHandler.LoadClients();
            for (int i = 0; i < clients.Length; i++)
            {
                if (clients[i].IsActive)
                {
                    Console.WriteLine(clients[i] + "\n");
                }
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Adds a new coach to the 'Coaches' folder
        /// </summary>
        public static void AddCoach()
        {
            Coach c = Input.GetCoach();
            while (FileHandler.SearchCoach(c.Id))
            {
                Console.Clear();
                Console.WriteLine("There's already a coach with the same ID\nPlease enter a new ID");
                c.Id = Input.GetId();
            }
            Console.Clear();
            FileHandler.SaveCoach(c);
        }

        /// <summary>
        /// Edits a coach from the existing coaches in the 'Coaches' folder
        /// </summary>
        public static void EditCoach()
        {
            if (IsCoachesEmpty())
            {
                Console.Write("Press any key to go back to the coach menu...");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            int index = SearchCoachIndex("edit");
            Coach[] coaches = FileHandler.LoadCoaches();
            Console.Clear();
            IsCoachInactive(coaches, index);
            while (true)
            {
                Console.Clear();
                Console.WriteLine(coaches[index] + "\n");
                string message = ManagementRepo.EditCoachOptions();
                Console.WriteLine(message);
                int selectedOption = Input.GetIntInRange(1, 11, message);
                Console.Clear();
                switch (selectedOption)
                {
                    case 1:
                        FileHandler.SaveCoach(coaches[index]);
                        return;
                    case 2:
                        coaches[index].FirstName = Input.GetFirstName();
                        break;
                    case 3:
                        coaches[index].LastName = Input.GetLastName();
                        break;
                    case 4:
                        coaches[index].Gender = Input.GetGender();
                        break;
                    case 5:
                        coaches[index].DateOfBirth = Input.GetDateOfBirth("Coach");
                        break;
                    case 6:
                        coaches[index].City = Input.GetCity();
                        break;
                    case 7:
                        coaches[index].Address = Input.GetAddress();
                        break;
                    case 8:
                        coaches[index].Phone = Input.GetPhone();
                        break;
                    case 9:
                        coaches[index].Email = Input.GetEmail();
                        break;
                    case 10:
                        Console.Clear();
                        EditBankAccount(coaches, index);
                        break;
                    case 11:
                        coaches[index].Profession = Input.GetProfession();
                        break;
                }
            }
        }

        /// <summary>
        /// Presents user with menu for editing bank account
        /// </summary>
        /// <param name="coaches"></param>
        /// <param name="index"></param>
        private static void EditBankAccount(Coach[] coaches, int index)
        {
            Bank b = coaches[index].BankAccount;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(b + "\n");
                string message = ManagementRepo.EditBankAccountOptions();
                Console.WriteLine(message);
                int selectedOption = Input.GetIntInRange(1, 4, message);
                Console.Clear();
                switch (selectedOption)
                {
                    case 1:
                        coaches[index].BankAccount = b;
                        return;
                    case 2:
                        b.BankName = Input.GetBankName();
                        break;
                    case 3:
                        b.BankBranch = Input.GetBankBranch();
                        break;
                    case 4:
                        b.BankAccount = Input.GetBankAccount();
                        break;
                }
            }
        }

        /// <summary>
        /// Changes a coach's status to inactive
        /// </summary>
        public static void DeleteCoach()
        {
            if (IsCoachesEmptyOrInactive())
            {
                Console.Write("Press any key to go back to the coach menu...");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            int index = SearchCoachIndex("delete");
            Coach[] coaches = FileHandler.LoadCoaches();
            Console.Clear();
            coaches[index].IsActive = false;
            FileHandler.SaveCoach(coaches[index]);
        }

        /// <summary>
        /// Lists all active coaches
        /// </summary>
        public static void ListAllCoaches()
        {
            if (IsCoachesEmptyOrInactive())
            {
                Console.Write("Press any key to go back to the coach menu...");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            Coach[] coaches = FileHandler.LoadCoaches();
            for (int i = 0; i < coaches.Length; i++)
            {
                if (coaches[i].IsActive)
                {
                    Console.WriteLine(coaches[i] + "\n");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Asks user if to reactivate client 'clients[index]'
        /// </summary>
        /// <param name="clients"></param>
        /// <param name="index"></param>
        private static void IsClientInactive(Client[] clients, int index)
        {
            if (!clients[index].IsActive)
            {
                string message = ManagementRepo.ReactivateClientOptions();
                Console.WriteLine(message);
                int selectedOption = Input.GetIntInRange(1, 2, message);
                Console.Clear();
                switch (selectedOption)
                {
                    case 1:
                        clients[index].IsActive = true;
                        break;
                    case 2:
                        ClientMenu clientMenu = new ClientMenu();
                        clientMenu.Start();
                        break;
                }
            }
        }

        /// <summary>
        /// Asks user if to reactivate coach 'coaches[index]'
        /// </summary>
        /// <param name="coaches"></param>
        /// <param name="index"></param>
        private static void IsCoachInactive(Coach[] coaches, int index)
        {
            if (!coaches[index].IsActive)
            {
                string message = ManagementRepo.ReactivateCoachOptions();
                Console.WriteLine(message);
                int selectedOption = Input.GetIntInRange(1, 2, message);
                Console.Clear();
                switch (selectedOption)
                {
                    case 1:
                        coaches[index].IsActive = true;
                        break;
                    case 2:
                        CoachMenu coachMenu = new CoachMenu();
                        coachMenu.Start();
                        break;
                }
            }
        }

        /// <summary>
        /// Checks if there are no active clients in the 'Clients' folder
        /// </summary>
        /// <returns>True if 'Clients' folder is empty or if all existing clients are inactive</returns>
        private static bool IsClientsEmptyOrInactive()
        {
            if (Directory.GetDirectories("Clients").Length < 1)
            {
                Console.Clear();
                Console.WriteLine("There are no clients in the system.\n");
                return true;
            }
            Client[] clients = FileHandler.LoadClients();
            for (int i = 0; i < clients.Length; i++)
            {
                if (clients[i].IsActive)
                {
                    return false;
                }
            }
            Console.Clear();
            Console.WriteLine("There are no active clients in the system.\n");
            return true;
        }

        /// <summary>
        /// Checks if there are clients in the 'Clients' folder
        /// </summary>
        /// <returns>True if 'Clients' folder is empty</returns>
        private static bool IsClientsEmpty()
        {
            if (Directory.GetDirectories("Clients").Length < 1)
            {
                Console.Clear();
                Console.WriteLine("There are no clients in the system.\n");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Searches the index of the client in the client array
        /// </summary>
        /// <param name="action">Edit/Delete</param>
        /// <returns>Index of the client in the clients array</returns>
        private static int SearchClientIndex(string action)
        {
            Console.Write($"Enter the ID of the client you would like to {action}: ");
            string id = Console.ReadLine();
            while (!FileHandler.SearchClient(id))
            {
                Console.Clear();
                Console.WriteLine("Invalid ID.\nTry again\n");
                Console.Write($"Enter the ID of the client you would like to {action}: ");
                id = Console.ReadLine();
            }
            Client[] clients = FileHandler.LoadClients();
            for (int i = 0; i < clients.Length; i++)
            {
                if (id == clients[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Checks if there are no coaches in the "Coaches" folder 
        /// </summary>
        /// <returns>True if 'Coaches' folder is empty</returns>
        private static bool IsCoachesEmpty()
        {
            if (Directory.GetDirectories("Coaches").Length < 1)
            {
                Console.Clear();
                Console.WriteLine("There are no coaches in the system.\n");
                return true;
            }
            return false;
        }


        /// <summary>
        /// Checks if there are active coaches in the 'Coaches' folder
        /// </summary>
        /// <returns>True if 'Coaches' folder is empty or if all coaches are inactive</returns>
        private static bool IsCoachesEmptyOrInactive()
        {
            if (Directory.GetDirectories("Coaches").Length < 1)
            {
                Console.Clear();
                Console.WriteLine("There are no coaches in the system.\n");
                return true;
            }
            Coach[] coaches = FileHandler.LoadCoaches();
            for (int i = 0; i < coaches.Length; i++)
            {
                if (coaches[i].IsActive)
                {
                    return false;
                }
            }
            Console.Clear();
            Console.WriteLine("There are no active coaches in the system.\n");
            return true;
        }

        /// <summary>
        /// Searches the index of the coach in the coaches array 
        /// </summary>
        /// <param name="action">Edit/Delete</param>
        /// <returns>Index of coach in the coaches array</returns>
        private static int SearchCoachIndex(string action)
        {
            Console.Write($"Enter the ID of the coach you would like to {action}: ");
            string id = Console.ReadLine();
            while (!FileHandler.SearchCoach(id))
            {
                Console.Clear();
                Console.WriteLine("Invalid ID.\nTry again\n");
                Console.Write($"Enter the ID of the coach you would like to {action}: ");
                id = Console.ReadLine();
            }
            Coach[] coaches = FileHandler.LoadCoaches();
            for (int i = 0; i < coaches.Length; i++)
            {
                if (id == coaches[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

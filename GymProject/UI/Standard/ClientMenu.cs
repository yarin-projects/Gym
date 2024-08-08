using GymProject.Services.Inputs;
using GymProject.Services.Repository;
using GymProject.Services.Utils;
using System;
using System.IO;

namespace GymProject.UI.Standard
{
    internal class ClientMenu
    {
        private string _options;

        public void Start()
        {
            while (true)
            {
                Console.WriteLine(_options);
                int selectedOption = Input.GetIntInRange(1, 5, _options);
                Console.Clear();
                switch (selectedOption)
                {
                    case 1:
                        ManagementUtils.AddClient();
                        break;
                    case 2:
                        ManagementUtils.EditClient();
                        break;
                    case 3:
                        ManagementUtils.DeleteClient();
                        break;
                    case 4:
                        ManagementUtils.ListAllClients();
                        break;
                    case 5:
                        Console.Clear();
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.StartNormalMenu();
                        break;
                }
            }
        }
        public ClientMenu()
        {
            Directory.CreateDirectory("Clients");
            _options = ManagementRepo.ClientMenuOptions();
        }//sets value for options and creates 'Clients' folder if it doesn't exist
        
    }
}

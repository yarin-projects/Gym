using GymProject.Services.Inputs;
using GymProject.Services.Repository;
using GymProject.Services.Utils;
using System;
using System.IO;

namespace GymProject.UI.Standard
{
    internal class CoachMenu
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
                        ManagementUtils.AddCoach();
                        break;
                    case 2:
                        ManagementUtils.EditCoach();
                        break;
                    case 3:
                        ManagementUtils.DeleteCoach();
                        break;
                    case 4:
                        ManagementUtils.ListAllCoaches();
                        break;
                    case 5:
                        Console.Clear();
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.StartNormalMenu();
                        break;
                }
            }
        }
        public CoachMenu()
        {
            Directory.CreateDirectory("Coaches");
            _options = ManagementRepo.CoachMenuOptions();
        }//returns string of options for coach menu and creates 'Coaches' folder if it doesn't exist
        
    }
}

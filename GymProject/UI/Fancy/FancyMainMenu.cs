using GymProject.Services.Repository;
using GymProject.Services.Utils;
using System;

namespace GymProject.UI.Fancy
{
    class FancyMainMenu
    {
        private string[] _options;
        private string _title;
        private int _selectedIndex;
        public void Start()
        {
            while (true)
            {
                _selectedIndex = ConsoleUtils.MenuSelectedIndex(_title, _options, _selectedIndex);
                switch (_selectedIndex)
                {
                    case 0:
                        Console.Clear();
                        FancyClientMenu fancyClientMenu = new FancyClientMenu();
                        fancyClientMenu.Start();
                        break;
                    case 1:
                        Console.Clear();
                        FancyCoachMenu fancyCoachMenu = new FancyCoachMenu();
                        fancyCoachMenu.Start();
                        break;
                    case 2:
                        Console.Clear();
                        Console.CursorVisible = true;
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.StartProgram();
                        break;
                    case 3:
                        ConsoleUtils.ExitProgram();
                        break;
                }
            }
        }
        public FancyMainMenu()
        {
            _options = ManagementRepo.FancyMainMenuOptions();
            _title = ManagementRepo.FancyMainMenuTitle();
            _selectedIndex = 0;
        }//sets values for the class's fields 
    }
}

using GymProject.Services.Repository;
using GymProject.Services.Utils;
using System;
using System.IO;

namespace GymProject.UI.Fancy
{
    class FancyCoachMenu
    {
        public string[] Options { get; set; }
        public string Title { get; set; }
        public int SelectedIndex { get; set; }
        public void Start()
        {
            while (true)
            {
                Console.CursorVisible = false;
                SelectedIndex = ConsoleUtils.MenuSelectedIndex(Title, Options, SelectedIndex);
                Console.Clear();
                Console.CursorVisible = true;
                switch (SelectedIndex)
                {
                    case 0:
                        ManagementUtils.AddCoach();
                        Console.Clear();
                        break;
                    case 1:
                        ManagementUtils.FancyMenuEditCoach();
                        Console.Clear();
                        ResetPrompts();
                        break;
                    case 2:
                        ManagementUtils.DeleteCoach();
                        break;
                    case 3:
                        ManagementUtils.ListAllCoaches();
                        Console.Write("Press any key to go back to the coach menu...");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case 4:
                        Console.CursorVisible = false;
                        Console.Clear();
                        FancyMainMenu fancyMainMenu = new FancyMainMenu();
                        fancyMainMenu.Start();
                        break; 
                }
            }
        }
        public FancyCoachMenu()
        {
            Directory.CreateDirectory("Coaches");
            ResetPrompts();
            SelectedIndex = 0;
        }//sets values for the class's fields
        public void ResetPrompts()
        {
            Options = ManagementRepo.FancyCoachMenuOptions();
            Title = ManagementRepo.FancyCoachMenuTitle();
            SelectedIndex = 0;
        }
        public void EditPrompts()
        {
            Options = ManagementRepo.FancyCoachMenuEditOptions();
            SelectedIndex = 0;
        }
        public void ReactivatePrompts()
        {
            Options = ManagementRepo.FancyCoachMenuReactivateOptions();
            Title = ManagementRepo.FancyCoachMenuReactivateTitle();
            SelectedIndex = 0;
        }
    }
}

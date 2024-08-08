using GymProject.Services.Repository;
using GymProject.Services.Utils;
using System;
using System.IO;

namespace GymProject.UI.Fancy
{
    class FancyClientMenu
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
                        ManagementUtils.AddClient();
                        Console.Clear();
                        break;
                    case 1:
                        ManagementUtils.FancyMenuEditClient();
                        Console.Clear();
                        ResetPrompts();
                        break;
                    case 2:
                        ManagementUtils.DeleteClient();
                        break;
                    case 3:
                        ManagementUtils.ListAllClients();
                        Console.Write("Press any key to go back to the client menu...");
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
        public FancyClientMenu()
        {
            Directory.CreateDirectory("Clients");
            ResetPrompts();
        }
        public void ResetPrompts()
        {
            Options = ManagementRepo.FancyClientMenuOptions();
            Title = ManagementRepo.FancyClientMenuTitle();
            SelectedIndex = 0;
        }
        public void EditPrompts()
        {
            Options = ManagementRepo.FancyClientMenuEditOptions();
            SelectedIndex = 0;
        }
        public void ReactivatePrompts()
        {
            Options = ManagementRepo.FancyClientMenuReactivateOptions();
            Title = ManagementRepo.FancyClientMenuReactivateTitle();
            SelectedIndex = 0;
        }
        
    }
}

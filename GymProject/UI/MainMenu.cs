using GymProject.Services.Inputs;
using GymProject.Services.Repository;
using GymProject.Services.Utils;
using GymProject.UI.Fancy;
using GymProject.UI.Standard;
using System;

namespace GymProject.UI
{
    internal class MainMenu
    {
        public void StartProgram()
        {
            Console.Title = "Gym Management";
            string message = ManagementRepo.StartProgramOptions();
            while (true)
            {
                Console.WriteLine(message);
                int selectedOption = Input.GetIntInRange(1, 3, message);
                switch (selectedOption)
                {
                    case 1:
                        Console.Clear();
                        Console.CursorVisible = false;
                        FancyMainMenu fancyMainMenu = new FancyMainMenu();
                        fancyMainMenu.Start();
                        break;
                    case 2:
                        Console.Clear();
                        StartNormalMenu();
                        break;
                    case 3:
                        ConsoleUtils.ExitProgram();
                        break;
                }
            }
        }
        public void StartNormalMenu()
        {
            string message = ManagementRepo.StartNormalMenuOptions();
            while (true)
            {
                Console.WriteLine(message);
                int selectedOption = Input.GetIntInRange(1, 4, message);
                switch (selectedOption)
                {
                    case 1:
                        Console.Clear();
                        ClientMenu clientMenu = new ClientMenu();
                        clientMenu.Start();
                        break;
                    case 2:
                        Console.Clear();
                        CoachMenu coachtMenu = new CoachMenu();
                        coachtMenu.Start();
                        break;
                    case 3:
                        Console.Clear();
                        StartProgram();
                        break;
                    case 4:
                        ConsoleUtils.ExitProgram();
                        break;
                }
            }
        }
    }
}

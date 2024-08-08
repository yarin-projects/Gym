using System;

namespace GymProject.Services.Utils
{
    internal class ConsoleUtils
    {
        /// <summary>
        /// Prints title, options and highlights current index
        /// </summary>
        /// <param name="title"></param>
        /// <param name="options"></param>
        /// <param name="selectedIndex"></param>
        /// <param name="leftPosition"></param>
        /// <param name="topPosition"></param>
        public static void PrintOptions(string title, string[] options, int selectedIndex, int leftPosition = 0, int topPosition = 0)
        {
            Console.SetCursorPosition(leftPosition, topPosition);
            Console.WriteLine(title);
            for (int i = 0; i < options.Length; i++)
            {
                string prefix;
                if (selectedIndex == i)
                {
                    prefix = "> ";
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    prefix = "  ";
                }
                Console.WriteLine(prefix + options[i]);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Closes program
        /// </summary>
        public static void ExitProgram()
        {
            Console.WriteLine();
            Environment.Exit(0);
        }

        /// <summary>
        /// Prints title and options then lets the user navigate 
        /// with up/down arrow key and enter to select
        /// </summary>
        /// <param name="title">Menu title</param>
        /// <param name="options">Menu options</param>
        /// <param name="index">Highlighted row</param>
        /// <param name="upperLimit"></param>
        /// <param name="leftPosition"></param>
        /// <param name="topPosition"></param>
        /// <returns>Index of selected option</returns>
        public static int MenuSelectedIndex(string title, string[] options, int index, int leftPosition = 0, int topPosition = 0)
        {
            while (true)
            {
                ConsoleUtils.PrintOptions(title, options, index);
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                switch (keyPressed.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index == 0)
                            index = options.Length - 1;
                        else
                            index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index == options.Length - 1)
                            index = 0;
                        else
                            index++;
                        break;
                    case ConsoleKey.Enter:
                        return index;
                }
            }
        }

    }
}

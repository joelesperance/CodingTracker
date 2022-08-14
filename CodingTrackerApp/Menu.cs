using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTrackerApp
{
    public static class Menu
    {

        public static int MenuInput { get; set; }

        public static void OpenMenuPrompt()
        {
            Console.WriteLine(@"
[1] View All Records
[2] Enter New Record
[3] Update A Record
[4] Delete A Record
[5] Quit");
            UserInput.GetMenuInput();

            switch (MenuInput)
            {
                case 1:
                    Console.Clear();
                    DatabaseManager.Read();
                    break;
                case 2:
                    Console.Clear();
                    DatabaseManager.Create();
                    DatabaseManager.Read();
                    break;
                case 3:
                    Console.Clear();
                    DatabaseManager.Read();
                    DatabaseManager.Update();
                    DatabaseManager.Read();
                    break;
                case 4:
                    Console.Clear();
                    DatabaseManager.Read();
                    DatabaseManager.Delete();
                    DatabaseManager.Read();
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    UserInput.GetMenuInput();
                    break;
            }
            OpenReturnOrExitPrompt();
        }
        
        public static void OpenReturnOrExitPrompt()
        {
            Console.Write("\nReturn to Menu [1] || Quit Program [5]: ");
            UserInput.GetReturnOrExitInput();

            switch (MenuInput)
            {
                case 1:
                    Console.Clear();
                    OpenMenuPrompt();
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    OpenReturnOrExitPrompt();
                    break;
            }
        }
    }
}

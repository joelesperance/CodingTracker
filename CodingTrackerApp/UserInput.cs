using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTrackerApp
{
    public static class UserInput
    {
        public static string EntryInput { get; set; }

        public static int MenuInput { get; set; }



        public static void GetMenuInput()
        {
            EntryInput = Console.ReadLine();
            Validation.IdInputValidator();
            Menu.MenuInput = Validation.ValidId;
        }

        public static void GetCreateSartTimeInput()
        {
            Console.Write("Enter Start Time: ");
            EntryInput = Console.ReadLine();
            Validation.ValidateAndExecuteStartTimeInput();
        }
        public static void GetCreateEndTimeInput()
        {
            Console.Write("Enter End Time: ");
            EntryInput = Console.ReadLine();
            Validation.ValidateAndExecuteEndTimeInput();
        }
        
        public static void GetUpdateInput()
        {
            Console.Write("Select Record ID to Update: ");
            EntryInput = Console.ReadLine();
            Validation.IdInputValidator();
            CodingSession.Id = Validation.ValidId;
            Console.Write("Enter new Start Time: ");
            EntryInput = Console.ReadLine();
            Validation.ValidateAndExecuteStartTimeInput();
            Console.Write("Enter new End Time: ");
            EntryInput = Console.ReadLine();
            Validation.ValidateAndExecuteEndTimeInput();
        }
        
        public static void GetDeleteInput()
        {
            Console.Write("Select Record ID to Delete: ");
            EntryInput = Console.ReadLine();
            Validation.IdInputValidator();
            CodingSession.Id = Validation.ValidId;
        }

        public static void GetReturnOrExitInput()
        
        {
            EntryInput = Console.ReadLine();
            Validation.IdInputValidator();
            Menu.MenuInput = Validation.ValidId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTrackerApp
{
    public static class Validation
    {
        public static int ValidId { get; set; }

        public static void ValidateAndExecuteStartTimeInput()
        {
            bool isValid = TimeOnly.TryParse(UserInput.EntryInput, out TimeOnly time);
            if (isValid)
            {
                CodingSession.StartTime = time;

            }
            else
            {
                Console.WriteLine("Invalid Time");
                UserInput.GetCreateSartTimeInput();
            }
        }

        public static void ValidateAndExecuteEndTimeInput()
        {
            bool isValid = TimeOnly.TryParse(UserInput.EntryInput, out TimeOnly time);
            if (isValid)
            {
                CodingSession.EndTime = time;
            }
            else
            {
                Console.WriteLine("Invalid Time");
                UserInput.GetCreateEndTimeInput();
            }
        }

        public static void IdInputValidator()
        {
            bool isValid = Int32.TryParse(UserInput.EntryInput, out Int32 id);
            if (isValid)
            {
                ValidId = id;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Menu.OpenReturnOrExitPrompt();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTrackerApp
{
    internal class CodingSession
    {
        public static int Id { get; set; }
        public static TimeOnly StartTime { get; set; }
        public static TimeOnly EndTime { get; set; }
        public static TimeSpan Duration { get; set; }
    }
}

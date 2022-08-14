using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTrackerApp
{
    public static class Helper
    {
        public static string ConnectionStringValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static void DurationCalculator()
        {
            CodingSession.Duration = CodingSession.EndTime - CodingSession.StartTime;
        }
    }
}

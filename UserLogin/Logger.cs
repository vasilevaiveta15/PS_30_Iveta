using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        private static readonly List<string> Log = new();
        private const string LogFileName = "log.txt";

        public static void LogActivity(string activity)
        {
            var msg = DateTime.Now + " | " + LoginValidator.User.Username + " | " + LoginValidator.User.Role + " | " + activity;
            Log.Add(msg);
            StreamWriter log = new(LogFileName);
            log.WriteLine(msg);
            log.Close();
        }

        public static void ReadFullLog()
        {
            StreamReader log = new(LogFileName);
            StringBuilder sb = new();
            while (true)
            {
                var l = log.ReadLine();
                if (l != null) sb.AppendLine(l);
                else break;
            }
            Console.WriteLine(sb);
        }
        public static IEnumerable<string> GetActivities()
        {
            return File.ReadLines("Log.txt").ToList();
        }
        
        public static IEnumerable<string> GetCurrentSessionActivities(string? filter)
        {
            return (
                from activity 
                    in Log 
                where filter == null || activity.Contains(filter)
                select activity
            ).ToList();
        }
    }
}
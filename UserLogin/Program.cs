using System;
using System.Text;

namespace UserLogin
{
    internal static class Program
    {
        private static void ActionOnError(string errorMsg) {
            Console.WriteLine(errorMsg);
        }
            
        public static void Main(string[] args)
        {
            Console.WriteLine("Username:");
            var username = Console.ReadLine();
            Console.WriteLine("Username:");
            var password = Console.ReadLine();
            var loginValidator = new LoginValidator(username, password, ActionOnError);
            
            var user = new User();
            loginValidator.ValidateUserInput(ref user);
            Console.WriteLine(user);

            switch (LoginValidator.CurrentUserRole)
            {
                case UserRoles.Admin:
                {
                    DoAdmin();
                    break;
                }
                case UserRoles.Student:
                {
                    Console.WriteLine("Welcome, student!");
                    break;
                }
                case UserRoles.Inspector:
                {
                    Console.WriteLine("Welcome, inspector!");
                    break;
                }
                case UserRoles.Professor:
                {
                    Console.WriteLine("Welcome, professor!");
                    break;
                }
            }
        }

        private static void DoAdmin()
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Change user role");
                Console.WriteLine("2: Change user active date");
                Console.WriteLine("3: List users");
                Console.WriteLine("4: Print log file");
                Console.WriteLine("5: Print current log session");
                int value = Convert.ToInt16(Console.ReadLine());
                switch (value)
                {
                    case 0:
                        return;
                    case 1:
                        ChangeRole();
                        break;
                    case 2:
                        ChangeActiveDate();
                        break;
                    case 3:
                        UserData.ListUsers();
                        break;
                    case 4:
                        var sb = new StringBuilder();
                        foreach (var activity in Logger.GetActivities())
                            sb.Append(activity);
                        
                        Console.WriteLine(sb);
                        break;
                    case 5:
                        var sb2 = new StringBuilder();
                        foreach (var activity in Logger.GetCurrentSessionActivities(null))
                            sb2.Append(activity);
                        Console.WriteLine(sb2);
                        break;
                }
            }
        }

        private static void ChangeRole()
        {
            Console.WriteLine("Select username: ");
            var username = Console.ReadLine();
            var roles = new[] { UserRoles.Admin, UserRoles.Inspector, UserRoles.Professor, UserRoles.Student };
            for (var i = 0; i < roles.Length; i++)
                Console.WriteLine(i + ": " + roles[i]);
            Console.WriteLine("Select new role: ");
            var role = Convert.ToInt32(Console.ReadLine());
            UserData.AssignUserRole(username, roles[role]);
        }
        private static void ChangeActiveDate()
        {
            Console.WriteLine("Select username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Format: dd.MM.yyyy hh:mm:ss");
            Console.WriteLine("Type date: ");
            UserData.SetUserActiveTo(username, DateTime.Parse(Console.ReadLine()));
        }
    }
}
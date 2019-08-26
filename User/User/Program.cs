using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    class Program
    {
        static void Main()
        {
            //var users = new List<User>();
            //users.Add(GetUserFromConsole());
            var user = GetUserFromConsole();
            Console.WriteLine(user);
            Console.ReadKey();
        }
        static User GetUserFromConsole()
        {
            return new User(GetTextFromConsole(), GetTextFromConsole(), GetTextFromConsole(), GetDateTime());
        }
        static string GetTextFromConsole()
        {
            return Console.ReadLine();
        }
        static DateTime GetDateTime()
        {
            if (DateTime.TryParseExact(GetTextFromConsole(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            else
            {
                throw new ArgumentException("Incorrect dates format");
            }
        }
    }
}

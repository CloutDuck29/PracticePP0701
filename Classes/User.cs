using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practice
{
    // ИНФОРМАЦИЯ О ПОЛЬЗОВАТЕЛЕ
    public class User
    {
        string login;
        public string Login { get { return login; } set { login = value; } }

        string role;
        public string Role { get { return role; } set { role = value; } }

        string password;
        public string Password { get { return password; } set { password = value; } }

        public User(string login, string role)
        {
            Login = login;
            Role = role;
        }
    }
}

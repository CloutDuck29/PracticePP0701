using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    // Информация о пользователе
    public class User
    {
        string login;
        public string Login { get { return login; } set { login = value; } }
        string role;
        public string Role { get { return role; } set { role = value; } }
        public User(string login, string role)
        {
            Login = login;
            Role = role;
        }
    }
}

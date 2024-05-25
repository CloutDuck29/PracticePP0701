using Practice.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        string nameOfSchema = "dbo";
        // Model1 - имя подключения
        string connectionString = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
        public Authorization()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // (1) ПОЛУЧАЕМ СПИСОК ВСЕХ ПОЛЬЗОВАТЕЛЕЙ ИЗ БД
            List<User> listUsers = new List<User>();

            // процедура - список всех пользователей БД College с их ролями
            string cmdText = "EXEC sp_helpuser";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    SqlDataReader myreader;
                    connection.Open();
                    myreader = cmd.ExecuteReader();

                    while (myreader.Read())
                    {
                        //DefSchemaName - выбор тех пользователей, к-ые находятся в БД сollege
                        if (myreader["DefSchemaName"].ToString() == nameOfSchema)
                        {
                            listUsers.Add(new User(myreader["LoginName"].ToString(), myreader["RoleName"].ToString()));
                        }
                    }
                    myreader.Close();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "ОШИБКА");
                }
            }


            // (2) ПРОВЕРЯЕМ НАЛИЧИЕ ПОЛЬЗОВАТЕЛЯ В БД
            bool logic = false;
            User CurrentUser = new User("", ""); // вся информация о текущем пользователе

            foreach (User user in listUsers)
            {
                if (user.Login == CurrentLoginTextBox.Text)
                {
                    CurrentUser = user;
                    logic = true;
                    break;
                }
            }


            // если введенный логин найден
            if (logic)
            {
                // если введенный пароль к введённому логину найден
                CurrentUser.Password = new CollegeEntities().Users.First(l => l.Login == CurrentUser.Login).Password;   
                if (CurrentUser.Password == CurrentPasswordTextBox.Text)
                {
                    new Work(CurrentUser).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("У такого пользователя не тот пароль, что вы указали :(", "ОШИБКА");
                }
            }
            else
            {
                MessageBox.Show("Указанный пользователь не найден :(", "ОШИБКА");
            }
        }
    }
}

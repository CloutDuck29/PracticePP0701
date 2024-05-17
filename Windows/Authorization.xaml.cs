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
        string nameOfDatabase = "College";
        // Model1 - имя подключения
        string connectionString = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
        public Authorization()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // (1) ПОЛУЧАЕМ СПИСОК ВСЕХ ПОЛЬЗОВАТЕЛЕЙ
            List<User> listUsers = new List<User>();

            // список всех пользователей БД College с их ролями
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
                        if (myreader["DefDBName"].ToString() == nameOfDatabase)
                        {
                            listUsers.Add(new User(myreader["LoginName"].ToString(), myreader["RoleName"].ToString()));
                            MessageBox.Show(listUsers.Last().Login + " " + listUsers.Last().Role);
                        }
                        //myreader["UserName"].ToString();
                        //myreader.GetString(0);
                    }
                    myreader.Close();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("УСПЕШНО ПОЛУЧЕН СПИСОК ПОЛЬЗОВАТЕЛЕЙ", "УСПЕХ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "ОШИБКА");
                }
            }


            // (2) ПРОВЕРЯЕМ НАЛИЧИЕ ПОЛЬЗОВАТЕЛЯ В БД
            bool logic = false;
            User CurrentUser = new User("", ""); // вся информация о текущем пользователе
            string CurrentPassword = CurrentPasswordTextBox.Text;

            foreach (User user in listUsers)
            {
                if (user.Login == CurrentLoginTextBox.Text) // из переменной user надо вычленить логин
                {
                    CurrentUser = user;
                    logic = true;
                    break;
                }
            }

            logic = true; // !!! ЗАГЛУШКА, ЧТОБЫ МОЖНО БЫЛО ПЕРЕХОДИТЬ НА ДРУГИЕ ОКНА !!!

            if (logic)
            {
                new Work(CurrentUser).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ОШИБКА", "Указанный пользователь не найден :(");
            }
        }
    }
}

using Practice.Pages;
using System;
using System.Collections.Generic;
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
    public partial class Work : Window
    {
        User CurrentUser; // текущий пользователь
        Rules CurrentRules; // права текущего пользователя


        public Work(User currentUser)
        {
            CurrentUser = currentUser;
            CurrentRules = new Rules(CurrentUser.Role);
            InitializeComponent();
            // связь между правами пользователя и отображаемыми элементами интерфейса при инициализации приложения
            if (CurrentRules != null) 
            {
                if (CurrentRules.GradesTableSee)
                {
                    (GradesTableButton.Parent as Border).Visibility = Visibility.Visible;
                }
                if(CurrentRules.StudentsTableSee) {
                    (StudentsTableButton.Parent as Border).Visibility = Visibility.Visible;
                }
            }
        }

        // отображение выбранной таблицы и замена названия текущей таблицы в метке
        private void ShowTable(string pageUrl, string nameOfPage)
        {
            CurrentData.NavigationService.Navigate(new Uri(pageUrl, UriKind.Relative));
            NameOfCurrentTable.Text = nameOfPage;
        }
        private void StudentsTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTable("Pages/StudentsData.xaml", "Студенты");
        }
        private void GradesTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTable("Pages/GradesData.xaml", "Оценки");
        }
    }
}

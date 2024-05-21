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
    /// <summary>
    /// Логика взаимодействия для Work.xaml
    /// </summary>
    public partial class Work : Window
    {
        User CurrentUser; // вся информация о текущем пользователе
        Rules rules;
        public Work(User currentUser)
        {
            CurrentUser = currentUser;
            rules = new Rules(CurrentUser.Role);
            InitializeComponent();
            if (rules != null) {
                if (rules.GradesTableSee)
                {
                    (GradesTableButton.Parent as Border).Visibility = Visibility.Visible;
                }
                if(rules.StudentsTableSee) {
                    (StudentsTableButton.Parent as Border).Visibility = Visibility.Visible;
                }
            }
            
        }

        private void StudentsTableButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentData.NavigationService.Navigate(new Uri("Pages/StudentsData.xaml", UriKind.Relative));
            NameOfCurrentTable.Text = "Студенты";
        }

        private void GradesTableButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentData.NavigationService.Navigate(new Uri("Pages/GradesData.xaml", UriKind.Relative));
            NameOfCurrentTable.Text = "Оценки";
        }
    }
}

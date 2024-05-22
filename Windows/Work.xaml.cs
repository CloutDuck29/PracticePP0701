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
            TypeOfAccount.Text = currentUser.Role;
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

                if (CurrentRules.TeachersTableSee)
                {
                    (TeachersTableButton.Parent as Border).Visibility = Visibility.Visible;
                }

                if (CurrentRules.GroupsTableSee)
                {
                    (GroupsTableButton.Parent as Border).Visibility = Visibility.Visible;
                }

                if (CurrentRules.StudentsTableSee)
                {
                    (StudentsTableButton.Parent as Border).Visibility = Visibility.Visible;
                }

                if (CurrentRules.RUPTableSee)
                {
                    (RUPTableButton.Parent as Border).Visibility = Visibility.Visible;
                }

                if (CurrentRules.DisciplinesTableSee)
                {
                    (DisciplinesTableButton.Parent as Border).Visibility = Visibility.Visible;
                }

                if (CurrentRules.SpecialitiesTableSee)
                {
                    (SpecialitiesTableButton.Parent as Border).Visibility = Visibility.Visible;
                }
            }

        }

        // отображение выбранной таблицы и замена названия текущей таблицы в метке
        private void ShowTable(object page, string nameOfPage)
        {
            CurrentData.Navigate(page);
            NameOfCurrentTable.Text = nameOfPage;
        }
        private void StudentsTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTable(new StudentsData(), "Студенты");
        }
        private void GradesTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTable(new GradesData(), "Оценки");
        }

        private void TeachersTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTable(new TeachersData(), "Преподы");
        }

        private void AVGStudentsScoreTableButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DisciplinesTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTable(new DisciplinesData(), "Дисциплины");
        }

        private void GroupsTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTable(new GroupData(), "Группы");
        }

        private void LeaveStudentsTableButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RUPTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTable(new RUPData(), "РУПЫ");
        }

        private void SpecialitiesTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowTable(new SpecialitiesData(), "Специальности");
        }
    }
}

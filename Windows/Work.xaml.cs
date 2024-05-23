using Practice.Classes;
using Practice.Database;
using Practice.Pages;
using Practice.Pages.View;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
            Elements.NameOfCurrentPage = NameOfCurrentPage;
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

                if (CurrentRules.AVGStudentScoresTableSee)
                {
                    (AVGStudentsScoreTableButton.Parent as Border).Visibility = Visibility.Visible;
                }

                if (CurrentRules.LeaveStudentsTableSee)
                {
                    (LeaveStudentsTableButton.Parent as Border).Visibility = Visibility.Visible;
                }
            }
        }

        // отображение выбранной таблицы и замена названия текущей таблицы в метке
        private void ShowPage(object page, string nameOfPage)
        {
            CurrentData.Navigate(page);
            NameOfCurrentPage.Text = nameOfPage;
        }

        private void StudentsTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new StudentsData(), "Таблица студенты");
        }
        private void GradesTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new GradesData(), "Таблица оценки");
        }

        private void TeachersTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new TeachersData(), "Таблица преподы");
        }

        private void AVGStudentsScoreTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new AVGStudentScoreData(), "Таблица средний балл");
        }

        private void DisciplinesTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new DisciplinesData(), "Таблица дисциплины");
        }

        private void GroupsTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new GroupData(), "Таблица группы");
        }

        private void LeaveStudentsTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new LeaveStudentsData(), "Таблица отчисленные");
        }

        private void RUPTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new RUPData(), "Таблица РУПЫ");
        }

        private void SpecialitiesTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new SpecialitiesData(), "Таблица специальности");
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameOfCurrentPage.Text == "Таблица специальности" && Elements.SpecialitiesDataGrid.SelectedItem != null)
            {
                ShowPage(new SpecialitiesEdit(Elements.SpecialitiesDataGrid.SelectedItem), "Редактирование специальности");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new SpecialitiesEdit(), "Добавление специальности");
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameOfCurrentPage.Text == "Таблица специальности" && Elements.SpecialitiesDataGrid.SelectedItem != null && (MessageBoxResult)MessageBox.Show("Вы уверены что хотите удалить запись?", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (var context = CollegeEntities.GetContext())
                {
                    context.Specialities.Remove(context.Specialities.First(x => x.id == ((Specialities)Elements.SpecialitiesDataGrid.SelectedItem).id));
                    context.SaveChanges();
                }
                Elements.SpecialitiesDataGrid.ItemsSource = new CollegeEntities().Specialities.ToList();
            }
        }
    }
}

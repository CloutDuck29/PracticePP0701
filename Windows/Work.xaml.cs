using Practice.Classes;
using Practice.Database;
using Practice.Pages;
using Practice.Pages.Edit;
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
        // просмотр
        private void StudentsTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new StudentsData(), "Таблица студенты");
            ActionsButtons.Visibility = Visibility.Collapsed;
        }
        private void GradesTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new GradesData(), "Таблица оценки");
            if (CurrentRules.GradesTableEdit)
            {
                ActionsButtons.Visibility = Visibility.Visible;
            }
            else
            {
                ActionsButtons.Visibility = Visibility.Collapsed;
            }
        }
        private void TeachersTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new TeachersData(), "Таблица преподы");
            ActionsButtons.Visibility = Visibility.Collapsed;
        }
        private void AVGStudentsScoreTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new AVGStudentScoreData(), "Таблица средний балл");
            ActionsButtons.Visibility = Visibility.Collapsed;
        }
        private void DisciplinesTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new DisciplinesData(), "Таблица дисциплины");
            if (CurrentRules.DisciplinesTableEdit)
            {
                ActionsButtons.Visibility = Visibility.Visible;
            }
            else
            {
                ActionsButtons.Visibility = Visibility.Collapsed;
            }
        }
        private void GroupsTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new GroupData(), "Таблица группы");
            if (CurrentRules.GroupsTableEdit)
            {
                ActionsButtons.Visibility = Visibility.Visible;
            }
            else
            {
                ActionsButtons.Visibility = Visibility.Collapsed;
            }
        }
        private void LeaveStudentsTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new LeaveStudentsData(), "Таблица отчисленные");
            ActionsButtons.Visibility = Visibility.Collapsed;
        }
        private void RUPTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new RUPData(), "Таблица РУПЫ");
            if (CurrentRules.RUPTableEdit)
            {
                ActionsButtons.Visibility = Visibility.Visible;
            }
            else
            {
                ActionsButtons.Visibility = Visibility.Collapsed;
            }
        }
        private void SpecialitiesTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new SpecialitiesData(), "Таблица специальности");
            if (CurrentRules.SpecialitiesTableEdit)
            {
                ActionsButtons.Visibility = Visibility.Visible;
            }
            else
            {
                ActionsButtons.Visibility = Visibility.Collapsed;
            }
        }
        // редактирование
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameOfCurrentPage.Text == "Таблица специальности" && Elements.SpecialitiesDataGrid.SelectedItem != null)
            {
                ShowPage(new SpecialitiesEdit(Elements.SpecialitiesDataGrid.SelectedItem), "Редактирование специальности");
            }
            else if (NameOfCurrentPage.Text == "Таблица группы" && Elements.GroupsDataGrid.SelectedItem != null)
            {
                ShowPage(new GroupsEdit(Elements.GroupsDataGrid.SelectedItem), "Редактирование группы");
            }
            else if (NameOfCurrentPage.Text == "Таблица оценки" && Elements.GradesDataGrid.SelectedItem != null)
            {
                ShowPage(new GradesEdit(Elements.GradesDataGrid.SelectedItem), "Редактирование оценки");
            }
            else if (NameOfCurrentPage.Text == "Таблица РУПЫ" && Elements.RUPDataGrid.SelectedItem != null)
            {
                ShowPage(new RUPEdit(Elements.RUPDataGrid.SelectedItem), "Редактирование РУПА");
            }
        }
        // добавление
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameOfCurrentPage.Text == "Таблица специальности")
            {
                ShowPage(new SpecialitiesEdit(), "Добавление специальности");
            }
            else if (NameOfCurrentPage.Text == "Таблица группы")
            {
                ShowPage(new GroupsEdit(), "Добавление группы");
            }
            else if (NameOfCurrentPage.Text == "Таблица оценки")
            {
                ShowPage(new GradesEdit(), "Добавление оценки");
            }
            else if (NameOfCurrentPage.Text == "Таблица РУПЫ")
            {
                ShowPage(new RUPEdit(), "Добавление РУПА");
            }
        }
        // удаление
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

            else if (NameOfCurrentPage.Text == "Таблица группы" && Elements.GroupsDataGrid.SelectedItem != null && (MessageBoxResult)MessageBox.Show("Вы уверены что хотите удалить запись?", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (var context = CollegeEntities.GetContext())
                {
                    context.Groups.Remove(context.Groups.First(x => x.id == ((Groups)Elements.GroupsDataGrid.SelectedItem).id));
                    context.SaveChanges();
                }
                Elements.GroupsDataGrid.ItemsSource = new CollegeEntities().Groups.ToList();
            }

            else if (NameOfCurrentPage.Text == "Таблица оценки" && Elements.GradesDataGrid.SelectedItem != null && (MessageBoxResult)MessageBox.Show("Вы уверены что хотите удалить запись?", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (var context = CollegeEntities.GetContext())
                {
                    context.Grades.Remove(context.Grades.First(x => x.id == ((Grades)Elements.GradesDataGrid.SelectedItem).id));
                    context.SaveChanges();
                }
                Elements.GradesDataGrid.ItemsSource = new CollegeEntities().Grades.ToList();
            }

            else if (NameOfCurrentPage.Text == "Таблица РУПЫ" && Elements.RUPDataGrid.SelectedItem != null && (MessageBoxResult)MessageBox.Show("Вы уверены что хотите удалить запись?", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (var context = CollegeEntities.GetContext())
                {
                    context.RUP.Remove(context.RUP.First(x => x.id == ((RUP)Elements.RUPDataGrid.SelectedItem).id));
                    context.SaveChanges();
                }
                Elements.RUPDataGrid.ItemsSource = new CollegeEntities().RUP.ToList();
            }

        }
    }
}

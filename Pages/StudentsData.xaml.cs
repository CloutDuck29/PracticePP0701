using Practice.Database;
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

namespace Practice.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentsData.xaml
    /// </summary>
    public partial class StudentsData : Page
    {
        CollegeEntities db = new CollegeEntities();

        public StudentsData()
        {
            InitializeComponent();
            StudentsDataGrid.ItemsSource = db.Students.ToList();
            GroupComboBox.ItemsSource = db.Students.ToList().Select(x => x.Groups.Name).Distinct();
        }


        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            if (GroupComboBox.SelectedItem == null && FIOTextBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали ничего для фильтрации", "Ошибка");
            }
            else if (FIOTextBox.Text == "")
            {
                StudentsDataGrid.ItemsSource = db.Students.ToList().Where(x => x.Groups.Name == Convert.ToString(GroupComboBox.SelectedItem));
                MessageBox.Show("Поиск проводится только по группе", "Оповещение");
            }
            else if (GroupComboBox.SelectedItem == null)
            {
                StudentsDataGrid.ItemsSource = db.Students.ToList().Where(x => x.FIO == FIOTextBox.Text);
                MessageBox.Show("Поиск проводится только по группам", "Оповещение");
            }
            else
            {
                StudentsDataGrid.ItemsSource = db.Students.ToList().Where(x => x.FIO == FIOTextBox.Text && x.Groups.Name == Convert.ToString(GroupComboBox.SelectedItem));
                MessageBox.Show("Поиск проводится по специальности и группам", "Оповещение");
            }
        }
    }
}

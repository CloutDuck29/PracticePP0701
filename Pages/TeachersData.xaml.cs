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
    public partial class TeachersData : Page
    {
        CollegeEntities db = new CollegeEntities();
        public TeachersData()
        {
            InitializeComponent();
            TeachersDataGrid.ItemsSource = db.Teachers.ToList();
            CategoryComboBox.ItemsSource = db.Teachers.ToList().Select(x => x.Category).Distinct();
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem == null && FIOTextBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали ничего для фильтрации", "Ошибка");
            }
            else if (FIOTextBox.Text == "")
            {
                TeachersDataGrid.ItemsSource = db.Teachers.ToList().Where(x => x.Category == Convert.ToString(CategoryComboBox.SelectedItem));
                MessageBox.Show("Поиск проводится только по категории", "Оповещение");
            }
            else if (CategoryComboBox.SelectedItem == null)
            {
                TeachersDataGrid.ItemsSource = db.Teachers.ToList().Where(x => x.FIO == FIOTextBox.Text);
                MessageBox.Show("Поиск проводится только по ФИО", "Оповещение");
            }
            else
            {
                TeachersDataGrid.ItemsSource = db.Teachers.ToList().Where(x => x.FIO == FIOTextBox.Text && x.Category == Convert.ToString(CategoryComboBox.SelectedItem));
                MessageBox.Show("Поиск проводится по категории и ФИО", "Оповещение");
            }
        }
    }
}

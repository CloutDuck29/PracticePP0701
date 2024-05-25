using Practice.Classes;
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

namespace Practice.Pages.View
{
    public partial class GroupData : Page
    {
        CollegeEntities db = new CollegeEntities();
        public GroupData()
        {
            InitializeComponent();
            GroupsDataGrid.ItemsSource = db.Groups.ToList();
            SpecialityComboBox.ItemsSource = db.Groups.ToList().Select(x => x.Specialities).Distinct();
            Elements.GroupsDataGrid = GroupsDataGrid;
            
        }

        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialityComboBox.SelectedItem == null && GroupTextBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали ничего для фильтрации", "Ошибка");
            }
            else if (GroupTextBox.Text == "")
            {
                GroupsDataGrid.ItemsSource = db.Groups.ToList().Where(x => x.Specialities.Name == ((Specialities)SpecialityComboBox.SelectedItem).Name);
                MessageBox.Show("Поиск проводится только по cпециальности", "Оповещение");
            }
            else if (SpecialityComboBox.SelectedItem == null)
            {
                GroupsDataGrid.ItemsSource = db.Groups.ToList().Where(x => x.Name == GroupTextBox.Text);
                MessageBox.Show("Поиск проводится только по группам", "Оповещение");
            }
            else
            {
                GroupsDataGrid.ItemsSource = db.Groups.ToList().Where(x => x.Name == GroupTextBox.Text && x.Specialities.Name == ((Specialities)SpecialityComboBox.SelectedItem).Name);
                MessageBox.Show("Поиск проводится по специальности и группам", "Оповещение");
            }
        }
    }
}

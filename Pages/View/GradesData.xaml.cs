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
    /// <summary>
    /// Логика взаимодействия для GradesData.xaml
    /// </summary>
    public partial class GradesData : Page
    {
        CollegeEntities db = new CollegeEntities();
        public GradesData()
        {
            InitializeComponent();
            GradesDataGrid.ItemsSource = db.Grades.ToList();

            ValueGradeComboBox.ItemsSource = db.Grades.ToList().Select(x => x.ValueGrade).Distinct();
        }


        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValueGradeComboBox.SelectedItem == null && FIOTextBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали ничего для фильтрации", "Ошибка");
            }
            else if (FIOTextBox.Text == "")
            {
                GradesDataGrid.ItemsSource = db.Grades.ToList().Where(x => x.ValueGrade == Convert.ToByte(ValueGradeComboBox.SelectedItem));
                MessageBox.Show("Поиск проводится только по оценкам", "Оповещение");
            }
            else if (ValueGradeComboBox.SelectedItem == null)
            {
                GradesDataGrid.ItemsSource = db.Grades.ToList().Where(x => x.Students.FIO == FIOTextBox.Text);
                MessageBox.Show("Поиск проводится только по ФИО", "Оповещение");
            }
            else
            {
                GradesDataGrid.ItemsSource = db.Grades.ToList().Where(x => x.Students.FIO == FIOTextBox.Text && x.ValueGrade == Convert.ToByte(ValueGradeComboBox.SelectedItem));
                MessageBox.Show("Поиск проводится по оценкам и ФИО", "Оповещение");
            }
        }
    }
}

using Practice.Classes;
using Practice.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Practice.Pages.Edit
{
    public partial class GradesEdit : Page
    {
        Grades Row; // выбранная строка

        public GradesEdit(object row) // конструктор, если мы РЕДАКТИРУЕМ строку
        {
            InitializeComponent();
            Row = (Grades)row;
    
            StudentComboBox.ItemsSource = new CollegeEntities().Students.ToList().Distinct();
            RUPComboBox.ItemsSource = new CollegeEntities().RUP.ToList().Distinct();
            GradesComboBox.ItemsSource = new CollegeEntities().Grades.ToList().Select(x => x.ValueGrade).Distinct();
            // заполнение полей ввода данными выбранной строки
            StudentComboBox.SelectedItem = StudentComboBox.Items.Cast<Students>().First(item => item.FIO == Row.Students.FIO);
            RUPComboBox.SelectedItem = RUPComboBox.Items.Cast<RUP>().First(item => item.id == Row.RupID);
            DataDatePicker.SelectedDate = Row.Date;

        }
        public GradesEdit() // конструктор, если мы ДОБАВЛЯЕМ строку
        {
            InitializeComponent();
            StudentComboBox.ItemsSource = new CollegeEntities().Students.ToList().Distinct();
            RUPComboBox.ItemsSource = new CollegeEntities().RUP.ToList().Distinct();
            GradesComboBox.ItemsSource = new CollegeEntities().Grades.ToList().Select(x => x.ValueGrade).Distinct();
        }

        private void ConfirmActionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // проверка на вводимые значения
                Errors.CheckIsEmpty(StudentComboBox, RUPComboBox, GradesComboBox, DataDatePicker);
                // проверка на текущее окно/режим редактирования или добавления
                if (Elements.NameOfCurrentPage.Text == "Добавление оценки")
                {
                    
                    MessageBox.Show(GradesComboBox.SelectedItem.ToString());
                    
                    var grade = new Grades()
                    {
                        StudentID = ((Students)StudentComboBox.SelectedItem).id,
                        Date = (DateTime)DataDatePicker.SelectedDate,
                        RupID = ((RUP)RUPComboBox.SelectedItem).id,
                        ValueGrade = Convert.ToByte(GradesComboBox.SelectedItem),
                    };

                    using (var context = CollegeEntities.GetContext())
                    {
                        context.Grades.Add(grade);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно добавлены", "УСПЕХ");
                }
                else
                {
                    using (var context = CollegeEntities.GetContext())
                    {
                        context.Grades.First(x => x.id == Row.id).StudentID = ((Students)StudentComboBox.SelectedItem).id;
                        context.Grades.First(x => x.id == Row.id).Date = (DateTime)DataDatePicker.SelectedDate;
                        context.Grades.First(x => x.id == Row.id).RupID = ((RUP)RUPComboBox.SelectedItem).id;
                        context.Grades.First(x => x.id == Row.id).ValueGrade = Convert.ToByte(GradesComboBox.SelectedItem);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно отредактированы", "УСПЕХ");
                }
            }
            catch
            {
            }
        }
    }
}
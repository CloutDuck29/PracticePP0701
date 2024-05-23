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

namespace Practice.Pages
{
    public partial class SpecialitiesEdit : Page
    {
        Specialities Row; // выбранная строка

        public SpecialitiesEdit(object row) // конструктор, если мы РЕДАКТИРУЕМ строку
        {
            InitializeComponent();
            NameTextBox.Text = ((Specialities)row).Name;
            Row = (Specialities)row;
        }
        public SpecialitiesEdit() // конструктор, если мы ДОБАВЛЯЕМ строку
        {
            InitializeComponent();
        }

        private void ConfirmActionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // проверка на вводимые значения
                Errors.CheckIsEmpty(NameTextBox);
                // проверка на текущее окно/режим редактирования или добавления
                if (Elements.NameOfCurrentPage.Text == "Добавление специальности")
                {
                    var speciality = new Specialities()
                    {
                        Name = NameTextBox.Text,
                    };

                    using (var context = CollegeEntities.GetContext())
                    {
                        context.Specialities.Add(speciality);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно добавлены", "УСПЕХ");
                }
                else
                {
                    using (var context = CollegeEntities.GetContext())
                    {
                        context.Specialities.First(x => x.id == Row.id).Name = NameTextBox.Text;
                        context.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно отредактированы", "УСПЕХ");
                }
            }
            catch { }
        }
    }
}
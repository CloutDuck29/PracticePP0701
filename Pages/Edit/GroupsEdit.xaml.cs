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
    public partial class GroupsEdit : Page
    {
        Groups Row; // выбранная строка

        public GroupsEdit(object row) // конструктор, если мы РЕДАКТИРУЕМ строку
        {
            InitializeComponent();
            Row = (Groups)row;
            NameTextBox.Text = Row.Name;
            SpecialityComboBox.ItemsSource = new CollegeEntities().Specialities.ToList().Distinct();
            SpecialityComboBox.SelectedItem = SpecialityComboBox.Items.Cast<Specialities>().First(item => item.id == Row.SpecialityID);
        }
        public GroupsEdit() // конструктор, если мы ДОБАВЛЯЕМ строку
        {
            InitializeComponent();
            SpecialityComboBox.ItemsSource = new CollegeEntities().Specialities.ToList().Distinct();
        }

        private void ConfirmActionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // проверка на вводимые значения
                Errors.CheckIsEmpty(NameTextBox, SpecialityComboBox);
                // проверка на текущее окно/режим редактирования или добавления
                if (Elements.NameOfCurrentPage.Text == "Добавление группы")
                {
                    var group = new Groups()
                    {
                        Name = NameTextBox.Text,
                        SpecialityID = ((Specialities)SpecialityComboBox.SelectedItem).id,
                    };

                    using (var context = CollegeEntities.GetContext())
                    {
                        context.Groups.Add(group);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно добавлены", "УСПЕХ");
                }
                else
                {
                    using (var context = CollegeEntities.GetContext())
                    {
                        context.Groups.First(x => x.id == Row.id).Name = NameTextBox.Text;
                        context.Groups.First(x => x.id == Row.id).SpecialityID = ((Specialities)SpecialityComboBox.SelectedItem).id;
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
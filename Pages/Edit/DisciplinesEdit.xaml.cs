using Practice.Classes;
using Practice.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    public partial class DisciplinesEdit : Page
    {
        Disciplines Row; // выбранная строка

        public DisciplinesEdit(object row) // конструктор, если мы РЕДАКТИРУЕМ строку
        {
            InitializeComponent();
            Row = (Disciplines)row;
            NameTextBox.Text = ((Disciplines)row).Name;
            HoursTextBox.Text = Convert.ToString(((Disciplines)row).Hours);
        }
        public DisciplinesEdit() // конструктор, если мы ДОБАВЛЯЕМ строку
        {
            InitializeComponent();
        }

        private void ConfirmActionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // проверка на вводимые значения
                Errors.CheckIsEmpty(NameTextBox);
                Errors.IsNatural(HoursTextBox);
                // проверка на текущее окно/режим редактирования или добавления
                if (Elements.NameOfCurrentPage.Text == "Добавление дисциплины")
                {
                    var discipline = new Disciplines()
                    {
                        Name = NameTextBox.Text,
                        Hours = Convert.ToInt16(HoursTextBox.Text),
                    };

                    using (var context = CollegeEntities.GetContext())
                    {
                        context.Disciplines.Add(discipline);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно добавлены", "УСПЕХ");
                }
                else
                {
                    using (var context = CollegeEntities.GetContext())
                    {
                        context.Disciplines.First(x => x.id == Row.id).Name = NameTextBox.Text;
                        context.Disciplines.First(x => x.id == Row.id).Hours = Convert.ToInt16(HoursTextBox.Text);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно отредактированы", "УСПЕХ");
                }
            }
            catch { }
        }
    }
}
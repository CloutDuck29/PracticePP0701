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
    public partial class RUPEdit : Page
    {
        RUP Row; // выбранная строка

        public RUPEdit(object row) // конструктор, если мы РЕДАКТИРУЕМ строку
        {
            InitializeComponent();
            Row = (RUP)row;
            DisciplineComboBox.ItemsSource = new CollegeEntities().Disciplines.ToList().Distinct();
            DisciplineComboBox.SelectedItem = DisciplineComboBox.Items.Cast<Disciplines>().First(item => item.id == Row.DisciplineID);
            SemestrComboBox.ItemsSource = new CollegeEntities().RUP.ToList().Select(x => x.Semestr).Distinct();
            TypeOfAttestationComboBox.ItemsSource = new CollegeEntities().RUP.ToList().Select(x => x.TypeOfAttestation).Distinct();
            TeacherComboBox.ItemsSource = new CollegeEntities().Teachers.ToList().Distinct();
            TeacherComboBox.SelectedItem = TeacherComboBox.Items.Cast<Teachers>().First(item => item.FIO == Row.Teachers.FIO);
        }
        public RUPEdit() // конструктор, если мы ДОБАВЛЯЕМ строку
        {
            InitializeComponent();
            DisciplineComboBox.ItemsSource = new CollegeEntities().Disciplines.ToList().Distinct();
            SemestrComboBox.ItemsSource = new CollegeEntities().RUP.ToList().Select(x => x.Semestr).Distinct();
            TeacherComboBox.ItemsSource = new CollegeEntities().Teachers.ToList().Distinct();
            TypeOfAttestationComboBox.ItemsSource = new CollegeEntities().RUP.ToList().Select(x => x.TypeOfAttestation).Distinct();
        }

        private void ConfirmActionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // проверка на вводимые значения
                Errors.CheckIsEmpty(DisciplineComboBox, SemestrComboBox, TypeOfAttestationComboBox, TeacherComboBox);
                // проверка на текущее окно/режим редактирования или добавления
                if (Elements.NameOfCurrentPage.Text == "Добавление РУПА")
                {
                    var rup = new RUP()
                    {
                        DisciplineID = ((Disciplines)DisciplineComboBox.SelectedItem).id,
                        Semestr = Convert.ToInt32(SemestrComboBox.SelectedItem),
                        TypeOfAttestation = Convert.ToString(TypeOfAttestationComboBox.SelectedItem),
                        TeacherID = ((Teachers)TeacherComboBox.SelectedItem).id,
                    };

                    using (var context = CollegeEntities.GetContext())
                    {
                        context.RUP.Add(rup);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно добавлены", "УСПЕХ");
                }
                else
                {
                    using (var context = CollegeEntities.GetContext())
                    {
                        context.RUP.First(x => x.id == Row.id).DisciplineID = ((Disciplines)DisciplineComboBox.SelectedItem).id;
                        context.RUP.First(x => x.id == Row.id).Semestr = Convert.ToInt32(SemestrComboBox.SelectedItem);
                        context.RUP.First(x => x.id == Row.id).TypeOfAttestation = Convert.ToString(TypeOfAttestationComboBox.SelectedItem);
                        context.RUP.First(x => x.id == Row.id).TeacherID = ((Teachers)TeacherComboBox.SelectedItem).id;

                        context.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно отредактированы", "УСПЕХ");
                }
            }
            catch { }
        }
    }
}
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

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

                if (CurrentRules.StudentsTableSee)
                {
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
            if (NameOfCurrentPage.Text == "Таблица специальности" && Elements.SpecialitiesDataGrid.SelectedItem != null)
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
            else if (NameOfCurrentPage.Text == "Таблица дисциплины" && Elements.DisciplinesDataGrid.SelectedItem != null)
            {
                ShowPage(new DisciplinesEdit(Elements.DisciplinesDataGrid.SelectedItem), "Редактирование дисциплины");
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
            else if (NameOfCurrentPage.Text == "Таблица дисциплины")
            {
                ShowPage(new DisciplinesEdit(), "Добавление дисциплины");
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

            else if (NameOfCurrentPage.Text == "Таблица дисциплины" && Elements.DisciplinesDataGrid.SelectedItem != null && (MessageBoxResult)MessageBox.Show("Вы уверены что хотите удалить запись?", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (var context = CollegeEntities.GetContext())
                {
                    context.Disciplines.Remove(context.Disciplines.First(x => x.id == ((Disciplines)Elements.DisciplinesDataGrid.SelectedItem).id));
                    context.SaveChanges();
                }
                Elements.DisciplinesDataGrid.ItemsSource = new CollegeEntities().Disciplines.ToList();
            }

        }
        // отчёт
        private void CreateOtchetButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = CollegeEntities.GetContext())
            {
                // ПАРАМЕТРЫ
                string pathToFont = @"C:\Users\Alex\Desktop\ArialUni.ttf";
                int titleSize = 24;

                // НАЧАЛО СОЗДАНИЯ ОТЧЁТОВ
                var data1 = context.DvoechinikiVRazrezeGrupIDisciplin.ToList();
                var data2 = context.SpisokStudentovVRazrezeGroup.ToList();
                var data3 = context.UchebnayaNagruzka.ToList();
                var data4 = context.VedomostOcenokStudentovVRazrezeGrupIDisciplin.ToList();

                // указание шрифта
                BaseFont bf = BaseFont.CreateFont(pathToFont, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(bf, titleSize - 14);

                // отчёт 1
                using (var stream = new FileStream("Двоечники.pdf", FileMode.Create))
                {
                    using (var document = new Document())
                    {
                        using (var writer = PdfWriter.GetInstance(document, stream))
                        {
                            document.Open();
                            // добавление заголовка
                            document.Add(new iTextSharp.text.Paragraph("Двоечники в разрезе групп и дисциплин", new Font(bf, titleSize)));
                            // добавление таблицы

                            PdfPTable table = new PdfPTable(5);
                            // заголовок таблицы
                            table.AddCell(new PdfPCell(new Phrase("GroupName", font)));
                            table.AddCell(new PdfPCell(new Phrase("Name", font)));
                            table.AddCell(new PdfPCell(new Phrase("FIO", font)));
                            table.AddCell(new PdfPCell(new Phrase("Date", font)));
                            table.AddCell(new PdfPCell(new Phrase("ValueGrade", font)));

                            // тело таблицы
                            foreach (var row in data1)
                            {
                                table.AddCell(new PdfPCell(new Phrase(row.GroupName, font)));
                                table.AddCell(new PdfPCell(new Phrase(row.Name, font)));
                                table.AddCell(new PdfPCell(new Phrase(row.FIO, font)));
                                table.AddCell(new PdfPCell(new Phrase(row.Date.ToString(), font)));
                                table.AddCell(new PdfPCell(new Phrase(row.ValueGrade.ToString(), font)));
                            }
                            document.Add(table);
                            document.Close();
                        }
                    }
                }

                // отчёт 2
                using (var stream = new FileStream("Список студентов в разрезе групп.pdf", FileMode.Create))
                {
                    using (var document = new Document())
                    {
                        using (var writer = PdfWriter.GetInstance(document, stream))
                        {
                            document.Open();
                            // добавление заголовка
                            document.Add(new iTextSharp.text.Paragraph("Список студентов в разрезе групп", new Font(bf, titleSize)));
                            // добавление таблицы

                            PdfPTable table = new PdfPTable(3);
                            // заголовок таблицы
                            table.AddCell(new PdfPCell(new Phrase("StudentName", font)));
                            table.AddCell(new PdfPCell(new Phrase("GroupName", font)));
                            table.AddCell(new PdfPCell(new Phrase("SpecialityName", font)));

                            // тело таблицы
                            foreach (var row in data2)
                            {
                                table.AddCell(new PdfPCell(new Phrase(row.StudentName, font)));
                                table.AddCell(new PdfPCell(new Phrase(row.GroupName, font)));
                                table.AddCell(new PdfPCell(new Phrase(row.SpecialityName, font)));
                            }
                            document.Add(table);
                            document.Close();
                        }
                    }
                }



                // отчёт 3
                using (var stream = new FileStream("Учебная нагрузка.pdf", FileMode.Create))
                {
                    using (var document = new Document())
                    {
                        using (var writer = PdfWriter.GetInstance(document, stream))
                        {
                            document.Open();
                            // добавление заголовка
                            document.Add(new iTextSharp.text.Paragraph("Учебная нагрузка", new Font(bf, titleSize)));
                            // добавление таблицы

                            PdfPTable table = new PdfPTable(3);
                            // заголовок таблицы
                            table.AddCell(new PdfPCell(new Phrase("ФИО преподавателя", font)));
                            table.AddCell(new PdfPCell(new Phrase("Имя дисциплины", font)));
                            table.AddCell(new PdfPCell(new Phrase("Имя специальности", font)));

                            // тело таблицы
                            foreach (var row in data3)
                            {
                                table.AddCell(new PdfPCell(new Phrase(row.ФИО_преподавателя, font)));
                                table.AddCell(new PdfPCell(new Phrase(row.Имя_дисцплины, font)));
                                table.AddCell(new PdfPCell(new Phrase(row.Имя_специальности, font)));
                            }
                            document.Add(table);
                            document.Close();
                        }
                    }
                }


                // отчёт 4
                using (var stream = new FileStream("Ведомость оценок студентов в разрезе дисциплин.pdf", FileMode.Create))
                {
                    using (var document = new Document())
                    {
                        using (var writer = PdfWriter.GetInstance(document, stream))
                        {
                            document.Open();
                            // добавление заголовка
                            document.Add(new iTextSharp.text.Paragraph("Ведомость оценок студентов в разрезе дисциплин", new Font(bf, titleSize)));
                            // добавление таблицы

                            PdfPTable table = new PdfPTable(5);
                            // заголовок таблицы
                            table.AddCell(new PdfPCell(new Phrase("GroupName", font)));
                            table.AddCell(new PdfPCell(new Phrase("DisciplineName", font)));
                            table.AddCell(new PdfPCell(new Phrase("StudentName", font)));
                            table.AddCell(new PdfPCell(new Phrase("GradeDate", font)));
                            table.AddCell(new PdfPCell(new Phrase("GradeValue", font)));

                            // тело таблицы
                            foreach (var row in data4)
                            {
                                table.AddCell(new PdfPCell(new Phrase(row.GroupName, font)));
                                table.AddCell(new PdfPCell(new Phrase(row.DisciplineName, font)));
                                table.AddCell(new PdfPCell(new Phrase(row.StudentName, font)));
                                table.AddCell(new PdfPCell(new Phrase(row.GradeDate.ToString(), font)));
                                table.AddCell(new PdfPCell(new Phrase(row.GradeValue.ToString(), font)));
                            }
                            document.Add(table);
                            document.Close();
                        }
                    }

                    MessageBox.Show("ОТЧЕТ СОЗДАН!");
                }
            }
        }
    }
}

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
    public partial class DisciplinesData : Page
    {
        CollegeEntities db = new CollegeEntities();
        public DisciplinesData()
        {
            InitializeComponent();
            DisciplinesDataGrid.ItemsSource = db.Disciplines.ToList();
            Elements.DisciplinesDataGrid = DisciplinesDataGrid;
        }
    }
}

using Lab2.DataAccess;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Lab3.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentDbContext _db;
        public MainWindow()
        {
            InitializeComponent();
            _db = new StudentDbContext();
        }

        private void BtnLoadDataClick(object sender, RoutedEventArgs e)
        {
            LstStudents.ItemsSource = _db.Students.ToList();
        }

        private void BtnSortClick(object sender, RoutedEventArgs e)
        {
            //LstStudents.ItemsSource = _db.Students.OrderBy(x => x.Surname).ToList();

            var sortColumn = LbSortColumn.Text;
            var sortOrder = LbSortOrder.Text;

            switch (sortOrder)
            {
                case "ASC":
                    LstStudents.ItemsSource = _db.Students.OrderBy(x => x.Surname).ToList();
                    break;
                case "DESC":
                    LstStudents.ItemsSource = _db.Students.OrderByDescending(x => x.Surname).ToList();
                    break;
            }
        }

        private void LstStudents_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }


            if (e.AddedItems[0] is not Student student) return;

            var studentId = student.Id;

            var grades = _db.Grades.Include(g => g.Student)
                .Where(g => g.Student.Id == studentId)
                .ToList();

            LstGrades.ItemsSource = grades;
        }
    }
}
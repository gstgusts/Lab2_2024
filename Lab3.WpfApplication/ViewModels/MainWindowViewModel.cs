using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab2.DataAccess;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab3.WpfApplication.ViewModels
{
    public class MainWindowViewModel : ObservableObject, INotifyPropertyChanged
    {
        private StudentDbContext _db;

        public MainWindowViewModel()
        {
            _db = new StudentDbContext();
            SelectStudentCommand = new RelayCommand(LoadGrades);
        }

        private Student[] _students;

        public Student[] Students => _students;

        public void Load()
        {
            _students = _db.Students.ToArray();
        }

        private List<Grade> _grades = new List<Grade>();

        public List<Grade> Grades
        {
            get
            {
                return _grades;
            }
            set
            {
                _grades = value;
                OnPropertyChanged();
            }
        }

        public Student SelectedStudent { get; set; }
            
        public void LoadGrades()
        {
            if (SelectedStudent == null)
            {
                return;
            }

            Grades = _db.Grades.Where(s => s.Id == SelectedStudent.Id).ToList();
        }

        public ICommand SelectStudentCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab2.DataAccess;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
            SearchCommand = new RelayCommand(FilterData);
            UpdateCommand = new RelayCommand(UpdateData);
        }

        private Student[] _students;

        public Student[] Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public string SearchName { get; set; }

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

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        public void LoadGrades()
        {
            if (SelectedStudent == null)
            {
                return;
            }

            Grades = _db.Grades.Where(s => s.Id == SelectedStudent.Id).ToList();
        }

        public void FilterData()
        {
            Students = _db.Students
                .Where(s => s.Name.ToUpper().Contains(SearchName.ToUpper()))
                .ToArray();
        }

        public void UpdateData()
        {
            var studentToUpdate = _db.Students.FirstOrDefault(s => s.Id == SelectedStudent.Id);

            if (studentToUpdate != null)
            {
                studentToUpdate.Name = SelectedStudent.Name;
                studentToUpdate.Surname = SelectedStudent.Surname;

                _db.SaveChanges();
            }

        }

        public ICommand SelectStudentCommand { get; }

        public ICommand SearchCommand { get; }

        public ICommand UpdateCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

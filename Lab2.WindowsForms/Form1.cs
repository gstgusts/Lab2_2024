using Lab2.DataAccess;

namespace Lab2.WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var db = new StudentDbContext();

           var student = db.Students.First();

           textBox1.Text = student.Name;
        }
    }
}

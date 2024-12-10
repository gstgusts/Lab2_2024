using Azure;
using Lab2.DataAccess;
using System.Text.RegularExpressions;

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
            //var db = new StudentDbContext();

            //var student = db.Students.First();

            //textBox1.Text = student.Name;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nameErrorProvider = new System.Windows.Forms.ErrorProvider();
            nameErrorProvider.SetIconAlignment(this.textBox1, ErrorIconAlignment.MiddleRight);
            nameErrorProvider.SetIconPadding(this.textBox1, 2);
            nameErrorProvider.BlinkRate = 1000;
            nameErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            this.textBox1.Validated += new System.EventHandler(this.nameTextBox1_Validated);
        }

        private void nameTextBox1_Validated(object sender, System.EventArgs e)
        {
            if (IsNameValid())
            {
                // Clear the error, if any, in the error provider.
                nameErrorProvider.SetError(this.textBox1, String.Empty);
            }
            else
            {
                // Set the error if the name is not valid.
                nameErrorProvider.SetError(this.textBox1, "Email is invalid");
            }
        }

        // Functions to verify data.
        private bool IsNameValid()
        {
            string email = textBox1.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            return match.Success;
        }
    }
}

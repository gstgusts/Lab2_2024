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
using System.Windows.Shapes;
using Lab3.WpfApplication.ViewModels;

namespace Lab3.WpfApplication
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {

        private TestViewModel _viewModel;

        public TestWindow()
        {
            InitializeComponent();

            InitModel();
        }

        private async void InitModel()
        {
            _viewModel = new TestViewModel(3);
            
            await _viewModel.Load();

            this.DataContext = _viewModel;
        }
    }
}

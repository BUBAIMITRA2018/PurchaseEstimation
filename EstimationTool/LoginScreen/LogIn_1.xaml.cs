using Estimationtool.ViewModels;
using EstimationTool.RegistrationScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EstimationTool.LoginScreen
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn_1 : Window
    {
        public LogIn_1()
        {
            InitializeComponent();
           

        }

  

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Registration window = new Registration();
            window.Show();
            this.Close();

        }
    }
}

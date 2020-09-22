using Estimationtool.Data;
using Estimationtool.ViewModels;
using EstimationTool.LoginScreen;
using EstimationTool.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace EstimationTool.RegistrationScreen
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();

         
            //RegistrationViewModel vm = servicelocator.RegistrationViewModel;
            //this.DataContext = vm;
         
        }

        private void GoToLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
     
            LogIn window = new LogIn();
            this.Close();
     
            window.Show();

        }

      
    }
}

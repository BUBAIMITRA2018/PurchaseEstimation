using Estimationtool.Data;
using Estimationtool.ViewModels;
using EstimationTool.LoginScreen;
using EstimationTool.Models;
using EstimationTool.Ninject;
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

            ServiceLocator servicelocator = new ServiceLocator();
            RegistrationViewModel vm = servicelocator.RegistrationViewModel;
            this.DataContext = vm;
         
        }

        private void GoToLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ServiceLocator servicelocator = new ServiceLocator();
            LogIn window = new LogIn();
            this.Close();
            LoginViewModel vm = servicelocator.LoginViewModel;
            window.DataContext = vm;
            window.Show();

        }

        //private  void SingUp_Click(object sender, RoutedEventArgs e)
        //{

        //    try
        //    {

        //        DataAcess dataacess = new DataAcess();
        //        var users = dataacess.users.ToList();
        //        bool is_match = false;

        //        foreach (var user in users)
        //        {
        //            is_match = Email.Text.ToLowerInvariant() == user.Username.ToLowerInvariant();
        //            if (is_match)
        //            {
        //                break;

        //            }

        //        }

        //        if (is_match)
        //        {
        //            MessageBoxResult result = MessageBox.Show("Email Id already Exist");

        //        }
        //        else
        //        {
        //            User objCompanyUser = new User();
        //            objCompanyUser.Username = Email.Text;
        //            objCompanyUser.Password = Password.Text;

        //            dataacess.users.Add(objCompanyUser);

        //            dataacess.SaveChangesAsync();



        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }






        //}
    }
}

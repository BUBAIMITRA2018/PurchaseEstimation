using Estimationtool.ViewModels;
using EstimationTool.HomeScreen;
using EstimationTool.LoginScreen;
using EstimationTool.Ninject;
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

namespace EstimationTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _username;

        public MainWindow(string username)
        {
            InitializeComponent();
            UserControl usc = null;
            GridMain.Children.Clear();
            usc = new UserControlHome();
            GridMain.Children.Add(usc);
            _username = username;
            this.username_entry.Text = _username;

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            ServiceLocator servicelocator = new ServiceLocator();
            LogIn window = new LogIn();
            LoginViewModel vm = servicelocator.LoginViewModel;
            window.DataContext = vm;
            this.Close();
            window.Show();

        }
        //private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonClose.Visibility = Visibility.Visible;
        //    ButtonOpen.Visibility = Visibility.Collapsed;
        //}

        //private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonClose.Visibility = Visibility.Collapsed;
        //    ButtonOpen.Visibility = Visibility.Visible;
        //}

        //private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    UserControl usc = null;
        //    GridMain.Children.Clear();

        //    switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
        //    {
        //        case "Home":
        //            usc = new UserControlHome();
        //            GridMain.Children.Add(usc);
        //            break;

        //        default:
        //            break;
        //    }
        //}

    }
}



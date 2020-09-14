using Estimationtool.Models;
using Estimationtool.Services;
using Estimationtool.ViewModels;
using EstimationTool.HomeScreen;
using EstimationTool.LoginScreen;
using EstimationTool.Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace EstimationTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceLocator servicelocator = new ServiceLocator();
            LogIn window = new LogIn();
            LoginViewModel vm = servicelocator.LoginViewModel;
            window.DataContext = vm;
            window.Show();



        }
    }
}

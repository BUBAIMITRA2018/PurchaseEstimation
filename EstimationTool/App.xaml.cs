using Estimationtool.Models;

using Estimationtool.ViewModels;
using EstimationTool.HomeScreen;
using EstimationTool.LoginScreen;

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
         
            LogIn window = new LogIn();
    
            window.Show();



        }
    }
}

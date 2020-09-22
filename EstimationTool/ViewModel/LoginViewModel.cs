using Estimationtool.Helper;

using System.ComponentModel;
using System.Windows.Input;

using System.Threading.Tasks;
using EstimationTool;

using EstimationTool.Models;
using EstimationTool.Helper;
using System;
using EstimationTool.RegistrationScreen;
using EstimationTool.LoginScreen;
using System.Windows;


namespace Estimationtool.ViewModels
{
 public   class LoginViewModel:BaseViewModel
    {

        private string _username;
        private string _password;
        private bool _boolfilteractivate;
        private bool _areCredentialsInvalid;

        LogIn LoginObj = new LogIn();
        

        


        public LoginViewModel()
        {



         

        }


        public bool Boolfilteractivate
        {
            get => this._boolfilteractivate;
            set
            {
                this.SetProperty(ref this._boolfilteractivate, value);
            }
        }




        public string Username
        {
            get =>this._username;
            set
            {
                this.SetProperty(ref this._username, value);
            }
        }

        public string Password
        {
            get => this._password;
            set
            {
                this.SetProperty(ref this._password, value);


    }
}




    }
}

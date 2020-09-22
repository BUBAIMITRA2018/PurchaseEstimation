using Estimationtool.Helper;

using System.ComponentModel;
using System.Windows.Input;

using System.Threading.Tasks;
using EstimationTool;

using EstimationTool.Models;
using EstimationTool.Helper;
using System;
using EstimationTool.RegistrationScreen;
using System.Windows;

namespace Estimationtool.ViewModels
{
 public   class RegistrationViewModel : BaseViewModel
    {

        private string _username;
        private string _password;
        private bool _areCredentialsInvalid;
 


        public RegistrationViewModel()
        {

            AreCredentialsInvalid = false;

      

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


       
        public bool AreCredentialsInvalid
        {
            get => _areCredentialsInvalid;
            set
            {
                this.SetProperty(ref this._areCredentialsInvalid, value);
            }
        }



        private ICommand authenticateCommand;
        public ICommand AuthenticateCommand
        {
            get
            {
                return authenticateCommand ?? (authenticateCommand = new AsyncRelayCommand(X => doStuff2()));
            }                                                                                  
  
        }

        private async Task doStuff2()
        {
            //await UserRegistration(Username, Password);
     
        }




      

        

            
    }
}

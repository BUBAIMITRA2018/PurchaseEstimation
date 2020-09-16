using Estimationtool.Helper;

using System.ComponentModel;
using System.Windows.Input;

using System.Threading.Tasks;
using EstimationTool;
using EstimationTool.Service;
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
        private IUserStore<User> _usersdata;


        public RegistrationViewModel(IUserStore<User> usersdata)
        {

            AreCredentialsInvalid = false;

            _usersdata = usersdata;

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
            await UserRegistration(Username, Password);
     
        }




        private async Task UserRegistration(string username, string password)
        {
            bool is_match = false; 
            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password))
            {
                is_match = false;

            }

            var users = await _usersdata.GetItemsAsync();

            foreach (var user in users)
            {
              is_match = username.ToLowerInvariant() == user.Username && password.ToLowerInvariant() == user.Password;

                if (is_match)
                    {
                    break;

                    }
            }


            if (is_match)
            {
                MessageBoxResult result = MessageBox.Show("Email Id already Exist");
                is_match = false;

            }
            else
            {
                User objCompanyUser = new User();
                objCompanyUser.Username = username;
                objCompanyUser.Password = Password;

                 bool done = await _usersdata.AddItemAsync(objCompanyUser);

                if (done)
                {
                    MessageBoxResult result = MessageBox.Show("User added is sucessfully");
                    done = false;

                }

            }






        }
    }
}

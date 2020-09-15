﻿using Estimationtool.Helper;

using System.ComponentModel;
using System.Windows.Input;

using System.Threading.Tasks;
using EstimationTool;
using EstimationTool.Service;
using EstimationTool.Models;
using EstimationTool.Helper;
using System;
using EstimationTool.RegistrationScreen;

namespace Estimationtool.ViewModels
{
 public   class LoginViewModel:BaseViewModel
    {

        private string _username;
        private string _password;
        private bool _areCredentialsInvalid;
        private IUserStore<User> _usersdata;


        public LoginViewModel(IUserStore<User> usersdata)
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


        private ICommand registrationcommand;
        public ICommand Registrationcommand
        {
            get
            {
                return registrationcommand ?? (registrationcommand = new DelegateCommand<object>(X =>
                {
                    UserControlRegistration window = new UserControlRegistration();
                    window.Show();


                }));
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
            AreCredentialsInvalid = await UserAuthenticated(Username, Password);
            if (!AreCredentialsInvalid) return;

            MainWindow window = new MainWindow();
            window.Show();
        }




        private async Task<bool> UserAuthenticated(string username, string password)
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


            return is_match;



       


    }
    }
}

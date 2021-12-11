using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFAuction.ViewModels
{
    public class LoginViewModel : ViewModel, INotifyPropertyChanged
    {
        public ICommand loginCommand { get; set; }

        public UserLogic authManager;

        string email;
        string password;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            private get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel(UserLogic authManager)
        {
            loginCommand = new LoginCommand(this);

            this.authManager = authManager;
        }

        public bool LogInButton()
        {
            return authManager.UserLogin(email, password);
        }

        public Action LoginSuccess { get; set; }
        public Action LoginFailed { get; set; }
        public Action Exit { get; set; }

        public string Error { get { throw new NotImplementedException(); } }
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        
    }
}

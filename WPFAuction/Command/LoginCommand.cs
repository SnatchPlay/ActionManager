using System;
using System.Windows.Input;

namespace WPFAuction.ViewModels
{
    public class LoginCommand : ICommand
    {
        private LoginViewModel loginVM;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public LoginCommand(LoginViewModel loginVM)
        {
            this.loginVM = loginVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (loginVM.LogInButton()==true)
            {
                loginVM.LoginSuccess?.Invoke();
            }
            else
            {
                loginVM.LoginFailed?.Invoke();
            }
        }
        
    }
}
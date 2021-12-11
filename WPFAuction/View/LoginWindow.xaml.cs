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
using System.Windows.Shapes;
using Unity;
using WPFAuction.ViewModels;

namespace WPFAuction
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(LoginViewModel lvm)
        {
            InitializeComponent();
            DataContext = lvm;

            Loaded += Login_Load;
        }

        private void Login_Load(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel lvm)
            {
                lvm.LoginSuccess += () =>
                {
                    DialogResult = true;
                    
                    Close();
                };
                lvm.LoginFailed += () =>
                {
                    MessageBox.Show("No access!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                };
                lvm.Exit += () =>
                {
                    DialogResult = false;
                    
                };
            }
        }

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
    }
}

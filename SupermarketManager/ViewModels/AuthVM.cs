using Checkers.Utils;
using SupermarketManager.Model.BusinessLogicLayer;
using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Utils.Managers;
using SupermarketManager.Views;
using SupermarketManager.Views.Cashier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SupermarketManager.ViewModels
{
    public class AuthVM
    {
        private readonly AuthBLL authBLL;
        private string username;
        private string password;
        private string userType;
        private readonly Window currentWindow;

        private ICommand registerCommand;
        private ICommand goToLoginCommand;
        private ICommand loginCommand;
        private ICommand goToRegisterCommand;

        public AuthVM(Window window)
        {
            authBLL = new AuthBLL(new AuthDAL());
            this.currentWindow = window;
        }

        public ICommand RegisterCommand
        {
            get
            {
                if (registerCommand == null)
                {
                    registerCommand = new ParameterlessRelayCommand(RegisterUser, param => true);
                }
                return registerCommand;
            }
            set { registerCommand = value; }
        }

        public ICommand GoToLoginCommand
        {
            get
            {
                if (goToLoginCommand == null)
                {
                    goToLoginCommand = new ParameterlessRelayCommand(GoToLogin, param => true);
                }
                return goToLoginCommand;
            }
            set
            {
                goToLoginCommand = value;
            }
        }
        public ICommand GoToRegisterCommand
        {
            get
            {
                if (goToRegisterCommand == null)
                {
                    goToRegisterCommand = new ParameterlessRelayCommand(GoToRegister, param => true);
                }
                return goToRegisterCommand;
            }
            set
            {
                goToRegisterCommand = value;
            }
        }
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new ParameterlessRelayCommand(LoginUser, param => true);
                }
                return loginCommand;
            }
            set => loginCommand = value;
        }
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                { password = value; }
            }
        }

        public string UserType
        {
            get { return userType; }
            set
            {
                if (userType != value)
                {
                    userType = value;
                }
            }
        }

        private void RegisterUser()
        {
            try
            {
                if (authBLL.Register(Username, Password, UserType))
                {
                    MessageBox.Show("User registerd succesfully.");

                    if (UserType == "Admin")
                    {
                        GoToAdminMenu();
                    }
                    else if (UserType == "Cashier")
                    {
                        GoToCashierMenu();
                    }
                }
                else
                {
                    MessageBox.Show("User already exists.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GoToLogin()
        {
            Login login = new Login();
            currentWindow.Close();
            login.ShowDialog();
        }

        private void GoToRegister()
        {
            MainWindow window = new MainWindow();
            currentWindow.Close();
            window.ShowDialog();
        }

        private void LoginUser()
        {
            try
            {
                if (authBLL.Login(Username, Password))
                {
                    MessageBox.Show("Login succesfully.");

                    if (authBLL.GetUserType(username, password) == "Admin")
                    {
                        GoToAdminMenu();
                    } else if (authBLL.GetUserType(username, password) == "Cashier")
                    {
                        GoToCashierMenu();
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GoToAdminMenu()
        {
            AdministratorMenu administratorMenu = new AdministratorMenu();
            this.currentWindow.Close();
            administratorMenu.ShowDialog();
        }
        private void GoToCashierMenu()
        {
            Checkout checkout = new Checkout(Username);
            this.currentWindow.Close();
            checkout.ShowDialog();
        }
    }
}

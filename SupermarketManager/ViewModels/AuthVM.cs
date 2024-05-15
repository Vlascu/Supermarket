using Checkers.Utils;
using SupermarketManager.Model.BusinessLogicLayer;
using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Utils.Managers;
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

        private ICommand registerCommand;

        public AuthVM()
        {
            authBLL = new AuthBLL(new AuthDAL());
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
                if(authBLL.Register(Username,Password,UserType))
                {
                    MessageBox.Show("User registerd succesfully.");
                } else
                {
                    MessageBox.Show("User already exists.");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.EntityLayer
{
    public class User : BasePropertyChanged
    {
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private string userType;
        public string UserType
        {
            get { return userType; }
            set
            {
                userType = value;
                NotifyPropertyChanged("UserType");
            }
        }
    }
}

using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SupermarketManager.Model.BusinessLogicLayer
{
    public class AuthBLL
    {
        private readonly AuthDAL authDAL;

        public AuthBLL(AuthDAL authDAL)
        {
            this.authDAL = authDAL;
        }

        public bool Register(string username, string password, string userType)
        {
            InputValidation(username, password, userType);

            User user = new User();
            user.Username = username;
            user.Password = HashPassword(password);
            user.UserType = userType;

            if (!authDAL.CheckUserExists(user))
            {
                authDAL.AddUser(user);
                return true;
            }
            return false;
        }
        public bool Login(string username, string password)
        {
            InputValidation(username, password);

            User user = new User();
            user.Username = username;
            user.Password = HashPassword(password);

            if (authDAL.CheckUserExists(user))
            {
                return true;
            }
            return false;

        }
        private static void InputValidation(string username, string password)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Null or empty username!");
            }
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Null or empty password!");
            }
        }
        private static void InputValidation(string username, string password, string userType)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Null or empty username!");
            }
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Null or empty password!");
            }
            if (String.IsNullOrEmpty(userType))
            {
                throw new ArgumentException("Null or empty user type!");
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public string GetUserType(string username, string password)
        {
            if (username == null || username == "" || password == null || password == "")
            {
                throw new ArgumentException("Null or empty password or username");
            }
            User user = new User();
            user.Username = username;
            user.Password = HashPassword(password);

            return authDAL.GetUserType(user);
        }
    }
}

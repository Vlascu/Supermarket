using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.DataAccessLayer
{
    public class AuthDAL
    {
        private SqlConnection conn;

        public AuthDAL()
        {
            conn = DALUtil.Connection;
        }

        public void AddUser(User user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AddUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter usernameParam = new SqlParameter("@username", user.Username);
                SqlParameter passwordParam = new SqlParameter("@password", user.Password);
                SqlParameter typeParameter = new SqlParameter("@user_type", user.UserType);

                cmd.Parameters.Add(usernameParam);
                cmd.Parameters.Add(passwordParam);
                cmd.Parameters.Add(typeParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + "When trying to add user with username " + user.Username);
            }
            finally
            {
                conn.Close();
            }

        }

        public bool CheckUserExists(User user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CheckUserExists", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter usernameParam = new SqlParameter("@username", user.Username);
                SqlParameter passwordParam = new SqlParameter("@password", user.Password);

                cmd.Parameters.Add(usernameParam);
                cmd.Parameters.Add(passwordParam);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int count = reader.GetInt32(0);
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + "When trying to add user with username + " + user.Username);
            }
            finally
            {
                conn.Close();
            }
        }
        public string GetUserType(User user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetUserType", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter usernameParam = new SqlParameter("@username", user.Username);
                SqlParameter passwordParam = new SqlParameter("@password", user.Password);

                cmd.Parameters.Add(usernameParam);
                cmd.Parameters.Add(passwordParam);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string type = reader.GetString(0);

                    return type;
                }
                else
                {
                    throw new SqlOperationException("User type non existent for user " + user.Username);
                }
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + "When trying to add user with username " + user.Username);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

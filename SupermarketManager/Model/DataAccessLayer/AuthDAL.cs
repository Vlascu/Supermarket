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
                SqlParameter userIdParam = new SqlParameter("@user_id", SqlDbType.Int);

                userIdParam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(usernameParam);
                cmd.Parameters.Add(passwordParam);
                cmd.Parameters.Add(typeParameter);
                cmd.Parameters.Add(userIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to add user with username + " + user.Username);
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
                SqlCommand cmd = new SqlCommand("AddUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter usernameParam = new SqlParameter("@username", user.Username);
                SqlParameter passwordParam = new SqlParameter("@password", user.Password);

                cmd.Parameters.Add(usernameParam);
                cmd.Parameters.Add(passwordParam);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to add user with username + " + user.Username);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

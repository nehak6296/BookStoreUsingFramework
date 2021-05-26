using ModelsLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class UserRepo : IUserRepo
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ToString();
            connection = new SqlConnection(connectionString);

        }

        //To Register New user    
        public Registration RegisterUser(Registration registrationModel)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_RegisterUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", registrationModel.FirstName);
                cmd.Parameters.AddWithValue("@LastName", registrationModel.LastName);
                cmd.Parameters.AddWithValue("@Email", registrationModel.Email);
                cmd.Parameters.AddWithValue("@Password", registrationModel.Password);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return registrationModel;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}

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
    public class OrdersRepo : IOrdersRepo
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public int PlaceOrder(int userId, int cartId)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_PlaceOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@CartId", cartId);               
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return userId;
                else
                    return cartId;
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

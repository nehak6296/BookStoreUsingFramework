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
                    return 1;
                else
                    return 0;
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

        public Orders GetAllOrders(Orders orders)
        {
            try
            {
                Connection();
                List<Orders> ordersList = new List<Orders>();
                SqlCommand cmd = new SqlCommand("sp_GetAllCustomerDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                connection.Open();
                da.Fill(dt);
                connection.Close();
                //Bind OrdersModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    ordersList.Add(
                        new Orders
                        {
                            OrderId = Convert.ToInt32(dr["orderId"]),
                            UserId = Convert.ToInt32(dr["userId"])
                        }
                        );
                }
                return orders;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

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
        public Orders PlaceOrder(Orders orders)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_PlaceOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", orders.UserId);
                cmd.Parameters.AddWithValue("@CartId", orders.CartId);
                //cmd.Parameters.AddWithValue("@OrderId",orders.OrderId,out);
                connection.Open();
                var i = cmd.ExecuteScalar();
                connection.Close();
                if (i != null)                    
                    return orders;
                else
                    return null;
                
                //SqlDataReader rdr = cmd.ExecuteReader();
                //int OrderId;
                //while (rdr.Read())
                //{
                //    OrderId = Convert.ToInt32(rdr["orderId"]);
                //    orders.OrderId = OrderId;
                //}



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

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
    public class CartRepo : ICartRepo
    {
        private SqlConnection connection;

        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);

        }
        public Cart AddToCart(Cart cartModel)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_AddToCart", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", cartModel.BookId);
                cmd.Parameters.AddWithValue("@UserId", cartModel.UserId);
                cmd.Parameters.AddWithValue("@CartBookQuantity", cartModel.CartBookQuantity);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
               
                if (i >= 1)
                    return cartModel;
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

        public bool RemoveFromCart(int cartId, int userId)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_RemoveFromCart", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartId", cartId);
                cmd.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
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

        public List<GetCart> GetCart(int userId)
        {
            Connection();
            List<GetCart> CartList = new List<GetCart>();
            SqlCommand cmd = new SqlCommand("sp_GetAllCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);           
            //Bind CartModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                CartList.Add(
                    new GetCart
                    {
                        UserId = userId,
                        CartId = Convert.ToInt32(dr["CartId"]),
                        BookId = Convert.ToInt32(dr["BookId"]),
                        BookName=Convert.ToString(dr["BookName"]),
                        Author=Convert.ToString(dr["Author"]),
                        Price=Convert.ToInt32(dr["Price"]),
                        Image=Convert.ToString(dr["Image"]),                                               
                        CartBookQuantity = Convert.ToInt32(dr["cartBookQuantity"])                       
                    }
                    );
            }
            return CartList;
        }
    }
}
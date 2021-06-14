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
    public class WishListRepo : IWishListRepo
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);

        }
        public WishList AddToWishList(WishList wishList)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_AddToWishList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", wishList.BookId);
                cmd.Parameters.AddWithValue("@UserId", wishList.UserId);
                cmd.Parameters.AddWithValue("@Quantity", wishList.WishListQuantity);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                //connection.Close();
                if (i >= 1)
                    return wishList;
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

        public int RemoveFromWishList(int wishListId)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_RemoveFromWishList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WishListId", wishListId);                               
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

        public List<GetWishList> GetWishList()
        {
            Connection();
            List<GetWishList> wishList = new List<GetWishList>();
            SqlCommand cmd = new SqlCommand("sp_GetAllWishList", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", 1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);
            
            //Bind WishListModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                wishList.Add(
                    new GetWishList
                    {
                        WishListId=Convert.ToInt32(dr["WishListId"]),
                        WishListQuantity=Convert.ToInt32(dr["WishListQuantity"]),
                        BookId = Convert.ToInt32(dr["BookId"]),                       
                        BookName=Convert.ToString(dr["BookName"]),
                        Author= Convert.ToString(dr["Author"]),
                        Price = Convert.ToInt32(dr["Price"]),
                        Image = Convert.ToString(dr["Image"])
                    }
                    );
            }
            return wishList;
        }
    }
}

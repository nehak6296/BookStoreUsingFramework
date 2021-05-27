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
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ToString();
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
                cmd.Parameters.AddWithValue("@WishListQuantity", wishList.WishListQuantity);
                cmd.Parameters.AddWithValue("@IsWishListed", wishList.IsWishListed);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
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

        public int RemoveFromWishList(int userId, int wishListId)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_RemoveFromWishList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", wishListId);
                cmd.Parameters.AddWithValue("@UserId", userId);               
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return wishListId;
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
    }
}

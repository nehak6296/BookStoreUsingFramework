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
    public class BookRepo : IBookRepo
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }

        public Books AddBook(Books booksModel)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_AddBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookName", booksModel.BookName);
                cmd.Parameters.AddWithValue("@Author", booksModel.Author);
                cmd.Parameters.AddWithValue("@Details", booksModel.Details);
                cmd.Parameters.AddWithValue("@Price", booksModel.Price);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return booksModel;
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

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
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
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
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
                cmd.Parameters.AddWithValue("@Quantity", booksModel.Quantity);
                cmd.Parameters.AddWithValue("@Image", booksModel.Image);
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
        public Books UpdateBook(Books booksModel)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_UpdateBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookName", booksModel.BookName);
                cmd.Parameters.AddWithValue("@Author", booksModel.Author);
                cmd.Parameters.AddWithValue("@Details", booksModel.Details);
                cmd.Parameters.AddWithValue("@Price", booksModel.Price);
                cmd.Parameters.AddWithValue("@Quantity", booksModel.Quantity);

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
        public bool DeleteBook(int bookId)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_deleteBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", bookId);
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

        public List<Books> GetAllBooks()
        {
            try
            {
                Connection();
                List<Books> BookList = new List<Books>();
                SqlCommand cmd = new SqlCommand("sp_GetAllBooks", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                connection.Open();
                da.Fill(dt);
                connection.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    BookList.Add(
                        new Books
                        {
                            BookId = Convert.ToInt32(dr["BookId"]),
                            BookName = Convert.ToString(dr["BookName"]),
                            Author = Convert.ToString(dr["Author"]),
                            Details = Convert.ToString(dr["Details"]),
                            Price = Convert.ToDouble(dr["Price"]),
                            Quantity = Convert.ToInt32(dr["Quantity"])
                        }
                        );
                }
                return BookList;
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

        public bool UploadImage(int BookId, string imageUpload)
        {
            Connection();            
            SqlCommand cmd = new SqlCommand("sp_AddImage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookId", BookId);
                       // var myAccount = new Account { ApiKey = "371652781151548", ApiSecret = "1aVBjz0E-GdsHlguqwgk_spEyCo", Cloud = "dywhtr8hk" };
            cmd.Parameters.AddWithValue("@Image", imageUpload);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;

            else
                return false;
        }

    }
}


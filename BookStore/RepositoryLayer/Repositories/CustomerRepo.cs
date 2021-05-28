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
    public class CustomerRepo : ICustomerRepo
    {       
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
            {
        string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ToString();
        connection = new SqlConnection(connectionString);

        }
        public Customer AddCustomerDetails(Customer customer)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_AddCustomerDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", customer.Name);
                cmd.Parameters.AddWithValue("@BookId", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@BookId", customer.Address);
                cmd.Parameters.AddWithValue("@BookId", customer.City);
                cmd.Parameters.AddWithValue("@BookId", customer.Locality);
                cmd.Parameters.AddWithValue("@BookId", customer.Landmark);
                cmd.Parameters.AddWithValue("@BookId", customer.Pincode);
                cmd.Parameters.AddWithValue("@BookId", customer.Type);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return customer;
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

        public int DeleteCustomer(int userId, int customerId)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return customerId;
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

        public Customer UpdateCustomerDetails(Customer customer)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_UpdateCustomerDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", customer.Name);
                cmd.Parameters.AddWithValue("@BookId", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@BookId", customer.Address);
                cmd.Parameters.AddWithValue("@BookId", customer.City);
                cmd.Parameters.AddWithValue("@BookId", customer.Locality);
                cmd.Parameters.AddWithValue("@BookId", customer.Landmark);
                cmd.Parameters.AddWithValue("@BookId", customer.Pincode);
                cmd.Parameters.AddWithValue("@BookId", customer.Type);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return customer;
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


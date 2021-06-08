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
        string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
        connection = new SqlConnection(connectionString);

        }
        public Customer AddCustomerDetails(Customer customer)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_AddCustomerDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId",1);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@Locality", customer.Locality);
                cmd.Parameters.AddWithValue("@Landmark", customer.Landmark);
                cmd.Parameters.AddWithValue("@Pincode", customer.Pincode);
                cmd.Parameters.AddWithValue("@Type", customer.Type);
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
      
        public Customer UpdateCustomerDetails(Customer customer)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("sp_UpdateCustomerDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@UserId",1);
                cmd.Parameters.AddWithValue("@CustomerId",customer.CustomerId);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@Locality", customer.Locality);
                cmd.Parameters.AddWithValue("@Landmark", customer.Landmark);
                cmd.Parameters.AddWithValue("@Pincode", customer.Pincode);
                cmd.Parameters.AddWithValue("@Type", customer.Type);
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

        public List<Customer> GetAllCustomerDetails(int userId)
        {
            Connection();
            List<Customer> customerList = new List<Customer>();
            SqlCommand cmd = new SqlCommand("sp_GetAllCustomerDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId",userId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);
            connection.Close();
            //Bind CustomerModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                customerList.Add(
                    new Customer
                    {
                        CustomerId = Convert.ToInt32(dr["CustomerId"]),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Address=Convert.ToString(dr["Address"]),
                        Locality=Convert.ToString(dr["Locality"]),
                        Landmark= Convert.ToString(dr["Landmark"]),
                        Pincode=Convert.ToInt32(dr["Pincode"]),
                        PhoneNumber= Convert.ToInt32(dr["PhoneNumber"]),
                        City= Convert.ToString(dr["City"]),
                        Type=Convert.ToString(dr["Type"])
                    }
                    ); ;
            }
            return customerList;
        }
    }
}


using CentiSoft.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CentiSoft.DAL
{
    public class CustomerRepository
    {
        public List <Customer> LoadAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=localhost;Database=PWECentiSoft;Integrated Security=SSPI";
            
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Customer";
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = reader.GetInt32(0);
                    customer.Name = reader.GetString(1);
                    customer.Company = reader.GetString(2);
                    customer.Position = reader.GetString(3);
                    customer.PhoneNumber = reader.GetString(4);
                    customers.Add(customer);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return customers;
        }
    }
}
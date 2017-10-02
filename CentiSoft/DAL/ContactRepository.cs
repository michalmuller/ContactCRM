using CentiSoft.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CentiSoft.DAL
{
    public class ContactRepository
    {
        public List <Contact> LoadAllContacts()
        {
            List<Contact> contacts = new List<Contact>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=localhost;Database=PWECentiSoft;Integrated Security=SSPI";
            
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Contact";
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Contact contact = new Contact();
                    contact.Id = reader.GetInt32(0);
                    contact.Name = reader.GetString(1);
                    contact.Company = reader.GetString(2);
                    contact.Position = reader.GetString(3);
                    contact.PhoneNumber = reader.GetString(4);
                    contacts.Add(contact);
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
            return contacts;
        }
        
    }
}
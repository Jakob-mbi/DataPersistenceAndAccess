using DataPersistenceAndAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistenceAndAccess.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {

        public string ConnectionString { get; set; } = string.Empty;

   
        public void Add(Customer obj)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = " INSERT INTO Customer  ( FirstName ,LastName,Country,PostalCode,Phone,Email) VALUES(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName",obj.FirstName);
            command.Parameters.AddWithValue("@LastName", obj.LastName);
            command.Parameters.AddWithValue("@Country", obj.Country);
            command.Parameters.AddWithValue("@PostalCode", obj.PostalCode);
            command.Parameters.AddWithValue("@Phone", obj.Phone);
            command.Parameters.AddWithValue("@Email", obj.Email);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email  FROM Customer";
            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read()) 
            {


                string? three = reader.IsDBNull(3) ? null : reader.GetString(3);
                string? four = reader.IsDBNull(4) ? null : reader.GetString(4);
                string? five = reader.IsDBNull(5) ? null : reader.GetString(5);

                list.Add(new Customer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    three,
                    four,
                    five,
                    reader.GetString(6)
                    ));

            }
            connection.Close();
            return list;
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}

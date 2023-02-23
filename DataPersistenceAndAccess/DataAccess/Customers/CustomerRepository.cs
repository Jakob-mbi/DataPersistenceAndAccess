using DataPersistenceAndAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistenceAndAccess.DataAccess.Customers
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
            command.Parameters.AddWithValue("@FirstName",obj.firstName);
            command.Parameters.AddWithValue("@LastName", obj.lastName);
            command.Parameters.AddWithValue("@Country", obj.country);
            command.Parameters.AddWithValue("@PostalCode", obj.postalCode);
            command.Parameters.AddWithValue("@Phone", obj.phone);
            command.Parameters.AddWithValue("@Email", obj.email);
            command.ExecuteNonQuery();
            connection.Close();
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
          
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email  FROM Customer WHERE CustomerId = @ID";

            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", id);

            using var reader = command.ExecuteReader();
            var person = new Customer();

            while (reader.Read())
            {
                string? three = reader.IsDBNull(3) ? null : reader.GetString(3);
                string? four = reader.IsDBNull(4) ? null : reader.GetString(4);
                string? five = reader.IsDBNull(5) ? null : reader.GetString(5);

                person = new Customer(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                three,
                four,
                five,
                reader.GetString(6));
            }
            connection.Close();
            return person;
        }

        public Customer GetByName(string firstName)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email  FROM Customer WHERE FirstName = @Name";

            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", firstName);

            using var reader = command.ExecuteReader();
            var person = new Customer();


            while (reader.Read())
            {
                string? three = reader.IsDBNull(3) ? null : reader.GetString(3);
                string? four = reader.IsDBNull(4) ? null : reader.GetString(4);
                string? five = reader.IsDBNull(5) ? null : reader.GetString(5);

                person = new Customer(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                three,
                four,
                five,
                reader.GetString(6));
            }
            
            connection.Close();
            return person;
        }

        public List<Customer> GetLimitedListWiithOffset(int limit, int offset)
        {
            List<Customer> list = new List<Customer>();
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer Order by CustomerId OFFSET @Offset ROWS FETCH FIRST @limit ROWS ONLY";
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Offset", offset);
            command.Parameters.AddWithValue("@limit", limit);

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

        public List<CustomerCountry> GetListOfCountriesWithAmountOfCustomers()
        {
            List<CustomerCountry> list = new List<CustomerCountry>();
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT Country,COUNT(CustomerId) AS NumberOfCustomers FROM Customer GROUP BY Country Order by NumberOfCustomers DESC";
            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new CustomerCountry(
                    reader.GetString(0),
                    reader.GetInt32(1)
                    ));
            }
            connection.Close();
            return list;
        }

        public List<CustomerGenre> GetListOfCustomerMostPopularGenre(int id)
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.Append("SELECT TOP (1) WITH TIES Customer.CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email, Genre.NAME, COUNT(Genre.NAME) AS GenreNumber");
            stringBuilder.Append(" FROM Customer  INNER JOIN Invoice  ON Customer.CustomerId = Invoice.CustomerId INNER JOIN InvoiceLine  ON Invoice.InvoiceId = InvoiceLine.InvoiceId");
            stringBuilder.Append(" INNER JOIN Track  ON InvoiceLine.TrackId = Track.TrackId  INNER JOIN Genre  ON Track.GenreId = Genre.GenreId");
            stringBuilder.Append(" WHERE [Customer].[CustomerId] = @ID");
            stringBuilder.Append(" GROUP BY Customer.CustomerId, FirstName, LastName,Country, PostalCode,Phone,Email,Genre.NAME");
            stringBuilder.AppendLine(" Order by GenreNumber DESC");
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = stringBuilder.ToString();

            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", id);

            using var reader = command.ExecuteReader();
            var list = new List<CustomerGenre>();


            while (reader.Read())
            {
                string? three = reader.IsDBNull(3) ? null : reader.GetString(3);
                string? four = reader.IsDBNull(4) ? null : reader.GetString(4);
                string? five = reader.IsDBNull(5) ? null : reader.GetString(5);
               list.Add(new CustomerGenre(new Customer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    three,
                    four,
                    five,
                    reader.GetString(6)
                    ), reader.GetString(7), reader.GetInt32(8)));
            }

            connection.Close();
            return list;
        }

        public List<CustomerSpender> GetListOfHighestSpendingCustomers()
        {
            List<CustomerSpender> list = new List<CustomerSpender>();
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT Customer.CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email, SUM(Total) AS TotelSpending FROM Customer INNER JOIN Invoice ON Customer.CustomerId = Invoice.CustomerId GROUP BY Customer.CustomerId,FirstName, LastName, Country, PostalCode, Phone, Email Order by TotelSpending DESC";
            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string? three = reader.IsDBNull(3) ? null : reader.GetString(3);
                string? four = reader.IsDBNull(4) ? null : reader.GetString(4);
                string? five = reader.IsDBNull(5) ? null : reader.GetString(5);
                list.Add(new CustomerSpender(new Customer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    three,
                    four,
                    five,
                    reader.GetString(6)
                    ), reader.GetDecimal(7)));
            }
            connection.Close();
            return list;
        }

        public void Update(Customer obj)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "UPDATE Customer SET FirstName = @firstName, LastName = @lastName, Country = @country, PostalCode = @postalCode, Phone = @phone, Email = @email WHERE CustomerId = @ID";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@firstName", obj.firstName);
            command.Parameters.AddWithValue("@lastName", obj.lastName);
            command.Parameters.AddWithValue("@country", obj.country);
            command.Parameters.AddWithValue("@postalCode", obj.postalCode);
            command.Parameters.AddWithValue("@phone", obj.phone);
            command.Parameters.AddWithValue("@email", obj.email);
            command.Parameters.AddWithValue("@ID", obj.customerId);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

using DataPersistenceAndAccess.Repositories.Customers;
using Microsoft.Data.SqlClient;

namespace DataPersistenceAndAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = new CustomerRepository { ConnectionString = GetConnectionString() };
            //customers.Add(new Models.Customer(null, "Jakob", "TheGoat", "Sweden", "17444", "073 258 65 98", "TheGoat@Legend.com"));
            //var allPeople = customers.GetAll();
            //foreach (var person in allPeople) 
            //{
            //    Console.WriteLine(person.CustomerId+" "+person.FirstName + " "+ person.LastName);
            //}
            static string GetConnectionString()
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "N-SE-01-5256\\SQLEXPRESS";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                builder.TrustServerCertificate = true;
                return builder.ConnectionString;
            }
        }
    }
}
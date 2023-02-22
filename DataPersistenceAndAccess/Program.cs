using DataPersistenceAndAccess.DataAccess.Customers;
using Microsoft.Data.SqlClient;

namespace DataPersistenceAndAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = new CustomerRepository { ConnectionString = GetConnectionString() };
            //customers.Update(new Models.Customer(62, "Jakob", "TheGoat", "Sweden", "17444", "073 258 65 98", "TheGoat@Legend.com"));
            //var allPeople = customers.GetLimitedListWiithOffset(4,4);
            //foreach (var person in allPeople)
            //{
            //    Console.WriteLine(person.CustomerId + " " + person.FirstName + " " + person.LastName);
            //}
            //var person = customers.GetByName("jakob");
            //Console.WriteLine(person.CustomerId+" "+person.FirstName + " " +person.LastName + " " +person.Country);

            //var allPeople = customers.GetListOfCountriesWithAmountOfCustomers();
            //foreach (var person in allPeople)
            //{
            //    Console.WriteLine(person.Country+ " " + person.NumberOfCustomers);
            //}

            var allPeople = customers.GetListOfHighestSpendingCustomers();
            foreach (var person in allPeople)
            {
                Console.WriteLine(person.customer.FirstName + " " + person.customer.LastName + " " +person.totalSpent);
            }
            static string GetConnectionString()
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "LAPTOP-SJ7TR0SQ";
                builder.InitialCatalog = "Chinook";
                builder.IntegratedSecurity = true;
                builder.TrustServerCertificate = true;
                return builder.ConnectionString;
            }
            //N - SE - 01 - 5256\\SQLEXPRESS
        }
    }
}
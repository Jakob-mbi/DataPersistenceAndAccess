using DataPersistenceAndAccess.DataAccess.Customers;
using Microsoft.Data.SqlClient;
using System;

namespace DataPersistenceAndAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository customers = new CustomerRepository (GetConnectionString());
            var person1 = customers.GetById(10);
            Console.WriteLine(person1.firstName + " " + person1.lastName);
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

            var People = customers.GetListOfCustomerMostPopularGenre(12);
            Console.Write(People[0].customer.firstName+" "+ People[0].customer.lastName + " ");
            foreach (var person in People)
            {
                Console.Write(person.genre + " ");
            }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPersistenceAndAccess.Models;

namespace DataPersistenceAndAccess.DataAccess.Customers
{
    public interface ICustomerRepository : ICruRepository<Customer,int>
    {
        /// <summary>
        /// Retrieves a particular instance from the database by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Customer</returns>
        public Customer GetByName(string name);

        /// <summary>
        /// Retrieves limited list off instances with offset from the database.
        /// </summary>
        /// <returns>List<Customer></returns>
        public List<Customer> GetLimitedListWiithOffset(int limit,int offset);

        /// <summary>
        /// Retrieves list countries with amount Of customers for each country.
        /// </summary>
        /// <returns>List<CustomerCountry></returns>
        public List<CustomerCountry> GetListOfCountriesWithAmountOfCustomers();

        /// <summary>
        /// Retrieves list of customers who are the highest spenders.
        /// </summary>
        /// <returns>List<CustomerCountry></returns>
        public List<CustomerSpender> GetListOfHighestSpendingCustomers();

        /// <summary>
        /// Retrieves most popular genre of a given customer.
        /// </summary>
        /// <returns>List<CustomerGenre></returns>
        public List<CustomerGenre> GetListOfCustomerMostPopularGenre(int id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPersistenceAndAccess.Models;

namespace DataPersistenceAndAccess.Repositories.Customers
{
    public interface ICustomerRepository : ICrudRepository<Customer,int>
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistenceAndAccess.Models
{
    public readonly record struct CustomerSpender(Customer customer, decimal totalSpent);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistenceAndAccess.Models
{
    public readonly record struct CustomerCountry(string country, int numberOfCustomers);
}

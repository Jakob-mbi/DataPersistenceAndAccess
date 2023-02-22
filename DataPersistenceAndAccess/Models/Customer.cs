using DataPersistenceAndAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistenceAndAccess.Models
{
    public readonly record struct Customer(int customerId, string firstName, string lastName, string? country, string? postalCode, string? phone,string email);

   

}

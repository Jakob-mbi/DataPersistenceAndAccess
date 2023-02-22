using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistenceAndAccess.Models
{
    public readonly record struct CustomerGenre(Customer customer,List<string> genre);
}

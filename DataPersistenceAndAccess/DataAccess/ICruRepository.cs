using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistenceAndAccess.DataAccess
{
    public interface ICruRepository<T, ID>
    {
        /// <summary>
        /// Retrieves all instances from the database.
        /// </summary>
        /// <returns>List<T></returns>
        List<T> GetAll();

        /// <summary>
        /// Retrieves a particular instance from the database by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        T GetById(ID id);

        /// <summary>
        /// Inserts a new row into the database based on the paramter.
        /// </summary>
        /// <param name="obj"></param>
        void Add(T obj);

        /// <summary>
        /// Updates an existing row based on the provided parameters.
        /// </summary>
        /// <param name="obj"></param>
        void Update(T obj);
       
        
    }
}




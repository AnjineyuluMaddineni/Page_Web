using Page_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_BLL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
       Task< IEnumerable<T>> GetAllByAsync();

       Task< T> GetByIdByAsync(int id);

        Task AddByAsync(T item);

        void Update(T item);

        void Delete(T  item);

    }
}

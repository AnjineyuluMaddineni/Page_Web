using Page_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_BLL.Interfaces
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        public IQueryable<Employee> GetEmployeesByAddress(string Address);
        public IQueryable<Employee> GetEmployeesByName(string Name);

    }

}

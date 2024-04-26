using Microsoft.EntityFrameworkCore;
using Page_BLL.Interfaces;
using Page_DAL.Contexts;
using Page_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly MVCProjectDbContext _dbContext;
        public EmployeeRepository(MVCProjectDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeesByAddress(string Address)
        {
          return  _dbContext.Employees.Where(A=>A.Address == Address);
        }

        public IQueryable<Employee> GetEmployeesByName(string Name)
        {
            var res=_dbContext.Employees.Include(D=>D.department)
                .Where(N=>N.Name.ToLower().Contains(Name.ToLower()));
            return res;
        }
    }
}

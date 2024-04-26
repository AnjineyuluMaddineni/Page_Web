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
    public class DepartmentRepository :GenericRepository<Department>, IDepartmentRepository
    {
        private readonly MVCProjectDbContext _dbContext;
        public DepartmentRepository(MVCProjectDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Department> GetDepartmentsByName(string Name)
            {
                var res = _dbContext.Departments.Include(D => D.employees)
                    .Where(N => N.Name.ToLower().Contains(Name.ToLower()));
                return res;
            }
        } 
    }

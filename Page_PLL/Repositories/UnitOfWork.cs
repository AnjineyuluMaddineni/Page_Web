using Page_BLL.Interfaces;
using Page_DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly MVCProjectDbContext _dbContext;

        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        public UnitOfWork(MVCProjectDbContext dbContext) { 
              EmployeeRepository=new EmployeeRepository(dbContext);
             DepartmentRepository=new DepartmentRepository(dbContext);
            _dbContext = dbContext;
        }
        public async Task<int> CompeleteByAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            ((IDisposable)_dbContext).Dispose();
        }
    }
}

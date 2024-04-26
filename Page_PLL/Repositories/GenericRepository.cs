using Microsoft.EntityFrameworkCore;
using Page_BLL.Interfaces;
using Page_DAL.Contexts;
using Page_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MVCProjectDbContext _dbContext;
        public GenericRepository(MVCProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddByAsync(T item)
        {
            await _dbContext.AddAsync(item);
           
        }

        public void Delete(T item)
        {
            _dbContext.Remove(item);
            
        }

        public async Task<IEnumerable<T>>GetAllByAsync()
        {
            if(typeof(T)==typeof(Employee))
             return (IEnumerable<T>) await _dbContext.Employees.Include(D=>D.department).ToListAsync(); 
            else return await _dbContext.Set<T>().ToListAsync(); 
        }

        public async Task<T> GetByIdByAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T item)
        {
            _dbContext.Update(item);
            
        }
    }
}

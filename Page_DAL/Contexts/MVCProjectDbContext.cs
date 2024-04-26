using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Page_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_DAL.Contexts
{
    public class MVCProjectDbContext:IdentityDbContext<ApplictionUser>
    {
        public MVCProjectDbContext(DbContextOptions<MVCProjectDbContext> options) : base(options) { 
            
        }
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer("Server=. ;Database=Mvcproject;Trusted_Connection=True");
       */
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }

}

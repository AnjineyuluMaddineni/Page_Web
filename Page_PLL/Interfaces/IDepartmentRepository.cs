﻿using Page_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_BLL.Interfaces
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
        public IQueryable<Department> GetDepartmentsByName(string Name);
    }
}

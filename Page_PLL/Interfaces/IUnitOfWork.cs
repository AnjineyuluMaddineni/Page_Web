﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public Task<int> CompeleteByAsync();
        public void Dispose();
    }
}

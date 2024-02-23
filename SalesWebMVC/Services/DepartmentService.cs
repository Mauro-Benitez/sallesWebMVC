using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {

        //banco de dados
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext dbcontext)
        {
            _context = dbcontext;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}

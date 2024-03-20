using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Department>> FindAllAsync()
        {
            return await  _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}

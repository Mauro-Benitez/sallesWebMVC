using SalesWebMVC.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        //banco de dados
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }


        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id )
        {
            var obj = _context.Seller.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();


        }
        public void Insert(Seller obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }


        public void Update (Seller updateSeller)
        {
            if(!_context.Seller.Any(x => x.Id == updateSeller.Id))
            {
                throw new NotFoundExceptions("Id não ecnotrado");
            }

            try
            {
                _context.Update(updateSeller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                new DbConcurrencyException(ex.Message);
            }

        }

    }
}

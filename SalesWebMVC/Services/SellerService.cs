using SalesWebMVC.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;
using System.Threading.Tasks;

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


        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id )
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Remove(obj);
           await _context.SaveChangesAsync();


        }
        public async Task InsertAsync(Seller obj)
        {
            
             _context.Add(obj);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync (Seller updateSeller)
        {
             bool temSeller = await _context.Seller.AnyAsync(x => x.Id == updateSeller.Id);

            if (!temSeller)
            {
                throw new NotFoundExceptions("Id não encontrado");
            }

            try
            {
                _context.Update(updateSeller);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                new DbConcurrencyException(ex.Message);
            }

        }

    }
}

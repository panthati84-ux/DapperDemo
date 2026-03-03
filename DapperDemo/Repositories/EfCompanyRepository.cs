using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDemo.Data;
using DapperDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DapperDemo.Repositories
{
    public class EfCompanyRepository : IEfCompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public EfCompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.AsNoTracking().ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<int> AddAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company.CompanyId;
        }

        public async Task<bool> UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity is null) return false;

            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
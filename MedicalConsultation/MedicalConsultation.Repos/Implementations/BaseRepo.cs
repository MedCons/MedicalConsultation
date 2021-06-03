using MedicalConsultation.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalConsultation.Repos.Implementations
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, new()
    {
        private readonly MedConsAdminContext _context;
        private readonly DbSet<T> _table = null;

        public BaseRepo(MedConsAdminContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public async Task<T> CreateAsync(T model)
        {
            _table.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(int? id)
        {
            T model = _table.Find(id);
            _table.Remove(model);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<T> GetAll()
        {
            return _table;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.Run(() => _table);
        }

        public async Task<T> GetAsync(int? id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T model)
        {
            _table.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }
    }
}

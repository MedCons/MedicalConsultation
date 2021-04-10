using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalConsultation.Repos.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetAsync(int? id);
        Task<T> UpdateAsync(T model);
        Task DeleteAsync(int? id);
        Task<T> CreateAsync(T model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_dataAtkomstlager
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T ettObjekt);
        Task <List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(T ettObjekt);
        Task<bool> DeleteAsync(string ettObjektId);
    }
}

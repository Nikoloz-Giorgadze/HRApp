using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDatabaseModels.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDomainCore.Abstractions
{
    public interface IRepository<T> where T : Base
    {
        Task<bool> CreateAsync(T item);
        Task<IEnumerable<T>> ReadAsync();
        Task<T> ReadByIdAsync(int id);
        Task<bool> UpdateAsync(int id, T item);
        Task<bool> DeleteAsync(int id);
        DbSet<T> Get();
        
    }
}

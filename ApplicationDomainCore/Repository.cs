using ApplicationDatabaseConnector.DB;
using ApplicationDatabaseModels.Models;
using ApplicationDomainCore.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomainCore
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        private readonly ApplicationDbcontext _db = default;
        private readonly DbSet<T> _entity = default;
        public Repository(ApplicationDbcontext db)

        {
            _db = db;
            _entity = _db.Set<T>();
        }
        public async Task<bool> CreateAsync(T item)
        {
            await _entity.AddAsync(item);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await ReadByIdAsync(id);
            _entity.Remove(item);
            return await SaveChangesAsync();
        }

        public DbSet<T> Get()
        {
            return _entity;
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> ReadByIdAsync(int id)
        {
            return await _entity.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> UpdateAsync(int id, T item)
        {
            item.Id = id;
            _entity.Update(item);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _db.SaveChangesAsync() >= 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}

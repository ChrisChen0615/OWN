using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OWN.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        //private readonly OWNDbContext _context;
        private readonly DbSet<T> entities;
        public RepositoryBase(OWNDbContext context)
        {
            //_context = context;
            entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            var data = entities.AsQueryable();
            return data;
        }

        public async Task<List<T>> GetAllListAsync()
        {
            var data = await entities.ToListAsync();
            return data;
        }

        public async Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> predicate)
        {
            var data = await GetAll().Where(predicate).ToListAsync();
            return data;
        }
    }
}

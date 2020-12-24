using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OWN.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly OWNDbContext _context;
        private readonly DbSet<T> entities;
        public RepositoryBase(OWNDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public async Task<IList<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
    }
}

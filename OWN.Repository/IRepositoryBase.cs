using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OWN.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        //T Get(int id);
        Task<IList<T>> GetAll();

        //IQueryable<T> FindAll();
        //IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        //void Create(T entity);
        //void Update(T entity);
        //void Delete(T entity);
    }
}

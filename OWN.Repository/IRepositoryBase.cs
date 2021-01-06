using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWN.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        //T Get(int id);
        IQueryable<T> GetAll();

        //Task<IList<T>> GetAllList();
        //IQueryable<T> FindAll();
        //IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        //void Create(T entity);
        //void Update(T entity);
        //void Delete(T entity);
    }
}

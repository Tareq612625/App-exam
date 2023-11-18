using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App_Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        T SelectById(int id);

        IEnumerable<T> SelectAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        IEnumerable<T> SelectAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);




        void Insert(T entity);
        void InsertAll(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateAll(IEnumerable<T> entities);

        void Delete(T entity);
        void DeleteAll(IEnumerable<T> entities);
    }
}

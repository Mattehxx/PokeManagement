using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public interface IManager<T> where T : class
    {
        public IQueryable<T> GetAll();
        public T? GetById(int id);
        public T Create(T entity);
        public T Update(T entity);
        public void DeleteById(int id);
        public IQueryable<T> Filter(Expression<Func<T, bool>> filter);
    }
}

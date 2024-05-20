using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    internal class GenericManager<T> : IManager<T> where T : class
    {
        public T Create(T entity, out bool isSuccessful)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity, out bool isSuccessful)
        {
            throw new NotImplementedException();
        }
    }
}

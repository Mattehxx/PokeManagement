using Microsoft.EntityFrameworkCore;
using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public class GenericManager<T> : IManager<T> where T : class
    {
        protected readonly PokeDbContext _ctx;
        protected readonly DbSet<T> _dbSet;
        public GenericManager(PokeDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<T>();
        }
        public IQueryable<T> GetAll() => _dbSet;
        public T? GetById(int id) => _dbSet.Find(id);
        public T Create(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
        public T Update(T entity)
        {
            //_dbSet.Attach(entity);
            //_dbSet.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
            return entity;
        }
        public bool DeleteById(int id)
        {
            T? entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return _ctx.SaveChanges() > 0;
            }
            return false;
        }
        public IQueryable<T> Filter(Expression<Func<T, bool>> filter) => _dbSet.Where(filter);






    }
}

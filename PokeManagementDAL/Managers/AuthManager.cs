using Microsoft.EntityFrameworkCore;
using PokeManagementDAL.Auth;
using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public class AuthManager : IAuthManager
    {
        protected readonly PokeDbContext _ctx;
        protected readonly DbSet<ApplicationUser> _dbSet;
        public AuthManager(PokeDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<ApplicationUser>();
        }

        public IQueryable<ApplicationUser> GetAll() => _dbSet;

        public ApplicationUser? GetById(string id) => _dbSet.Find(id);

        public ApplicationUser Create(ApplicationUser entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public ApplicationUser Update(ApplicationUser entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}

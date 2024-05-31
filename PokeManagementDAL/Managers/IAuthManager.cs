using PokeManagementDAL.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public interface IAuthManager
    {
        public IQueryable<ApplicationUser> GetAll();
        public ApplicationUser? GetById(string id);
        public ApplicationUser Create(ApplicationUser entity);
        public ApplicationUser Update(ApplicationUser entity);
    }
}

using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public class IngredientManager(PokeDbContext ctx) : GenericManager<Ingredient>(ctx), IIngredientManager
    {
        public void AddIngredient(Ingredient toAddIngredient)
        {
            throw new NotImplementedException();
        }

        public void AddIngredients(List<Ingredient> toAddIngredients)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ingredient> GetListDetails()
        {
            throw new NotImplementedException();
        }

        public void LogicalDelete(int ingredientId)
        {
            throw new NotImplementedException();
        }

        public void RemoveIngredient(int ingredientId)
        {
            throw new NotImplementedException();
        }

        public void RemoveIngredients(List<Ingredient> toRemoveIngredients)
        {
            throw new NotImplementedException();
        }
    }
}

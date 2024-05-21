using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public interface IIngredientManager : IManager<Ingredient>
    {
        //ADMIN
        public IQueryable<Ingredient> GetListDetails(); //lista ingredienti con dettaglio
        public void LogicalDelete(int ingredientId);
        public void AddIngredients(List<Ingredient> toAddIngredients);
        public void RemoveIngredients(List<Ingredient> toRemoveIngredients);
        public void AddIngredient(Ingredient toAddIngredient);
        public void RemoveIngredient(int ingredientId);

    }
}

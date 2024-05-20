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
        public bool LogicalDelete(int ingredientId);
        public bool AddIngredients(List<Ingredient> toAddIngredients);
        public bool RemoveIngredients(List<Ingredient> toRemoveIngredients);
        public bool AddIngredient(Ingredient toAddIngredient);
        public bool RemoveIngredient(int ingredientId);

    }
}

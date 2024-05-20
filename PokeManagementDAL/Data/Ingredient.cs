using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Data
{
    public  class Ingredient
    {
        public int IngredientId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }   
        public double AddictionalCost { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool Allegergen { get; set; }
        public double Calories {  get; set; }
        public bool IsDeleted { get; set; }
        public int Type {  get; set; } 
    }
}

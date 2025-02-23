﻿
using PokeManagement.Models.BasicModels;
using PokeManagementDAL.Data;
using System.ComponentModel.DataAnnotations;

namespace PokeManagement.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public int ProductTypeId { get; set; }
        public ProductTypeBasicModel? ProductType { get; set; }
        public List<OrderDetailBasicModel>? OrderDetails { get; set; }
        public List<ProductIngredientBasicModel>? ProductIngredients { get; set; }
        //solo per il modello (default personalization) -> senza gli ingredienti presenti nel prodotto
        //public List<SpecificPersonalization>? specificPersonalizations { get; set; }
    }
}

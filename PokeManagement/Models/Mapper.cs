using Microsoft.IdentityModel.Tokens;
using PokeManagementDAL.Auth;
using PokeManagementDAL.Data;

namespace PokeManagement.Models
{
    public class Mapper
    {
        #region toEntity
        public Product ToEntity(ProductModel model) => new Product
        {
            ProductId = model.Id,
            Name = model.Name,
            Description = model.Description,
            IsDeleted = false,
            Price = model.ProductIngredients?.Sum(pi=>pi.Amount * (pi.Ingredient != null ? pi.Ingredient.AddictionalCost : 0)) ?? 0,
            ProductTypeId = model.ProductTypeId,
            OrderDetails = model.OrderDetails?.ConvertAll(ToEntity),
            ProductType = ToEntity(model.ProductType),
            ProductIngredients = model.ProductIngredients?.ConvertAll(ToEntity)
        };
        public ProductType ToEntity(ProductTypeModel model) => new ProductType
        {
            ProductTypeId = model.Id,
            Description = model.Description,
            Products = model.Products?.ConvertAll(ToEntity)
        };
        public ProductIngredient ToEntity(ProductIngredientModel model) => new ProductIngredient
        {
            ProductIngredientId = model.Id,
            Amount = model.Amount,
            IngredientId = model.IngredientId,
            ProductId = model.ProductId,
            Ingredient = ToEntity(model.Ingredient!),
            Product = ToEntity(model.Product!)
        };
        public Personalization ToEntity(PersonalizationModel model) => new Personalization
        {
            PersonalizationId = model.Id,
            IsDeleted = false,
            DefaultPersonalizationId = model.DefaultPersonalizationId,
            OrderDetailId = model.OrderDetailId,
            OrderDetail = ToEntity(model.OrderDetail!),
            DefaultPersonalization = ToEntity(model.DefaultPersonalization!)
        };
        public OrderType ToEntity(OrderTypeModel model) => new OrderType
        {
            OrderTypeId = model.Id,
            Description = model.Description,
            Orders = model.Orders?.ConvertAll(ToEntity)
        };
        public Order ToEntity(OrderModel model) => new Order
        {
            OrderId = model.Id,
            InsertDate = model.InsertDate,
            IsCompleted = model.IsCompleted,
            ReservationCode = model.ReservationCode,
            IsDeleted = model.IsDeleted,
            MandatorId = model.MandatorId,
            OperatorId = model.OperatorId,
            OrderTypeId = model.OrderTypeId,
            Mandator = ToEntity(model.Mandator!),
            Operator = ToEntity(model.Operator!),
            OrderType = ToEntity(model.OrderType!)
        };
        public OrderDetail ToEntity(OrderDetailModel model) => new OrderDetail
        {
            OrderDetailId = model.Id,
            Amount = model.Amount,
            Price = model.Price,
            OrderdId = model.OrderdId,
            ProductId = model.ProductId,
            Order = ToEntity(model.Order!),
            Product = ToEntity(model.Product!),
            Personalizations = model.Personalizations?.ConvertAll(ToEntity)
        };
        public IngredientType ToEntity(IngredientTypeModel model) => new IngredientType
        {
            IngredientTypeId = model.Id,
            Description = model.Description,
            Ingredients = model.Ingredients?.ConvertAll(ToEntity)
        };
        public Ingredient ToEntity(IngredientModel model) => new Ingredient
        {
            IngredientId = model.Id,
            AddictionalCost = model.AddictionalCost,
            Allegergen = model.Allegergen,
            Description = model.Description,
            Calories = model.Calories,
            Name = model.Name,
            IsDeleted = model.IsDeleted,
            IngredientTypeId = model.IngredientTypeId,
            IngredientType = ToEntity(model.IngredientType!)
        };
        public DefaultPersonalization ToEntity(DefaultPersonalizationModel model) => new DefaultPersonalization
        {
            DefaultPersonalizationId = model.Id,
            MaxAllowed = model.MaxAllowed,
            IngredientId = model.IngredientId,
            ProductId = model.ProductId,
            Ingredient = ToEntity(model.Ingredient),
            Personalizations = model.Personalizations?.ConvertAll(ToEntity),
            Product = ToEntity(model.Product)
        };
        public ApplicationUser ToEntity(ApplicationUserModel model) => new ApplicationUser
        {
            
        };
        #endregion


        #region toModel
        public ProductModel ToModel(Product entity) => new ProductModel
        {
            Id = entity.ProductId,
            Description = entity.Description,
            Name = entity.Name,
            Price = entity.Price,
            ProductTypeId = entity.ProductId,
            ProductType = ToModel(entity.ProductType!),
            OrderDetails = entity.OrderDetails?.ConvertAll(ToModel),
            ProductIngredients = entity.ProductIngredients?.ConvertAll(ToModel)
        };
        public ProductTypeModel ToModel(ProductType entity) => new ProductTypeModel
        {
            Id = entity.ProductTypeId,
            Description = entity.Description,
            Products = entity.Products?.ConvertAll(ToModel)
        };
        public ProductIngredientModel ToModel(ProductIngredient entity) => new ProductIngredientModel
        {
            Id = entity.ProductIngredientId,
            Amount = entity.Amount,
            IngredientId = entity.IngredientId,
            ProductId = entity.ProductId,
            Ingredient = ToModel(entity.Ingredient!),
            Product = ToModel(entity.Product!)
        };
        public PersonalizationModel ToModel(Personalization entity) => new PersonalizationModel
        {
            Id = entity.PersonalizationId,
            IsDeleted = entity.IsDeleted,
            DefaultPersonalizationId = entity.DefaultPersonalizationId,
            OrderDetailId = entity.OrderDetailId,
            OrderDetail = ToModel(entity.OrderDetail!),
            DefaultPersonalization = ToModel(entity.DefaultPersonalization)
        };
        public OrderTypeModel ToModel(OrderType entity) => new OrderTypeModel
        {
            Id = entity.OrderTypeId,
            Description = entity.Description,
            Orders = entity.Orders?.ConvertAll(ToModel)
        };
        public OrderModel ToModel(Order entity) => new OrderModel
        {
            Id = entity.OrderId,
            InsertDate = entity.InsertDate,
            IsCompleted = entity.IsCompleted,
            ReservationCode = entity.ReservationCode,
            IsDeleted = entity.IsDeleted,
            MandatorId = entity.MandatorId,
            OperatorId = entity.OperatorId,
            OrderTypeId = entity.OrderTypeId,
            Mandator = ToModel(entity.Mandator!),
            Operator = ToModel(entity.Operator!),
            OrderType = ToModel(entity.OrderType!)
        };
        public OrderDetailModel ToModel(OrderDetail entity) => new OrderDetailModel
        {
            Id = entity.OrderDetailId,
            Amount = entity.Amount,
            Price = entity.Price,
            ProductId = entity.ProductId,
            OrderdId = entity.OrderdId,
            Order = ToModel(entity.Order!),
            Product = ToModel(entity.Product!),
            Personalizations = entity.Personalizations?.ConvertAll(ToModel)
        };
        public IngredientTypeModel ToModel(IngredientType entity) => new IngredientTypeModel
        {
            Id = entity.IngredientTypeId,
            Description = entity.Description,
            Ingredients = entity.Ingredients?.ConvertAll(ToModel)
        };
        public IngredientModel ToModel(Ingredient entity) => new IngredientModel
        {
            Id = entity.IngredientId,
            AddictionalCost = entity.AddictionalCost,
            Allegergen = entity.Allegergen,
            Description = entity.Description,
            IsDeleted = entity.IsDeleted,
            Calories = entity.Calories,
            Name = entity.Name,
            IngredientTypeId = entity.IngredientTypeId,
            IngredientType = ToModel(entity.IngredientType!)
        };
        public ApplicationUserModel ToModel(ApplicationUser entity) => new ApplicationUserModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            Email = entity.Email!,
            MandatorOrders = entity.MandatorOrders?.ConvertAll(ToModel),
            OperatorOrders = entity.OperatorOrders?.ConvertAll(ToModel)
        };
        public DefaultPersonalizationModel ToModel(DefaultPersonalization entity) => new DefaultPersonalizationModel
        {
            Id = entity.DefaultPersonalizationId,
            MaxAllowed = entity.MaxAllowed,
            ProductId = entity.ProductId,
            IngredientId = entity.IngredientId,
            Ingredient = ToModel(entity.Ingredient),
            Product = ToModel(entity.Product),
            Personalizations = entity.Personalizations?.ConvertAll(ToModel)
        };
        
        #endregion
    }
}

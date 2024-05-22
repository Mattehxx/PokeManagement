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
            ProductType = model.ProductType != null ? ToEntity(model.ProductType) : null,
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
            MaxAllowed = model.MaxAllowed,
            IsIncluded = model.IsIncluded,
            Personalizations = model.Personalizations?.ConvertAll(ToEntity),
            Ingredient = model.Ingredient != null ? ToEntity(model.Ingredient) : null,
            Product = model.Product != null ? ToEntity(model.Product) : null
        };
        public Personalization ToEntity(PersonalizationModel model) => new Personalization
        {
            PersonalizationId = model.Id,
            IsRemoved = model.IsRemoved,
            OrderDetailId = model.OrderDetailId,
            ProductIngredientId = model.ProductIngredientId,
            OrderDetail = ToEntity(model.OrderDetail!),
            ProductIngredient = model.ProductIngredient != null ? ToEntity(model.ProductIngredient) : null
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
            ExecDate = model.ExecDate,
            Mandator = model.Mandator != null ? ToEntity(model.Mandator) : null,
            Operator = model.Operator != null ? ToEntity(model.Operator) : null,
            OrderType = model.OrderType != null ? ToEntity(model.OrderType) : null
        };
        public OrderDetail ToEntity(OrderDetailModel model) => new OrderDetail
        {
            OrderDetailId = model.Id,
            Amount = model.Amount,
            Price = model.Price,
            OrderdId = model.OrderdId,
            ProductId = model.ProductId,
            Order = model.Order != null ? ToEntity(model.Order) : null,
            Product = model.Product != null ? ToEntity(model.Product) : null,
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
            IngredientType = model.IngredientType != null ? ToEntity(model.IngredientType) : null,
            ProductIngredients = model.ProductIngredients?.ConvertAll(ToEntity)
        };
        //public DefaultPersonalization ToEntity(DefaultPersonalizationModel model) => new DefaultPersonalization
        //{
        //    DefaultPersonalizationId = model.Id,
        //    MaxAllowed = model.MaxAllowed,
        //    IngredientId = model.IngredientId,
        //    ProductId = model.ProductId,
        //    Ingredient = ToEntity(model.Ingredient),
        //    Personalizations = model.Personalizations?.ConvertAll(ToEntity),
        //    Product = ToEntity(model.Product)
        //};
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
            
            //specificPersonalizations = entity.DefaultPersonalizations? //finire
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
            MaxAllowed = entity.MaxAllowed,
            IsIncluded = entity.IsIncluded,
            IngredientId = entity.IngredientId,
            ProductId = entity.ProductId,
            Ingredient = entity.Ingredient != null ? ToModel(entity.Ingredient) : null,
            Product = entity.Product != null ? ToModel(entity.Product) : null,
            Personalizations = entity.Personalizations?.ConvertAll(ToModel)
        };
        public PersonalizationModel ToModel(Personalization entity) => new PersonalizationModel
        {
            Id = entity.PersonalizationId,
            IsRemoved = entity.IsRemoved,
            ProductIngredientId = entity.ProductIngredientId,
            OrderDetailId = entity.OrderDetailId,
            OrderDetail =entity.OrderDetail != null ? ToModel(entity.OrderDetail) : null,
            ProductIngredient = entity.ProductIngredient != null ? ToModel(entity.ProductIngredient) : null
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
            ExecDate = entity.ExecDate,
            MandatorId = entity.MandatorId,
            OperatorId = entity.OperatorId,
            OrderTypeId = entity.OrderTypeId,
            Mandator = entity.Mandator != null ? ToModel(entity.Mandator) : null,
            Operator = entity.Operator != null ? ToModel(entity.Operator) : null,
            OrderType = entity.OrderType != null ? ToModel(entity.OrderType) : null
        };
        public OrderDetailModel ToModel(OrderDetail entity) => new OrderDetailModel
        {
            Id = entity.OrderDetailId,
            Amount = entity.Amount,
            Price = entity.Price,
            ProductId = entity.ProductId,
            OrderdId = entity.OrderdId,
            Order = entity.Order != null ? ToModel(entity.Order) : null,
            Product = entity.Product != null ? ToModel(entity.Product) : null,
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
            IngredientType = entity.IngredientType != null ? ToModel(entity.IngredientType) : null,
            ProductIngredients = entity.ProductIngredients?.ConvertAll(ToModel)
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
        //public DefaultPersonalizationModel ToModel(DefaultPersonalization entity) => new DefaultPersonalizationModel
        //{
        //    Id = entity.DefaultPersonalizationId,
        //    MaxAllowed = entity.MaxAllowed,
        //    ProductId = entity.ProductId,
        //    IngredientId = entity.IngredientId,
        //    Ingredient = ToModel(entity.Ingredient),
        //    Product = ToModel(entity.Product),
        //    Personalizations = entity.Personalizations?.ConvertAll(ToModel)
        //};
        
        #endregion
    }
}

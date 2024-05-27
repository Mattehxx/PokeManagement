using Microsoft.IdentityModel.Tokens;
using PokeManagement.Models.BasicModels;
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
            //Price = 
            //Price = model.ProductIngredients?.Sum(pi=>pi.Amount * (pi.Ingredient != null ? pi.Ingredient.AdditionalCost : 0)) ?? 0,
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
            Amount = model.Amount,
            OrderDetailId = model.OrderDetailId,
            ProductIngredientId = model.ProductIngredientId,
            OrderDetail = model.OrderDetail != null ? ToEntity(model.OrderDetail) : null,
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
            //ReservationCode = model.ReservationCode,
            ReservationCode = ReservationCode.New().ToString(),
            IsDeleted = model.IsDeleted,
            MandatorId = model.MandatorId,
            OperatorId = model.OperatorId,
            OrderTypeId = model.OrderTypeId,
            ExecDate = model.ExecDate,
            Mandator = model.Mandator != null ? ToEntity(model.Mandator) : null,
            Operator = model.Operator != null ? ToEntity(model.Operator) : null,
            OrderType = model.OrderType != null ? ToEntity(model.OrderType) : null,
            Details = model.Details.ConvertAll(ToEntity)
        };
        public OrderDetail ToEntity(OrderDetailModel model) => new OrderDetail
        {
            OrderDetailId = model.Id,
            Amount = model.Amount,
            Price = model.Price,
            OrderId = model.OrderId,
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
            AdditionalCost = model.AdditionalCost,
            Allergen = model.Allergen,
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
            IsDeleted = entity.IsDeleted,
            ProductTypeId = entity.ProductTypeId,
            ProductType = entity.ProductType != null ? ToBasicModel(entity.ProductType) : null,
            OrderDetails = entity.OrderDetails?.ConvertAll(ToBasicModel),
            ProductIngredients = entity.ProductIngredients?.ConvertAll(ToBasicModel)
            
            //specificPersonalizations = entity.DefaultPersonalizations? //finire
        };
        public ProductTypeModel ToModel(ProductType entity) => new ProductTypeModel
        {
            Id = entity.ProductTypeId,
            Description = entity.Description,
            Products = entity.Products?.ConvertAll(ToBasicModel)
        };
        public ProductIngredientModel ToModel(ProductIngredient entity) => new ProductIngredientModel
        {
            Id = entity.ProductIngredientId,
            Amount = entity.Amount,
            MaxAllowed = entity.MaxAllowed,
            IsIncluded = entity.IsIncluded,
            IngredientId = entity.IngredientId,
            ProductId = entity.ProductId,
            Ingredient = entity.Ingredient != null ? ToBasicModel(entity.Ingredient) : null,
            Product = entity.Product != null ? ToBasicModel(entity.Product) : null,
            Personalizations = entity.Personalizations?.ConvertAll(ToBasicModel)
        };
        public PersonalizationModel ToModel(Personalization entity) => new PersonalizationModel
        {
            Id = entity.PersonalizationId,
            Amount = entity.Amount,
            ProductIngredientId = entity.ProductIngredientId,
            OrderDetailId = entity.OrderDetailId,
            OrderDetail =entity.OrderDetail != null ? ToBasicModel(entity.OrderDetail) : null,
            ProductIngredient = entity.ProductIngredient != null ? ToBasicModel(entity.ProductIngredient) : null
        };
        public OrderTypeModel ToModel(OrderType entity) => new OrderTypeModel
        {
            Id = entity.OrderTypeId,
            Description = entity.Description,
            Orders = entity.Orders?.ConvertAll(ToBasicModel)
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
            OrderType = entity.OrderType != null ? ToBasicModel(entity.OrderType) : null,
            Details = entity.Details.ConvertAll(ToBasicModel)
        };
        public OrderDetailModel ToModel(OrderDetail entity) => new OrderDetailModel
        {
            Id = entity.OrderDetailId,
            Amount = entity.Amount,
            Price = entity.Price,
            ProductId = entity.ProductId,
            OrderId = entity.OrderId,
            Order = entity.Order != null ? ToBasicModel(entity.Order) : null,
            Product = entity.Product != null ? ToBasicModel(entity.Product) : null,
            Personalizations = entity.Personalizations?.ConvertAll(ToBasicModel)
        };
        public IngredientTypeModel ToModel(IngredientType entity) => new IngredientTypeModel
        {
            Id = entity.IngredientTypeId,
            Description = entity.Description,
            Ingredients = entity.Ingredients?.ConvertAll(ToBasicModel)
        };
        public IngredientModel ToModel(Ingredient entity) => new IngredientModel
        {
            Id = entity.IngredientId,
            AdditionalCost = entity.AdditionalCost,
            Allergen = entity.Allergen,
            Description = entity.Description,
            IsDeleted = entity.IsDeleted,
            Calories = entity.Calories,
            Name = entity.Name,
            IngredientTypeId = entity.IngredientTypeId,
            IngredientType = entity.IngredientType != null ? ToBasicModel(entity.IngredientType) : null,
            ProductIngredients = entity.ProductIngredients?.ConvertAll(ToBasicModel)
        };
        public ApplicationUserModel ToModel(ApplicationUser entity) => new ApplicationUserModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            Email = entity.Email!,
            MandatorOrders = entity.MandatorOrders?.ConvertAll(ToBasicModel),
            OperatorOrders = entity.OperatorOrders?.ConvertAll(ToBasicModel)
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

        #region toBasicModel
        public ProductBasicModel ToBasicModel(Product entity) => new ProductBasicModel
        {
            Id = entity.ProductId,
            Description = entity.Description,
            Name = entity.Name,
            Price = entity.Price,
            IsDeleted = entity.IsDeleted
        };
        public ProductTypeBasicModel ToBasicModel(ProductType entity) => new ProductTypeBasicModel
        {
            Id = entity.ProductTypeId,
            Description = entity.Description
        };
        public ProductIngredientBasicModel ToBasicModel(ProductIngredient entity) => new ProductIngredientBasicModel
        {
            Id = entity.ProductIngredientId,
            Amount = entity.Amount,
            IsIncluded = entity.IsIncluded,
            MaxAllowed = entity.MaxAllowed,
            IngredientId = entity.IngredientId,
            ProductId = entity.ProductId,
            IngredientName = entity.Ingredient?.Name ?? string.Empty,
            IngredientPrice = entity.Ingredient == null ? 0 : entity.Ingredient.AdditionalCost
        };
        public PersonalizationBasicModel ToBasicModel(Personalization entity) => new PersonalizationBasicModel
        {
            Id = entity.PersonalizationId,
            Amount = entity.Amount,
            ProductIngredientId = entity.ProductIngredientId,
            ProductIngredient = entity.ProductIngredient != null ? ToBasicModel(entity.ProductIngredient) : null,
        };
        public OrderBasicModel ToBasicModel(Order entity) => new OrderBasicModel
        {
            Id = entity.OrderId,
            ExecDate = entity.ExecDate,
            InsertDate = entity.InsertDate,
            ReservationCode = entity.ReservationCode,
            IsCompleted = entity.IsCompleted,
            IsDeleted = entity.IsDeleted
        };
        public OrderDetailBasicModel ToBasicModel(OrderDetail entity) => new OrderDetailBasicModel
        {
            Id = entity.OrderDetailId,
            Amount = entity.Amount,
            Price = entity.Price,
            ProductId = entity.ProductId,
            OrderId = entity.OrderId,
            Product = entity.Product != null ? ToBasicModel(entity.Product) : null,
            Personalizations = entity.Personalizations?.ConvertAll(ToBasicModel)
        };
        public OrderTypeBasicModel ToBasicModel(OrderType entity) => new OrderTypeBasicModel
        {
            Id = entity.OrderTypeId,
            Description = entity.Description
        };
        public IngredientBasicModel ToBasicModel(Ingredient entity) => new IngredientBasicModel
        {
            Id = entity.IngredientId,
            Description = entity.Description,
            Allergen = entity.Allergen,
            Calories = entity.Calories,
            Name = entity.Name,
            AdditionalCost = entity.AdditionalCost,
            IsDeleted= entity.IsDeleted
        };
        public IngredientTypeBasicModel ToBasicModel(IngredientType entity) => new IngredientTypeBasicModel
        {
            Id = entity.IngredientTypeId,
            Description = entity.Description
        };
        #endregion

        #region toEntity - from BasicModel
        public Product ToEntity(ProductBasicModel model) => new Product
        {
            ProductId = model.Id,
            Name = model.Name,
            Description = model.Description,
            IsDeleted = false
        };
        public ProductType ToEntity(ProductTypeBasicModel model) => new ProductType
        {
            ProductTypeId = model.Id,
            Description = model.Description
        };
        public ProductIngredient ToEntity(ProductIngredientBasicModel model) => new ProductIngredient
        {
            ProductIngredientId = model.Id,
            Amount = model.Amount,
            MaxAllowed = model.MaxAllowed,
            IsIncluded = model.IsIncluded,
            IngredientId = model.IngredientId,
            ProductId = model.ProductId
        };
        public Personalization ToEntity(PersonalizationBasicModel model) => new Personalization
        {
            PersonalizationId = model.Id,
            Amount = model.Amount,
            ProductIngredientId = model.ProductIngredientId

        };
        public OrderType ToEntity(OrderTypeBasicModel model) => new OrderType
        {
            OrderTypeId = model.Id,
            Description = model.Description
        };
        public Order ToEntity(OrderBasicModel model) => new Order
        {
            OrderId = model.Id,
            InsertDate = model.InsertDate,
            IsCompleted = model.IsCompleted,
            //ReservationCode = model.ReservationCode,
            ReservationCode = ReservationCode.New().ToString(),
            IsDeleted = model.IsDeleted,
            ExecDate = model.ExecDate
        };
        public OrderDetail ToEntity(OrderDetailBasicModel model) => new OrderDetail
        {
            OrderDetailId = model.Id,
            Amount = model.Amount,
            Price = model.Price,
            OrderId = model.OrderId,
            ProductId = model.ProductId,
            Personalizations = model.Personalizations.ConvertAll(ToEntity)
        };
        public IngredientType ToEntity(IngredientTypeBasicModel model) => new IngredientType
        {
            IngredientTypeId = model.Id,
            Description = model.Description
        };
        public Ingredient ToEntity(IngredientBasicModel model) => new Ingredient
        {
            IngredientId = model.Id,
            AdditionalCost = model.AdditionalCost,
            Allergen = model.Allergen,
            Description = model.Description,
            Calories = model.Calories,
            Name = model.Name,
            IsDeleted = model.IsDeleted
        };
        
        #endregion
    }
}

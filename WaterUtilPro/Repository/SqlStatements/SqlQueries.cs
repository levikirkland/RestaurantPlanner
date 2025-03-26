namespace WaterUtilPro.Repository.SqlStatements
{
    public class SqlQueries
    {
        public class Accounts
        {
            public const string GetById = "SELECT Id,CompanyName,FirstName,LastName,EmailAddress,Phone,Address1,Address2,City,State,Zipcode,AccountType,DeactivationDate,SignUpDate,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy,IsActive FROM restaurantplanner.dbo.Accounts WHERE Id = @Id";
            public const string IsUniqueEmail = "SELECT Top 1 Count(EmailAddress) FROM restaurantplanner.dbo.Accounts WHERE and EmailAddress = @emailAddress";
            public const string IsUniqueByAccountAndEmailAddress = "SELECT Top 1 Count(EmailAddress) FROM restaurantplanner.dbo.Accounts WHERE AccountId = @Id and EmailAddress = @emailAddress";
        }

        public class Category
        {
            public const string GetAll = "SELECT Id, Name, Description FROM restaurantplanner.dbo.Category";
        }

        public class Inventory
        {
            public const string GetAll = "SELECT Id, Name FROM restaurantplanner.dbo.Inventory";
            public const string GetById = "SELECT Id,Name ,CategoryId,Location,QtyInStock,ReorderQty,UnitCost,ReStockDate,ImageUrl,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy,IsActive,UnitOfMeasureId,Description FROM restaurantplanner.dbo.Inventory WHERE Id = @id";
            public const string GetInventoryDetailsById = "Select i.Id,i.Name,u.Name as UnitOfMeasure,i.Description,c.Name as Category,i.Location,i.QtyInStock,i.ReorderQty,i.UnitCost,i.ReStockDate,i.ImageUrl,i.IsActive from restaurantplanner.dbo.Inventory i join restaurantplanner.dbo.Category c on i.CategoryId = c.Id join restaurantplanner.dbo.UnitOfMeasure u on i.UnitOfMeasureId = u.Id WHERE i.Id = @Id";
            public const string GetAllInventoryDetails = "Select i.Id,i.Name,u.Name as UnitOfMeasure,i.Description,c.Name as Category,i.Location,i.QtyInStock,i.ReorderQty,i.UnitCost,i.ReStockDate,i.ImageUrl,i.IsActive, Coalesce(o.Quantity,0) as OrderQuantity\r\n from restaurantplanner.dbo.Inventory i left join restaurantplanner.dbo.Category c on i.CategoryId = c.Id left join restaurantplanner.dbo.UnitOfMeasure u on i.UnitOfMeasureId = u.Id left join restaurantplanner.dbo.Orders o on o.InventoryId = i.Id and o.PurchaseDate is null and o.CancelDate is null";
        }

        public class UnitOfMeasure
        {
            public const string GetAll = "SELECT Id, Name, Description FROM restaurantplanner.dbo.UnitOfMeasure";
        }

        public class Vendors
        {
            public const string GetAll = "SELECT Id, Name, Description, Address, City, State, Postalcode,IsActive,EmailAddress, Phone, Contact FROM restaurantplanner.dbo.Vendor";
            public const string GetById = "SELECT Id,Name, Description, Address, City, State, PostalCode, IsActive,EmailAddress, Phone, Contact FROM restaurantplanner.dbo.Vendor WHERE Id = @id";
        }

        public class Users
        {
            public const string GetUsers = "SELECT Id,FirstName,LastName,AccountInfoId,Active,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount  FROM restaurantplanner.dbo.[User]";
        }

        public class Orders
        {
            public const string GetOrdersDetails = "SELECT o.Id,i.name as InventoryName, i.id as InventoryId, v.name as VendorName, v.id as VendorId,o.Quantity,o.CreatedDate,o.ModifiedDate,o.CreatedBy,o.ModifiedBy,o.IsActive FROM restaurantplanner.dbo.Orders o join restaurantplanner.dbo.Inventory i on i.id = o.inventoryid join restaurantplanner.dbo.Vendor v on v.id = o.vendorid";
            public const string GetOrdersDetailsById = "SELECT o.Id,i.name as InventoryName, i.id as InventoryId, v.name as VendorName, v.id as VendorId,o.Quantity,o.CreatedDate,o.ModifiedDate,o.CreatedBy,o.ModifiedBy,o.IsActive FROM restaurantplanner.dbo.Orders o join restaurantplanner.dbo.Inventory i on i.id = o.inventoryid join restaurantplanner.dbo.Vendor v on v.id = o.vendorid where o.id = @id";
        }
    }
}
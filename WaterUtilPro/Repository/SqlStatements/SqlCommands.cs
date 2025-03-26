namespace WaterUtilPro.Repository.SqlStatements
{
    public class SqlCommands
    {

        public class Accounts
        {
            public const string InsertAccount = "(CompanyName,FirstName,LastName,EmailAddress,Phone,Address1,Address2,City,State,Zipcode,AccountType,DeactivationDate,SignUpDate,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy,IsActive)VALUES(@CompanyName,@FirstName,@LastName,@EmailAddress,@Phone,@Address1,@Address2,@City,@State,@Zipcode,@AccountType,@DeactivationDate,@SignUpDate,@CreatedDate,@ModifiedDate,@CreatedBy,@ModifiedBy,@IsActive)";
        }

        public class Category
        {

        }

        public class Inventory
        {
            public const string InsertInventory = "INSERT INTO dbo.Inventory(Name,CategoryId,Location,QtyInStock,ReorderQty,UnitCost,ReStockDate,ImageUrl,CreatedDate,CreatedBy,IsActive,UnitOfMeasureId,Description)VALUES(@Name,@CategoryId,@Location,@QtyInStock,@ReorderQty,@UnitCost,@ReStockDate,@ImageUrl,@CreatedDate,@CreatedBy,@IsActive,@UnitOfMeasureId,@Description)";
            public const string DeleteInventoryByIdAsync = "DELETE FROM restaurantplanner.dbo.Inventory WHERE Id = @id";
            public const string UpdateInventory = "UPDATE dbo.Inventory SET Name = @Name,CategoryId = @CategoryId,Location = @Location,QtyInStock = @QtyInStock,ReorderQty = @ReorderQty,UnitCost = @UnitCost,ReStockDate = @ReStockDate,ImageUrl = @ImageUrl,ModifiedDate = @ModifiedDate,ModifiedBy = @ModifiedBy,IsActive = @IsActive,UnitOfMeasureId = @UnitOfMeasureId,Description = @Description WHERE Id = @Id";
        }

        public class UnitOfMeasure
        {

        }

        public class Vendor
        {
            public const string InsertVendor = "INSERT INTO dbo.Vendor (Name ,Description ,Address ,City ,State ,PostalCode ,CreatedDate,CreatedBy, IsActive, Phone,Contact,EmailAddress) VALUES (@Name, @Description, @Address, @City, @State, @PostalCode, @CreatedDate, @CreatedBy, @IsActive, @Phone,@Contact,@EmailAddress)";
            public const string UpdateVendor = "UPDATE Vendor  SET Name = @Name ,Description = @Description ,Address = @Address ,City = @City ,State = @State ,PostalCode = @PostalCode ,ModifiedDate = @ModifiedDate ,ModifiedBy = @ModifiedBy ,IsActive = @IsActive ,EmailAddress = @EmailAddress ,Phone = @Phone ,Contact = @Contact WHERE Id = @Id";
        }
    }
}



CREATE PROCEDURE ProductInsert (@ProductName nvarchar(40), 
                                 @SupplierID int,
                                 @CategoryID int,
                                 @QuantityPerUnit nvarchar(20),
                                 @UnitPrice money,
                                 @UnitsInStock smallint,
                                 @UnitsOnOrder smallint,
                                 @ReorderLevel smallint)

AS
BEGIN
SET NOCOUNT ON;

INSERT INTO [dbo].[Products]
           ([ProductName]
           ,[SupplierID]
           ,[CategoryID]
           ,[QuantityPerUnit]
           ,[UnitPrice]
           ,[UnitsInStock]
           ,[UnitsOnOrder]
           ,[ReorderLevel])
     VALUES
           (@ProductName
           ,@SupplierID
           ,@CategoryID
           ,@QuantityPerUnit
           ,@UnitPrice
           ,@UnitsInStock
           ,@UnitsOnOrder
           ,@ReorderLevel)

END

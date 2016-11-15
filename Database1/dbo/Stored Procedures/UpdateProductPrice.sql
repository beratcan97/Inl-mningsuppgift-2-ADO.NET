CREATE PROCEDURE UpdateProductPrice(@ProductID int
                                   ,@UnitPrice money)
AS
BEGIN

	SET NOCOUNT ON

UPDATE [dbo].[Products]
   SET 
      [UnitPrice] = @UnitPrice

 WHERE [ProductID]=@ProductID

 END

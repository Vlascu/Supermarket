CREATE PROCEDURE DeleteProduct
    @product_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Products
    WHERE ProductID = @product_id;
END
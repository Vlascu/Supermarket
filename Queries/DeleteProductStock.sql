CREATE PROCEDURE DeleteProductStock
    @product_stock_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM ProductStocks
    WHERE ProductStockID = @product_stock_id;
END
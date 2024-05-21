CREATE PROCEDURE GetStockPurchasePrice
    @stock_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT PurchasePrice
    FROM ProductStock
    WHERE ProductStockID = @stock_id;
END
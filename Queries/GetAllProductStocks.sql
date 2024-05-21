CREATE PROCEDURE GetAllProductStocks
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductStockID, ProductID, Quantity, UnitOfMeasure, 
           DayOfSupply, MonthOfSupply, YearOfSupply, 
           DayOfExpiration, MonthOfExpiration, YearOfExpiration, 
           PurchasePrice, SalePrice
    FROM ProductStocks;
END
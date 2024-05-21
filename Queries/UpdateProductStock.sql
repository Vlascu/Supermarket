CREATE PROCEDURE UpdateProductStock
    @product_id INT,
    @quantity INT,
    @unit_of_measure NVARCHAR(50),
    @supply_day INT,
    @supply_month INT,
    @supply_year INT,
    @expiration_day INT,
    @expiration_month INT,
    @expiration_year INT,
    @purchase_price DECIMAL(18, 2),
    @sale_price DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ProductStocks
    SET 
        Quantity = @quantity,
        UnitOfMeasure = @unit_of_measure,
        DayOfSupply = @supply_day,
        MonthOfSupply = @supply_month,
        YearOfSupply = @supply_year,
        DayOfExpiration = @expiration_day,
        MonthOfExpiration = @expiration_month,
        YearOfExpiration = @expiration_year,
        PurchasePrice = @purchase_price,
        SalePrice = @sale_price
    WHERE ProductID = @product_id;
END
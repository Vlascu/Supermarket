USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[GetStockId]    Script Date: 16.05.2024 22:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetStockId]
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

    SELECT ProductStockID
    FROM ProductStock
    WHERE 
        Quantity = @quantity
        AND UnitOfMeasure = @unit_of_measure
        AND DayOfSupply = @supply_day
        AND MonthOfSupply = @supply_month
        AND YearOfSupply = @supply_year
        AND DayOfExpiration = @expiration_day
        AND MonthOfExpiration = @expiration_month
        AND YearOfExpiration = @expiration_year
        AND PurchasePrice = @purchase_price
        AND SalePrice = @sale_price;
END
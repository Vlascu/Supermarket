USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[AddProductStock]    Script Date: 16.05.2024 22:39:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddProductStock]
    @product_id INT,
    @quantity INT,
    @price_per_product DECIMAL(18, 2),
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

    INSERT INTO ProductStock(ProductID, Quantity, PricePerProduct, UnitOfMeasure, 
                                DayOfSupply, MonthOfSupply, YearOfSupply, 
                                DayOfExpiration, MonthOfExpiration, YearOfExpiration, 
                                PurchasePrice, SalePrice)
    VALUES (@product_id, @quantity, @price_per_product, @unit_of_measure, 
            @supply_day, @supply_month, @supply_year, 
            @expiration_day, @expiration_month, @expiration_year, 
            @purchase_price, @sale_price);
END
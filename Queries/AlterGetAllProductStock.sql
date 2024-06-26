USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductStocks]    Script Date: 16.05.2024 22:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllProductStocks]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductStockID, ProductID, Quantity, UnitOfMeasure, 
           DayOfSupply, MonthOfSupply, YearOfSupply, 
           DayOfExpiration, MonthOfExpiration, YearOfExpiration, 
           PurchasePrice, SalePrice
    FROM ProductStock;
END
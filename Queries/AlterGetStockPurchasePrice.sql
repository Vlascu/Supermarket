USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[GetStockPurchasePrice]    Script Date: 16.05.2024 22:42:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetStockPurchasePrice]
    @stock_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT PurchasePrice
    FROM ProductStock
    WHERE ProductStockID = @stock_id;
END
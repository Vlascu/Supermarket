USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductStock]    Script Date: 16.05.2024 22:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteProductStock]
    @product_stock_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM ProductStock
    WHERE ProductStockID = @product_stock_id;
END
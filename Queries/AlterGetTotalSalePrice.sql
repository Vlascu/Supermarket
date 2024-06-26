USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[GetTotalSalePrice]    Script Date: 16.05.2024 22:42:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetTotalSalePrice]
    @category_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT SUM(s.SalePrice) AS total_sale_price
    FROM Products p
    JOIN ProductStock s ON p.ProductID = s.ProductID
    WHERE p.CategoryID= @category_id;
END
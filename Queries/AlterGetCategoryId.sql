USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryId]    Script Date: 16.05.2024 22:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetCategoryId]
    @category_name NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CategoryID
    FROM ProductCategories
    WHERE CategoryName = @category_name;
END
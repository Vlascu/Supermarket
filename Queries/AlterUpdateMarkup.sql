USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateMarkup]    Script Date: 16.05.2024 22:43:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateMarkup]
    @markup_id INT,
    @markup_percentage INT,
    @markup_category INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Markups
    SET MarkupPercentage = @markup_percentage,
        MarkupCategory = @markup_category
    WHERE MarkupID = @markup_id;
END
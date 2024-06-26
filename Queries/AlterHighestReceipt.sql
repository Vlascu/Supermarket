USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[HighestReceipt]    Script Date: 16.05.2024 22:42:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[HighestReceipt]
    @day INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 *
    FROM Receipt
    WHERE DayOfIssuing = @day
    ORDER BY AmountReceived DESC;
END
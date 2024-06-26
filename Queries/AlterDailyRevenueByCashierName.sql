USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[DailyRevenueByCashierAndMonth]    Script Date: 16.05.2024 22:40:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DailyRevenueByCashierAndMonth]
    @cashier_name NVARCHAR(100),
    @month INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DayOfIssuing AS DayNumber, SUM(AmountReceived) AS TotalAmount
    FROM Receipt
    WHERE CashierName = @cashier_name
    AND MonthOfIssuing = @month
    GROUP BY DayOfIssuing;
END
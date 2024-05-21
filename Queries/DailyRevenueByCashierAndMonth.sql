CREATE PROCEDURE DailyRevenueByCashierAndMonth
    @cashier_name NVARCHAR(100),
    @month INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DayOfIssuing AS DayNumber, SUM(AmountReceived) AS TotalAmount
    FROM Receipts
    WHERE CashierName = @cashier_name
    AND MonthOfIssuing = @month
    GROUP BY DayOfIssuing;
END
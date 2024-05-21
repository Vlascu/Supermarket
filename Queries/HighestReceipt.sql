CREATE PROCEDURE HighestReceipt
    @day INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 *
    FROM Receipts
    WHERE DayOfIssuing = @day
    ORDER BY AmountReceived DESC;
END
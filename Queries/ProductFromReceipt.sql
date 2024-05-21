CREATE PROCEDURE ProductFromReceipt
    @receiptId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT p.*
    FROM Receipt_Products rp
    JOIN Products p ON rp.ProductId = p.ProductId
    WHERE rp.ReceiptId = @receiptId;
END
USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[ProductFromReceipt]    Script Date: 16.05.2024 22:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ProductFromReceipt]
    @receiptId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT p.*
    FROM Receipt_Product rp
    JOIN Products p ON rp.ProductId = p.ProductId
    WHERE rp.ReceiptId = @receiptId;
END
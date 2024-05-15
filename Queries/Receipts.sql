CREATE TABLE Receipts (
    ReceiptID INT IDENTITY(1,1) PRIMARY KEY,
    ReceiptProductId INT,
    MonthOfIssuing INT,
    DayOfIssuing INT,
    YearOfIssuing INT,
    CashierName NVARCHAR(100),
    AmountReceived DECIMAL(18, 2) 
);
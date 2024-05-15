CREATE TABLE Receipt_Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ReceiptId INT,
    ProductId INT,
    Quantity INT,
    Subtotal DECIMAL(18, 2) -- Adjust precision and scale as needed
);
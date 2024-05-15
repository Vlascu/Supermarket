CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL, -- Adjust size as needed
    Barcode INT,
    CategoryID INT,
    ManufacturerID INT
);
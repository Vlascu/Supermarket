CREATE TABLE ProductStock (
    ProductStockID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT,
    Quantity INT,
    UnitOfMeasure NVARCHAR(50),
    MonthOfSupply INT,
    DayOfSupply INT,
    YearOfSupply INT,
    MonthOfExpiration INT,
    DayOfExpiration INT,
    YearOfExpiration INT,
    PurchasePrice DECIMAL(18, 2),
    SalePrice DECIMAL(18, 2),
    PricePerProduct DECIMAL(18, 2)
);
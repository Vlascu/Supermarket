CREATE TABLE Offers (
    OfferID INT IDENTITY(1,1) PRIMARY KEY,
    Reason NVARCHAR(255), -- Adjust size as needed
    ProductID INT,
    DiscountPercentage DECIMAL(5, 2),
    ValidFrom DATETIME,
    ValidTo DATETIME
);
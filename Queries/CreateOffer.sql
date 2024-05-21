CREATE TABLE Offer (
    OfferID INT IDENTITY(1,1) PRIMARY KEY, -- Assuming OfferID is an identity column
    Reason NVARCHAR(MAX) NOT NULL,
    ProductID INT NOT NULL,
    DiscountPercentage FLOAT NOT NULL,
    ValidFromDay INT NOT NULL,
    ValidFromMonth INT NOT NULL,
    ValidFromYear INT NOT NULL,
    ValidToDay INT NOT NULL,
    ValidToMonth INT NOT NULL,
    ValidToYear INT NOT NULL,
    CONSTRAINT FK_Offer_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID) -- Assuming a Product table exists
);
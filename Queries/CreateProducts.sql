CREATE TABLE Products(
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(MAX) NOT NULL,
    Barcode INT NOT NULL,
    CategoryID INT NOT NULL,
    ManufacturerID INT NOT NULL,
    CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryID) REFERENCES ProductCategories(CategoryID),
    CONSTRAINT FK_Product_Manufacturer FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID) 
);
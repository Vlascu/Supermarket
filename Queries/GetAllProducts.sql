CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductName, ProductID, Barcode, CategoryID, ManufacturerID
    FROM Products;
END
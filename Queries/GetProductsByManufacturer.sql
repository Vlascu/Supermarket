CREATE PROCEDURE GetProductsByManufacturer
    @manufacturer_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductName, ProductID, Barcode, CategoryID, ManufacturerID
    FROM Products
    WHERE ManufacturerID = @manufacturer_id;
END
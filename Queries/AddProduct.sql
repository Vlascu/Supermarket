CREATE PROCEDURE AddProduct
    @product_name NVARCHAR(100),
    @barcode INT,
    @category_id INT,
    @manufacturer_id INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Products (ProductName, Barcode, CategoryID, ManufacturerID)
    VALUES (@product_name, @barcode, @category_id, @manufacturer_id);
END
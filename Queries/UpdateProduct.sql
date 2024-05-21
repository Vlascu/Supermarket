CREATE PROCEDURE UpdateProduct
    @product_id INT,
    @product_name NVARCHAR(100),
    @barcode INT,
    @category_id INT,
    @manufacturer_id INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
    SET ProductName = @product_name,
        Barcode = @barcode,
        CategoryID = @category_id,
        ManufacturerID = @manufacturer_id
    WHERE ProductID = @product_id;
END
CREATE PROCEDURE AddProductCategory
    @category_name NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ProductCategories (CategoryName)
    VALUES (@category_name);
END
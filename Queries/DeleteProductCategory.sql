CREATE PROCEDURE DeleteProductCategory
    @category_name NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM ProductCategories
    WHERE CategoryName = @category_name;
END
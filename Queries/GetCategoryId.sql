CREATE PROCEDURE GetCategoryId
    @category_name NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CategoryID
    FROM ProductCategories
    WHERE CategoryName = @category_name;
END
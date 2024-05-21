CREATE PROCEDURE GetAllProductCategories
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CategoryID, CategoryName
    FROM ProductCategories;
END
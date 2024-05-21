CREATE PROCEDURE GetMarkupsByCategory
    @category_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MarkupPercentage
    FROM Markups
    WHERE MarkupCategory = @category_id;
END
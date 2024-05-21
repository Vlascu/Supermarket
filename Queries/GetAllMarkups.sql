CREATE PROCEDURE GetAllMarkups
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MarkupID, MarkupPercentage, MarkupCategory
    FROM Markups;
END
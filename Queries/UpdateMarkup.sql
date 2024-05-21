CREATE PROCEDURE UpdateMarkup
    @markup_id INT,
    @markup_percentage INT,
    @markup_category INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Markups
    SET MarkupPercentage = @markup_percentage,
        MarkupCategory = @markup_category
    WHERE MarkupID = @markup_id;
END
CREATE PROCEDURE DeleteMarkup
    @markup_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Markups
    WHERE MarkupID = @markup_id;
END
CREATE PROCEDURE AddMarkup
    @markup_percentage INT,
    @markup_category INT,
    @markup_id INT OUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Markups (MarkupPercentage, MarkupCategory)
    VALUES (@markup_percentage, @markup_category);

    SET @markup_id = SCOPE_IDENTITY();
END
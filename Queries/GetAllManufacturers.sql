CREATE PROCEDURE GetAllManufacturers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ManufacturerID, Name, CountryOfOrigin
    FROM Manufacturers;
END
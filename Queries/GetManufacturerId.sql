CREATE PROCEDURE GetManufacturerId
    @manufacturer_name NVARCHAR(100),
    @manufacturer_country NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ManufacturerID
    FROM Manufacturers
    WHERE Name = @manufacturer_name
    AND CountryOfOrigin = @manufacturer_country;
END
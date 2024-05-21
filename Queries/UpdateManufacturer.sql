CREATE PROCEDURE UpdateManufacturer
    @manufacturer_id INT,
    @name NVARCHAR(100),
    @country_of_origin NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Manufacturers
    SET Name = @name,
        CountryOfOrigin = @country_of_origin
    WHERE ManufacturerID = @manufacturer_id;
END
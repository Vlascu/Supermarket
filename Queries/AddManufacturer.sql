CREATE PROCEDURE AddManufacturer
    @name NVARCHAR(100),
    @country_of_origin NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Manufacturers (Name, CountryOfOrigin)
    VALUES (@name, @country_of_origin);
END
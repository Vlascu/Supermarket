USE [SupermarketDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateManufacturer]    Script Date: 16.05.2024 22:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateManufacturer]
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
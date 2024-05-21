CREATE PROCEDURE AddOffer
    @reason NVARCHAR(MAX),
    @product_id INT,
    @discount_percentage FLOAT,
    @valid_from_day INT,
    @valid_from_month INT,
    @valid_from_year INT,
    @valid_to_day INT,
    @valid_to_month INT,
    @valid_to_year INT
AS
BEGIN
    INSERT INTO Offers(Reason, ProductID, DiscountPercentage, ValidFromDay, ValidFromMonth, ValidFromYear, ValidToDay, ValidToMonth, ValidToYear)
    VALUES (@reason, @product_id, @discount_percentage, @valid_from_day, @valid_from_month, @valid_from_year, @valid_to_day, @valid_to_month, @valid_to_year);
END
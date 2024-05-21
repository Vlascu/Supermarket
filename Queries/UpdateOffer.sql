CREATE PROCEDURE UpdateOffer
    @offer_id INT,
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
    UPDATE Offers
    SET Reason = @reason,
        ProductID = @product_id,
        DiscountPercentage = @discount_percentage,
        ValidFromDay = @valid_from_day,
        ValidFromMonth = @valid_from_month,
        ValidFromYear = @valid_from_year,
        ValidToDay = @valid_to_day,
        ValidToMonth = @valid_to_month,
        ValidToYear = @valid_to_year
    WHERE OfferID = @offer_id;
END
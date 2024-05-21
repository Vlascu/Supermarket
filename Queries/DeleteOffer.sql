CREATE PROCEDURE DeleteOffer
    @offer_id INT
AS
BEGIN
    DELETE FROM Offers WHERE OfferID = @offer_id;
END
CREATE PROCEDURE GetTotalSalePrice
    @category_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT SUM(s.SalePrice) AS total_sale_price
    FROM Products p
    JOIN ProductStock s ON p.ProductID = s.ProductID
    WHERE p.CategoryID= @category_id;
END
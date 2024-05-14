using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils.DataModels;
using SupermarketManager.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.DataAccessLayer
{
    public class CashierDAL
    {
        private SqlConnection conn;

        public CashierDAL() { conn = DALUtil.Connection; }

        public Product GetProduct(Product product)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter productIdParam = new SqlParameter("@product_id", product.ProductId);
                SqlParameter productNameParam = new SqlParameter("@product_name", product.ProductName);
                SqlParameter barcodeParam = new SqlParameter("@barcode", product.Barcode);
                SqlParameter categoryIdParam = new SqlParameter("@category_id", product.CategoryID);
                SqlParameter manufacturerIdParam = new SqlParameter("@manufacturer_id", product.ManufacturerID);

                cmd.Parameters.Add(productNameParam);
                cmd.Parameters.Add(productIdParam);
                cmd.Parameters.Add(barcodeParam);
                cmd.Parameters.Add(categoryIdParam);
                cmd.Parameters.Add(manufacturerIdParam);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Product foundProduct = new Product();

                    foundProduct.ProductId = reader.GetInt32(0);
                    foundProduct.ProductName = reader.GetString(0);
                    foundProduct.Barcode = reader.GetInt32(1);
                    foundProduct.CategoryID = reader.GetInt32(2);
                    foundProduct.ManufacturerID = reader.GetInt32(3);

                    return foundProduct;
                }
                else
                {
                    throw new SqlOperationException("Can't find product " + product.ProductName);
                }
            }
            catch (Exception ex)
            {
                throw new SqlOperationException("Something went wrong when trying to get a product.");
            }
            finally { conn.Close(); }
        }

        public decimal GetSelectedProductPrice(int productId, string productName, int wantedQuantity)
        {
            try
            {
                SortedSet<ProductStock> stocks = new SortedSet<ProductStock>(new ProductStockSorter());

                SqlCommand cmd = new SqlCommand("GetStocksOfProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter productIdParam = new SqlParameter("@product_id", productId);

                cmd.Parameters.Add(productIdParam);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductStock productStock = new ProductStock();

                    productStock.ProductStockID = reader.GetInt32(0);
                    productStock.ProductID = reader.GetInt32(1);
                    productStock.Quantity = reader.GetInt32(2);
                    productStock.UnitOfMeasure = reader.GetString(2);
                    productStock.DayOfSupply = reader.GetInt32(3);
                    productStock.MonthOfSupply = reader.GetInt32(4);
                    productStock.YearOfSupply = reader.GetInt32(5);
                    productStock.DayOfExpiration = reader.GetInt32(6);
                    productStock.MonthOfExpiration = reader.GetInt32(6);
                    productStock.YearOfExpiration = reader.GetInt32(7);
                    productStock.PurchasePrice = reader.GetDecimal(5);
                    productStock.SalePrice = reader.GetDecimal(6);

                    stocks.Add(productStock);
                }

                foreach (ProductStock productStock in stocks)
                {
                    decimal priceOnReceipt = (decimal)(wantedQuantity * productStock.PricePerProduct);

                    if (productStock.Quantity - wantedQuantity > 0)
                    {
                        productStock.Quantity -= wantedQuantity;

                        UpdateProductStock(productStock);

                        return priceOnReceipt;
                    }
                    else if (productStock.Quantity - wantedQuantity == 0)
                    {
                        productStock.Quantity -= wantedQuantity;

                        DeleteProductStock(productStock);

                        return priceOnReceipt;
                    }
                }
                throw new SqlOperationException("Insuffiecient stocks of product " + productName);
            }
            catch (Exception ex)
            {
                throw new SqlOperationException("Something went wrong when trying to get receipt price of product " + productName);
            }
            finally { conn.Close(); }
        }

        public void UpdateProductStock(ProductStock productStock)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateProductStock", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter stockId = new SqlParameter("@stock_id", productStock.ProductStockID) { Direction = ParameterDirection.Output };
                SqlParameter stockProductID = new SqlParameter("@product_id", productStock.ProductID);
                SqlParameter quantityParam = new SqlParameter("@quantity", productStock.Quantity);
                SqlParameter unitOfMeasureParam = new SqlParameter("@unit_of_measure", productStock.UnitOfMeasure);
                SqlParameter supplyDayParam = new SqlParameter("@supply_day", productStock.DayOfSupply);
                SqlParameter supplyMonthParam = new SqlParameter("@supply_month", productStock.MonthOfSupply);
                SqlParameter supplyYearParam = new SqlParameter("@supply_year", productStock.YearOfSupply);
                SqlParameter expirationDayParam = new SqlParameter("@expiration_day", productStock.DayOfExpiration);
                SqlParameter expirationMonthParam = new SqlParameter("@expiration_month", productStock.MonthOfExpiration);
                SqlParameter expirationYearParam = new SqlParameter("@expiration_year", productStock.YearOfExpiration);
                SqlParameter purchasePriceParam = new SqlParameter("@purchase_price", productStock.PurchasePrice);
                SqlParameter salePriceParam = new SqlParameter("@sale_price", productStock.SalePrice);


                cmd.Parameters.Add(stockProductID);
                cmd.Parameters.Add(quantityParam);
                cmd.Parameters.Add(unitOfMeasureParam);
                cmd.Parameters.Add(supplyDayParam);
                cmd.Parameters.Add(supplyMonthParam);
                cmd.Parameters.Add(supplyYearParam);
                cmd.Parameters.Add(expirationDayParam);
                cmd.Parameters.Add(expirationMonthParam);
                cmd.Parameters.Add(expirationYearParam);
                cmd.Parameters.Add(purchasePriceParam);
                cmd.Parameters.Add(salePriceParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                productStock.ProductStockID = (int)stockId.Value;
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to update product stock with ID " + productStock.ProductStockID);
            }
            finally { conn.Close(); }
        }

        public void DeleteProductStock(ProductStock productStock)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteProductStock", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter productStockIdParam = new SqlParameter("@product_stock_id", productStock.ProductStockID);
                cmd.Parameters.Add(productStockIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to delete product stock with ID " + productStock.ProductStockID);
            }
            finally { conn.Close(); }
        }

    }
}

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

                SqlParameter productNameParam = new SqlParameter("@product_name", product.ProductName);
                SqlParameter barcodeParam = new SqlParameter("@barcode", product.Barcode);
                SqlParameter categoryIdParam = new SqlParameter("@category_id", product.CategoryID);
                SqlParameter manufacturerIdParam = new SqlParameter("@manufacturer_id", product.ManufacturerID);

                cmd.Parameters.Add(productNameParam);
                cmd.Parameters.Add(barcodeParam);
                cmd.Parameters.Add(categoryIdParam);
                cmd.Parameters.Add(manufacturerIdParam);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Product foundProduct = new Product();

                    foundProduct.ProductId = reader.GetInt32(0);
                    foundProduct.ProductName = reader.GetString(1);
                    foundProduct.Barcode = reader.GetInt32(2);
                    foundProduct.CategoryID = reader.GetInt32(3);
                    foundProduct.ManufacturerID = reader.GetInt32(4);

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
                    stocks.Add(BuildProductStockFromReader(reader));
                }

                foreach (ProductStock productStock in stocks)
                {
                    decimal priceOnReceipt = (decimal)(wantedQuantity * productStock.PricePerProduct);

                    if (productStock.Quantity - wantedQuantity < 0)
                    {
                        continue;
                    }
                    else
                    {
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
        public void SellProduct(int productId, string productName, int wantedQuantity)
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
                    stocks.Add(BuildProductStockFromReader(reader));
                }

                reader.Close();

                bool sufficientStock = false;
                foreach (ProductStock productStock in stocks)
                {

                    if (productStock.Quantity - wantedQuantity > 0)
                    {
                        productStock.Quantity -= wantedQuantity;

                        sufficientStock = true;
                        UpdateProductStock(productStock);

                        break;
                    }
                    else if (productStock.Quantity - wantedQuantity == 0)
                    {
                        productStock.Quantity -= wantedQuantity;

                        sufficientStock = true;
                        DeleteProductStock(productStock);

                        break;
                    }
                }
                if (!sufficientStock)
                {
                    throw new SqlOperationException("Insuffiecient stocks of product " + productName);
                }
            }
            catch (Exception ex)
            {
                throw new SqlOperationException(ex.Message + ". Something went wrong when trying to get receipt price of product " + productName);
            }
            finally { conn.Close(); }
        }
        public void AddReceipt(Receipt receipt, List<ReceiptDetails> details)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("AddReceipt", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    command.Parameters.AddWithValue("@MonthOfIssuing", receipt.MonthOfIssuing);
                    command.Parameters.AddWithValue("@DayOfIssuing", receipt.DayOfIssuing);
                    command.Parameters.AddWithValue("@YearOfIssuing", receipt.YearOfIssuing);
                    command.Parameters.AddWithValue("@CashierName", receipt.CashierName);
                    command.Parameters.AddWithValue("@AmountReceived", receipt.AmountReceived);
                    command.Parameters.AddWithValue("@Deleted", 0);

                    SqlParameter outputParameter = new SqlParameter("@NewReceiptId", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParameter);

                    command.ExecuteNonQuery();

                    receipt.ReceiptID = (int)outputParameter.Value;

                    foreach (var detail in details)
                    {
                        using (SqlCommand insertCommand = new SqlCommand("INSERT INTO Receipt_Product (ReceiptId, ProductId, Quantity, Subtotal) VALUES (@ReceiptId, @ProductId, @Quantity, @Subtotal)", conn))
                        {
                            insertCommand.Parameters.AddWithValue("@ReceiptId", receipt.ReceiptID);
                            insertCommand.Parameters.AddWithValue("@ProductId", detail.ProductId);
                            insertCommand.Parameters.AddWithValue("@Quantity", detail.ProductQuantity);
                            insertCommand.Parameters.AddWithValue("@Subtotal", detail.Subtotal);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
        }
        public void UpdateProductStock(ProductStock productStock)
        {
            try
            {
                if(conn.State != ConnectionState.Open) 
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("UpdateProductStock", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter stockProductID = new SqlParameter("@product_id", productStock.ProductID);
                SqlParameter quantityParam = new SqlParameter("@quantity", productStock.Quantity);
                SqlParameter unitOfMeasureParam = new SqlParameter("@unit_of_measure", productStock.UnitOfMeasure);
                SqlParameter expirationDayParam = new SqlParameter("@expiration_day", productStock.DayOfExpiration);
                SqlParameter expirationMonthParam = new SqlParameter("@expiration_month", productStock.MonthOfExpiration);
                SqlParameter expirationYearParam = new SqlParameter("@expiration_year", productStock.YearOfExpiration);
                SqlParameter purchasePriceParam = new SqlParameter("@purchase_price", productStock.PurchasePrice);
                SqlParameter salePriceParam = new SqlParameter("@sale_price", productStock.SalePrice);
                SqlParameter perProductParam = new SqlParameter("@per_product", productStock.PricePerProduct);


                cmd.Parameters.Add(stockProductID);
                cmd.Parameters.Add(quantityParam);
                cmd.Parameters.Add(unitOfMeasureParam);
                cmd.Parameters.Add(expirationDayParam);
                cmd.Parameters.Add(expirationMonthParam);
                cmd.Parameters.Add(expirationYearParam);
                cmd.Parameters.Add(purchasePriceParam);
                cmd.Parameters.Add(salePriceParam);
                cmd.Parameters.Add(perProductParam);

                cmd.ExecuteNonQuery();
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
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("DeleteProductStock", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter productStockIdParam = new SqlParameter("@product_stock_id", productStock.ProductStockID);
                cmd.Parameters.Add(productStockIdParam);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to delete product stock with ID " + productStock.ProductStockID);
            }
            finally { conn.Close(); }
        }

        private ProductStock BuildProductStockFromReader(SqlDataReader reader)
        {
            ProductStock productStock = new ProductStock();

            productStock.ProductStockID = reader.GetInt32(0);
            productStock.ProductID = reader.GetInt32(1);
            productStock.Quantity = reader.GetInt32(2);
            productStock.UnitOfMeasure = reader.GetString(3);
            productStock.DayOfSupply = reader.GetInt32(4);
            productStock.MonthOfSupply = reader.GetInt32(5);
            productStock.YearOfSupply = reader.GetInt32(6);
            productStock.DayOfExpiration = reader.GetInt32(7);
            productStock.MonthOfExpiration = reader.GetInt32(8);
            productStock.YearOfExpiration = reader.GetInt32(9);
            productStock.PurchasePrice = reader.GetDecimal(10);
            productStock.SalePrice = reader.GetDecimal(11);
            productStock.PricePerProduct = reader.GetDecimal(12);

            return productStock;
        }

    }
}

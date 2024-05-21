using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils;
using SupermarketManager.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.DataAccessLayer
{
    public class AdministratorDAL
    {
        private SqlConnection conn;

        public AdministratorDAL()
        {
            conn = DALUtil.Connection;
        }

        public ObservableCollection<User> GetAllUsers()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", conn);

                ObservableCollection<User> result = new ObservableCollection<User>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();
                    user.Username = reader.GetString(0);
                    user.Password = reader.GetString(1);
                    user.UserType = reader.GetString(2);

                    result.Add(user);
                }
                reader.Close();
                return result;
            }
            finally { conn.Close(); }

        }
        public void AddUser(User user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AddUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter usernameParam = new SqlParameter("@username", user.Username);
                SqlParameter passwordParam = new SqlParameter("@password", user.Password);
                SqlParameter typeParameter = new SqlParameter("@user_type", user.UserType);
                SqlParameter userIdParam = new SqlParameter("@user_id", SqlDbType.Int);

                userIdParam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(usernameParam);
                cmd.Parameters.Add(passwordParam);
                cmd.Parameters.Add(typeParameter);
                cmd.Parameters.Add(userIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to add user with username + " + user.Username);
            }
            finally
            {
                conn.Close();
            }

        }
        public void DeleteUser(string username)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter userUsername = new SqlParameter("@username", username);
                cmd.Parameters.Add(userUsername);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to delete user with username " + username);
            }
            finally { conn.Close(); }
        }
        public void UpdateUser(User user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter usernameParam = new SqlParameter("@username", user.Username);
                SqlParameter passwordParam = new SqlParameter("@password", user.Password);
                SqlParameter typeParameter = new SqlParameter("@user_type", user.UserType);

                cmd.Parameters.Add(usernameParam);
                cmd.Parameters.Add(passwordParam);
                cmd.Parameters.Add(typeParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to update user with username " + user.Username);
            }
            finally { conn.Close(); }
        }
        public ObservableCollection<ProductCategory> GetAllProductCategories()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllProductCategories", conn);

                ObservableCollection<ProductCategory> result = new ObservableCollection<ProductCategory>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductCategory category = new ProductCategory();
                    category.CategoryID = reader.GetInt32(0);
                    category.CategoryName = reader.GetString(1);

                    result.Add(category);
                }
                reader.Close();
                return result;
            }
            finally { conn.Close(); }
        }
        public void AddProductCategory(ProductCategory category)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AddProductCategory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter categoryNameParam = new SqlParameter("@category_name", category.CategoryName);

                cmd.Parameters.Add(categoryNameParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to add product category with ID " + category.CategoryID);
            }
            finally { conn.Close(); }
        }
        public void DeleteProductCategory(ProductCategory category)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteProductCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter categoryName = new SqlParameter("@category_name", category.CategoryName);
                cmd.Parameters.Add(categoryName);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to delete product category with ID " + category.CategoryID);
            }
            finally { conn.Close(); }
        }
        public ObservableCollection<Manufacturer> GetAllManufacturers()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllManufacturers", conn);

                ObservableCollection<Manufacturer> result = new ObservableCollection<Manufacturer>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Manufacturer manufacturer = new Manufacturer();
                    manufacturer.ManufacturerID = reader.GetInt32(0);
                    manufacturer.Name = reader.GetString(1);
                    manufacturer.CountryOfOrigin = reader.GetString(2);

                    result.Add(manufacturer);
                }
                reader.Close();
                return result;
            }
            finally { conn.Close(); }
        }
        public void AddManufacturer(Manufacturer manufacturer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AddManufacturer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter("@name", manufacturer.Name);
                SqlParameter countryOfOriginParam = new SqlParameter("@country_of_origin", manufacturer.CountryOfOrigin);

                cmd.Parameters.Add(nameParam);
                cmd.Parameters.Add(countryOfOriginParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to add manufacturer with ID " + manufacturer.ManufacturerID);
            }
            finally { conn.Close(); }
        }
        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteManufacturer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter manufacturerNameParam = new SqlParameter("@manufacturer_name", manufacturer.Name);
                SqlParameter manufacturerCountryParam = new SqlParameter("@manufacturer_country", manufacturer.CountryOfOrigin);
                cmd.Parameters.Add(manufacturerNameParam);
                cmd.Parameters.Add(manufacturerCountryParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to delete manufacturer " + manufacturer.Name);
            }
            finally { conn.Close(); }
        }
        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateManufacturer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter manufacturerIdParam = new SqlParameter("@manufacturer_id", manufacturer.ManufacturerID);
                SqlParameter nameParam = new SqlParameter("@name", manufacturer.Name);
                SqlParameter countryOfOriginParam = new SqlParameter("@country_of_origin", manufacturer.CountryOfOrigin);

                cmd.Parameters.Add(manufacturerIdParam);
                cmd.Parameters.Add(nameParam);
                cmd.Parameters.Add(countryOfOriginParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to update manufacturer with ID " + manufacturer.ManufacturerID);
            }
            finally { conn.Close(); }
        }
        public int GetManufacturerId(Manufacturer manufacturer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ManufacturerId", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter manufacturerNameParam = new SqlParameter("@manufacturer_name", manufacturer.Name);
                SqlParameter manufacturerCountryParam = new SqlParameter("@manufacturer_country", manufacturer.CountryOfOrigin);

                cmd.Parameters.Add(manufacturerNameParam);
                cmd.Parameters.Add(manufacturerCountryParam);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int manufacturerId = reader.GetInt32(0);
                    return manufacturerId;
                }
                else
                {
                    throw new SqlOperationException("No manufacturer found.");
                }
            }
            finally { conn.Close(); }
        }
        public ObservableCollection<Product> GetAllProducts()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllProducts", conn);

                ObservableCollection<Product> result = new ObservableCollection<Product>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductName = reader.GetString(0);
                    product.ProductId = reader.GetInt32(0);
                    product.Barcode = reader.GetInt32(1);
                    product.CategoryID = reader.GetInt32(2);
                    product.ManufacturerID = reader.GetInt32(2);

                    result.Add(product);
                }
                reader.Close();
                return result;
            }
            finally { conn.Close(); }
        }
        public ObservableCollection<Product> GetProductsByManufacturer(Manufacturer manufacturer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductsByManufacturer", conn);
                int manufacturerId = GetManufacturerId(manufacturer);

                ObservableCollection<Product> result = new ObservableCollection<Product>();
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductName = reader.GetString(0);
                    product.ProductId = reader.GetInt32(0);
                    product.Barcode = reader.GetInt32(1);
                    product.CategoryID = reader.GetInt32(2);
                    product.ManufacturerID = reader.GetInt32(2);

                    result.Add(product);
                }
                reader.Close();
                return result;
            }
            finally { conn.Close(); }
        }
        public void AddProduct(Product product)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AddProduct", conn);
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
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to add product with ID " + product.ProductId);
            }
            finally { conn.Close(); }
        }
        public void DeleteProduct(Product product)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter productIdParam = new SqlParameter("@product_id", product.ProductId);
                cmd.Parameters.Add(productIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to delete product with ID " + product.ProductId);
            }
            finally { conn.Close(); }
        }
        public void UpdateProduct(Product product)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter productNameParam = new SqlParameter("@product_name", product.ProductName);
                SqlParameter barcodeParam = new SqlParameter("@barcode", product.Barcode);
                SqlParameter categoryIdParam = new SqlParameter("@category_id", product.CategoryID);
                SqlParameter manufacturerIdParam = new SqlParameter("@manufacturer_id", product.ManufacturerID);

                cmd.Parameters.Add(productNameParam);
                cmd.Parameters.Add(barcodeParam);
                cmd.Parameters.Add(categoryIdParam);
                cmd.Parameters.Add(manufacturerIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to update product with ID " + product.ProductId);
            }
            finally { conn.Close(); }
        }
        public ObservableCollection<ProductStock> GetAllProductStocks()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllProductStocks", conn);

                ObservableCollection<ProductStock> result = new ObservableCollection<ProductStock>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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

                    result.Add(productStock);
                }
                reader.Close();
                return result;
            }
            finally { conn.Close(); }
        }
        public void AddProductStock(ProductStock productStock)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AddProductStock", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter stockProductID = new SqlParameter("@product_id", productStock.ProductID);
                SqlParameter quantityParam = new SqlParameter("@quantity", productStock.Quantity);
                SqlParameter pricePerProduct = new SqlParameter("@price_per_product", productStock.SalePrice / productStock.Quantity);
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
                cmd.Parameters.Add(pricePerProduct);
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
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to add product stock with ID " + productStock.ProductStockID);
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
        public void UpdateProductStock(ProductStock productStock)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateProductStock", conn);
                cmd.CommandType = CommandType.StoredProcedure;

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
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to update product stock with ID " + productStock.ProductStockID);
            }
            finally { conn.Close(); }
        }
        public int GetStockId(ProductStock productStock)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetStockId", conn);
                cmd.CommandType = CommandType.StoredProcedure;

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
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int stockId = reader.GetInt32(0);
                    return stockId;
                }
                else
                {
                    throw new SqlOperationException("No stock found.");
                }

            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to get product stock sale price with stock ID " + productStock.ProductStockID);
            }
            finally { conn.Close(); }
        }
        public decimal GetStockPurchasePrice(ProductStock productStock)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetStockPurchasePrice", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter productStockIdParam = new SqlParameter("@stock_id", productStock.ProductStockID);


                cmd.Parameters.Add(productStockIdParam);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    decimal purchasePrice = reader.GetDecimal(1);
                    return purchasePrice;
                }
                else
                {
                    throw new SqlOperationException("No sale price found for stock ID: " + productStock.ProductStockID);
                }

            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to get product stock sale price with stock ID " + productStock.ProductStockID);
            }
            finally { conn.Close(); }
        }
        public int GetMarkupByCategory(int categoryId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetMarkupsByCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter categoryIdParam = new SqlParameter("@category_id", categoryId);
                cmd.Parameters.Add(categoryIdParam);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int markupPercentage = reader.GetInt32(1);
                    reader.Close();
                    return markupPercentage;
                }
                else
                {
                    throw new SqlOperationException("No markup found for category ID: " + categoryId);
                }
            }
            finally { conn.Close(); }
        }
        public ObservableCollection<Markup> GetAllMarkups()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllMarkups", conn);

                ObservableCollection<Markup> result = new ObservableCollection<Markup>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Markup markup = new Markup();
                    markup.MarkupID = reader.GetInt32(0);
                    markup.MarkupPercentage = reader.GetInt32(1);
                    markup.MarkupCategory = reader.GetInt32(2);

                    result.Add(markup);
                }
                reader.Close();
                return result;
            }
            finally { conn.Close(); }
        }
        public void AddMarkup(Markup markup)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AddMarkup", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter markupIdParam = new SqlParameter("@markup_id", markup.MarkupID) { Direction = ParameterDirection.Output };
                SqlParameter markupPercentageParam = new SqlParameter("@markup_percentage", markup.MarkupPercentage);
                SqlParameter markupCategoryParam = new SqlParameter("@markup_category", markup.MarkupCategory);

                cmd.Parameters.Add(markupIdParam);
                cmd.Parameters.Add(markupPercentageParam);
                cmd.Parameters.Add(markupCategoryParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                markup.MarkupID = (int)markupIdParam.Value;
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to add markup with ID " + markup.MarkupID);
            }
            finally { conn.Close(); }
        }
        public void DeleteMarkup(Markup markup)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteMarkup", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter markupIdParam = new SqlParameter("@markup_id", markup.MarkupID);
                cmd.Parameters.Add(markupIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to delete markup with ID " + markup.MarkupID);
            }
            finally { conn.Close(); }
        }
        public void UpdateMarkup(Markup markup)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateMarkup", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter markupIdParam = new SqlParameter("@markup_id", markup.MarkupID) { Direction = ParameterDirection.Output };
                SqlParameter markupPercentageParam = new SqlParameter("@markup_percentage", markup.MarkupPercentage);
                SqlParameter markupCategoryParam = new SqlParameter("@markup_category", markup.MarkupCategory);

                cmd.Parameters.Add(markupIdParam);
                cmd.Parameters.Add(markupPercentageParam);
                cmd.Parameters.Add(markupCategoryParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                markup.MarkupID = (int)markupIdParam.Value;
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to update markup with ID " + markup.MarkupID);
            }
            finally { conn.Close(); }
        }
        private int GetCategoryId(string categoryName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetCategoryId", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter categoryNameParam = new SqlParameter("@category_name", categoryName);
                cmd.Parameters.Add(categoryNameParam);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    throw new SqlOperationException("No category found.");
                }
            }
            finally { conn.Close(); }
        }
        public decimal GetTotalSalePriceOfCategory(string categoryName)
        {
            try
            {
                int categoryId = GetCategoryId(categoryName);

                SqlCommand cmd = new SqlCommand("GetTotalSalePrice", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter categoryIdParam = new SqlParameter("@category_id", categoryId);
                cmd.Parameters.Add(categoryIdParam);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return reader.GetDecimal(0);
                }
                else
                {
                    throw new SqlOperationException("Sum of all sale prices of a given category failed.");
                }
            }
            finally { conn.Close(); }
        }
        public ObservableCollection<DailyRevenue> GetDailyRevenueByMonthAndCashier(string cashierName, string month)
        {
            ObservableCollection<DailyRevenue> dailyRevenueList = new ObservableCollection<DailyRevenue>();

            try
            {
                SqlCommand cmd = new SqlCommand("DailyRevenueByCashierAndMonth", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter cashierNameParam = new SqlParameter("@cashier_name", cashierName);
                SqlParameter monthParam = new SqlParameter("@month", month);

                cmd.Parameters.Add(cashierNameParam);
                cmd.Parameters.Add(monthParam);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DailyRevenue dailyRevenue = new DailyRevenue();
                        dailyRevenue.DayNumber = reader.GetInt32(0);
                        dailyRevenue.TotalAmount = reader.GetDecimal(1);
                        dailyRevenueList.Add(dailyRevenue);
                    }
                }
            }
            finally { conn.Close(); }

            return dailyRevenueList;
        }
        private Receipt GetHighestReceipt(int day)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("HighestReceipt", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter dayParam = new SqlParameter("@day", day);
                cmd.Parameters.Add(dayParam);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Receipt highestReceipt = new Receipt();
                    highestReceipt.ReceiptID = reader.GetInt32(0);
                    highestReceipt.ReceiptProductId = reader.GetInt32(1);
                    highestReceipt.MonthOfIssuing = reader.GetInt32(2);
                    highestReceipt.DayOfIssuing = reader.GetInt32(3);
                    highestReceipt.YearOfIssuing = reader.GetInt32(4);
                    highestReceipt.CashierName = reader.GetString(1);
                    highestReceipt.AmountReceived = reader.GetDecimal(0);

                    return highestReceipt;
                }
                else
                {
                    throw new SqlOperationException("No highest receipt.");
                }
            }
            finally { conn.Close(); }
        }
        public Product GetHighestReceiptProduct(int day)
        {
            Receipt highestReceipt = GetHighestReceipt(day);

            try
            {
                SqlCommand cmd = new SqlCommand("ProductFromReceipt", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter receiptIdParam = new SqlParameter("@receipt_id", highestReceipt.ReceiptID);
                cmd.Parameters.Add(receiptIdParam);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Product product = new Product();
                    product.ProductName = reader.GetString(0);
                    product.ProductId = reader.GetInt32(0);
                    product.Barcode = reader.GetInt32(1);
                    product.CategoryID = reader.GetInt32(2);
                    product.ManufacturerID = reader.GetInt32(3);

                    return product;
                }
                else
                {
                    throw new SqlOperationException("Can't find product info of highest receipt.");
                }
            }
            finally { conn.Close(); }
        }
        public void AddOffer(Offer offer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AddOffer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter reasonParam = new SqlParameter("@reason", offer.Reason);
                SqlParameter productIdParam = new SqlParameter("@product_id", offer.ProductID);
                SqlParameter discountPercentageParam = new SqlParameter("@discount_percentage", offer.DiscountPercentage);
                SqlParameter validFromDayParam = new SqlParameter("@valid_from_day", offer.ValidFromDay);
                SqlParameter validFromMonthParam = new SqlParameter("@valid_from_month", offer.ValidFromMonth);
                SqlParameter validFromYearParam = new SqlParameter("@valid_from_year", offer.ValidFromYear);
                SqlParameter validToDayParam = new SqlParameter("@valid_to_day", offer.ValidToDay);
                SqlParameter validToMonthParam = new SqlParameter("@valid_to_month", offer.ValidToMonth);
                SqlParameter validToYearParam = new SqlParameter("@valid_to_year", offer.ValidToYear);

                cmd.Parameters.Add(reasonParam);
                cmd.Parameters.Add(productIdParam);
                cmd.Parameters.Add(discountPercentageParam);
                cmd.Parameters.Add(validFromDayParam);
                cmd.Parameters.Add(validFromMonthParam);
                cmd.Parameters.Add(validFromYearParam);
                cmd.Parameters.Add(validToDayParam);
                cmd.Parameters.Add(validToMonthParam);
                cmd.Parameters.Add(validToYearParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to add offer with reason: " + offer.Reason);
            }
            finally { conn.Close(); }
        }
        public void DeleteOffer(Offer offer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteOffer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter offerIdParam = new SqlParameter("@offer_id", offer.OfferID);
                cmd.Parameters.Add(offerIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to delete offer with ID: " + offer.OfferID);
            }
            finally { conn.Close(); }
        }
        public void UpdateOffer(Offer offer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateOffer", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter reasonParam = new SqlParameter("@reason", offer.Reason);
                SqlParameter productIdParam = new SqlParameter("@product_id", offer.ProductID);
                SqlParameter discountPercentageParam = new SqlParameter("@discount_percentage", offer.DiscountPercentage);
                SqlParameter validFromDayParam = new SqlParameter("@valid_from_day", offer.ValidFromDay);
                SqlParameter validFromMonthParam = new SqlParameter("@valid_from_month", offer.ValidFromMonth);
                SqlParameter validFromYearParam = new SqlParameter("@valid_from_year", offer.ValidFromYear);
                SqlParameter validToDayParam = new SqlParameter("@valid_to_day", offer.ValidToDay);
                SqlParameter validToMonthParam = new SqlParameter("@valid_to_month", offer.ValidToMonth);
                SqlParameter validToYearParam = new SqlParameter("@valid_to_year", offer.ValidToYear);

                cmd.Parameters.Add(reasonParam);
                cmd.Parameters.Add(productIdParam);
                cmd.Parameters.Add(discountPercentageParam);
                cmd.Parameters.Add(validFromDayParam);
                cmd.Parameters.Add(validFromMonthParam);
                cmd.Parameters.Add(validFromYearParam);
                cmd.Parameters.Add(validToDayParam);
                cmd.Parameters.Add(validToMonthParam);
                cmd.Parameters.Add(validToYearParam);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to update offer with ID: " + offer.OfferID);
            }
            finally { conn.Close(); }
        }
        public bool DoesSimilarOfferExist(Offer offer)
        {
            bool exists = false;
            try
            {
                SqlCommand cmd = new SqlCommand("CheckSimilarOfferExists", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter reasonParam = new SqlParameter("@reason", offer.Reason);
                SqlParameter productIdParam = new SqlParameter("@product_id", offer.ProductID);
                SqlParameter discountPercentageParam = new SqlParameter("@discount_percentage", offer.DiscountPercentage);
                SqlParameter validFromDayParam = new SqlParameter("@valid_from_day", offer.ValidFromDay);
                SqlParameter validFromMonthParam = new SqlParameter("@valid_from_month", offer.ValidFromMonth);
                SqlParameter validFromYearParam = new SqlParameter("@valid_from_year", offer.ValidFromYear);
                SqlParameter validToDayParam = new SqlParameter("@valid_to_day", offer.ValidToDay);
                SqlParameter validToMonthParam = new SqlParameter("@valid_to_month", offer.ValidToMonth);
                SqlParameter validToYearParam = new SqlParameter("@valid_to_year", offer.ValidToYear);

                cmd.Parameters.Add(reasonParam);
                cmd.Parameters.Add(productIdParam);
                cmd.Parameters.Add(discountPercentageParam);
                cmd.Parameters.Add(validFromDayParam);
                cmd.Parameters.Add(validFromMonthParam);
                cmd.Parameters.Add(validFromYearParam);
                cmd.Parameters.Add(validToDayParam);
                cmd.Parameters.Add(validToMonthParam);
                cmd.Parameters.Add(validToYearParam);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                exists = reader.HasRows;
                reader.Close();
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " when trying to check for similar offer");
            }
            finally { conn.Close(); }

            return exists;
        }
        public bool CheckManufacturerExistsById(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CheckManufacturerExistsById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter manufacturerId = new SqlParameter("@manufacturer_id", id);
               
                cmd.Parameters.Add(manufacturerId);
            
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int count = reader.GetInt32(0);
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + "When trying to check manufacturer with id " + id);
            }
            finally
            {
                conn.Close();
            }
        }
        public bool CheckCategoryExistsById(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CheckProductCategoryExistsById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter categoryId = new SqlParameter("@username", id);

                cmd.Parameters.Add(categoryId);
          
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int count = reader.GetInt32(0);
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new SqlOperationException(e.Message + " When trying to check category with id  " + id);
            }
            finally
            {
                conn.Close();
            }
        }
    }

}

using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils;
using SupermarketManager.Utils.Enums;
using SupermarketManager.Utils.Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SupermarketManager.Model.BusinessLogicLayer
{
    public class AdministratorBLL
    {
        private readonly AdministratorDAL administratorDAL;

        public AdministratorBLL(AdministratorDAL administratorDAL)
        {
            this.administratorDAL = administratorDAL;
        }
        public void ProductStockOperation(int id, decimal purchasePrice, int quantity, string unitOfMeasure, DateTime experationDate, int productId, OperationsType opType = OperationsType.Insert)
        {
            if (purchasePrice <= 0)
            {
                throw new ArgumentException("Can't have a purchase price smaller or 0 when adding a stock.");
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("Can't have a quantity smaller or 0 when adding a stock.");
            }
            if (unitOfMeasure == null || unitOfMeasure == "")
            {
                throw new ArgumentException("Can't have a null or empty unit of measure.");
            }
            if (productId == 0)
            {
                throw new ArgumentException("Can't have a productId smaller or 0.");
            }

            decimal pricePerProduct = purchasePrice / quantity;
            int markupPercentage = administratorDAL.GetMarkupByCategory(MarkupManager.GetMarkupCategory(pricePerProduct));
            decimal markupProductPrice = pricePerProduct + (markupPercentage * pricePerProduct) / 100;
            decimal stockMarkupPrice = markupProductPrice * quantity;

            ProductStock stock = new ProductStock();
            stock.Quantity = quantity;
            stock.UnitOfMeasure = unitOfMeasure;
            stock.PurchasePrice = purchasePrice;
            stock.SalePrice = stockMarkupPrice;
            stock.DayOfExpiration = experationDate.Day;
            stock.MonthOfExpiration = experationDate.Month;
            stock.YearOfExpiration = experationDate.Year;

            if (opType == OperationsType.Insert)
            {
                stock.DayOfSupply = DateTime.Now.Day;
                stock.MonthOfSupply = DateTime.Now.Month;
                stock.YearOfSupply = DateTime.Now.Year;
            }
            stock.ProductID = productId;
            stock.ProductStockID = id;
            stock.PricePerProduct = markupProductPrice;

            if (opType == OperationsType.Insert)
            {
                CheckProductExists(productId);

                administratorDAL.AddProductStock(stock);
            }
            else if (opType == OperationsType.Update)
            {
                CheckProductExists(productId);
                administratorDAL.UpdateProductStock(stock);
            }
            else if (opType == OperationsType.Delete)
            {
                administratorDAL.DeleteProductStock(stock);
            }
            else { throw new ArgumentException("Can't have another option than add, update or delete for the stock."); }
        }
        public ObservableCollection<ProductStock> GetAllProductStocks()
        {
            return administratorDAL.GetAllProductStocks();
        }
        public void ModifyPurchasePriceOfStock(decimal purchasePrice, int quantity, string unitOfMeasure, DateTime experationDate, int productId, decimal newSalePrice)
        {
            if (purchasePrice == 0)
            {
                throw new ArgumentException("Can't have a purchase price of 0 when adding a stock.");
            }
            if (quantity == 0)
            {
                throw new ArgumentException("Can't have a quantity of 0 when adding a stock.");
            }

            ProductStock stock = new ProductStock();
            stock.Quantity = quantity;
            stock.UnitOfMeasure = unitOfMeasure;
            stock.PurchasePrice = purchasePrice;
            stock.SalePrice = newSalePrice;
            stock.DayOfExpiration = experationDate.Day;
            stock.MonthOfExpiration = experationDate.Month;
            stock.YearOfExpiration = experationDate.Year;
            stock.DayOfSupply = DateTime.Now.Day;
            stock.MonthOfSupply = DateTime.Now.Month;
            stock.YearOfSupply = DateTime.Now.Year;
            stock.ProductID = productId;
            stock.ProductStockID = administratorDAL.GetStockId(stock);

            if (newSalePrice >= administratorDAL.GetStockPurchasePrice(stock))
            {
                administratorDAL.UpdateProductStock(stock);
            }
            else
            {
                throw new ArgumentException("New sale price can't smaller then purchase price.");
            }
        }
        public void ManufacturerOperation(int id, string name, string countryOfOrigin, OperationsType opType = OperationsType.Insert)
        {
            if (name == null || name == "")
            {
                throw new ArgumentException("Manufacturer needs a name");
            }
            if (countryOfOrigin == null || countryOfOrigin == "")
            {
                throw new ArgumentException("Manufacturer needs a country of origin");
            }

            Manufacturer manufacturer = new Manufacturer();
            manufacturer.Name = name;
            manufacturer.CountryOfOrigin = countryOfOrigin;
            manufacturer.ManufacturerID = id;

            if (opType == OperationsType.Insert)
            {
                administratorDAL.AddManufacturer(manufacturer);
            }
            else if (opType == OperationsType.Update)
            {
                administratorDAL.UpdateManufacturer(manufacturer);
            }
            else if (opType == OperationsType.Delete)
            {
                administratorDAL.DeleteManufacturer(manufacturer);
            }
            else { throw new ArgumentException("Can't have another option than add, update or delete for the manufacturer."); }
        }
        public ObservableCollection<Manufacturer> GetAllManufacturers()
        {
            return administratorDAL.GetAllManufacturers();
        }
        public ObservableCollection<User> GetAllUsers()
        {
            return administratorDAL.GetAllUsers();
        }
        public void CategoryOperation(string categoryName, int categoryId, OperationsType opType = OperationsType.Insert)
        {
            if (categoryName == null || categoryName == "")
            {
                throw new ArgumentException("Category name required.");
            }

            ProductCategory category = new ProductCategory();
            category.CategoryName = categoryName;

            if (opType == OperationsType.Insert)
            {
                administratorDAL.AddProductCategory(category);
            }
            else if (opType == OperationsType.Delete)
            {
                administratorDAL.DeleteProductCategory(category);
            }
            else if (opType == OperationsType.Update)
            {
                administratorDAL.UpdateCategory(categoryName, categoryId);
            }
            else { throw new ArgumentException("Can't have another option than add, update or delete for the category."); }
        }
        public ObservableCollection<ProductCategory> GetAllCategories()
        {
            var categories = administratorDAL.GetAllProductCategories();

            foreach(ProductCategory productCategory in categories)
            {
                productCategory.TotalValue = administratorDAL.GetTotalSalePriceOfCategory(productCategory.CategoryName);
            }

            return categories;
        }
        public void ProductOperation(int productId, string productName, int barcode, int manufacturerID, int categoryID, OperationsType opType = OperationsType.Insert)
        {
            if (productName == null || productName == "")
            {
                throw new ArgumentException("Null or empty product name");
            }
            if (barcode <= 0)
            {
                throw new ArgumentException("A product shouldn't have it's barcode smaller than or equal to 0.");
            }
            if (manufacturerID <= 0)
            {
                throw new ArgumentException("No manufacturer selected.");
            }
            if (categoryID <= 0)
            {
                throw new ArgumentException("No category selected.");
            }

            Product product = new Product();
            product.ProductName = productName;
            product.Barcode = barcode;
            product.ManufacturerID = manufacturerID;
            product.CategoryID = categoryID;
            product.ProductId = productId;

            if (opType == OperationsType.Insert)
            {
                CheckManufacturerAndCategoryExists(manufacturerID, categoryID);

                administratorDAL.AddProduct(product);
            }
            else if (opType == OperationsType.Update)
            {
                CheckManufacturerAndCategoryExists(manufacturerID, categoryID);

                administratorDAL.UpdateProduct(product);
            }
            else if (opType == OperationsType.Delete)
            {
                administratorDAL.DeleteProduct(product);
            }
            else { throw new ArgumentException("Can't have another option than add, update or delete for the product."); }
        }
        public ObservableCollection<Product> GetAllProducts()
        {
            return administratorDAL.GetAllProducts();
        }
        public ObservableCollection<Product> GetProductsByManufacturer(Manufacturer manufacturer)
        {
            if (manufacturer.Name == null || manufacturer.Name.Length == 0)
            { throw new ArgumentException("Manufacturer with null or empty name."); }
            if (manufacturer.CountryOfOrigin == null || manufacturer.CountryOfOrigin.Length == 0)
            { throw new ArgumentException("Manufacturer with null or empty country of origin."); }

            return administratorDAL.GetProductsByManufacturer(manufacturer);
        }
        public decimal GetTotalSalePriceOfCategory(string categoryName)
        {
            if (categoryName == null || categoryName.Length == 0) { throw new ArgumentException("Category name null or empty."); }

            return administratorDAL.GetTotalSalePriceOfCategory(categoryName);
        }

        public ObservableCollection<DailyRevenue> GetDailyRevenueByMonthAndCashier(string cashierName, int month, int year)
        {
            if (cashierName == null || cashierName.Length == 0)
            {
                throw new ArgumentException("Selected cashier must have a name.");
            }
            if (month <= 0)
            {
                throw new ArgumentException("Selected month must bigger than 0.");
            }
            if (year <= 0)
            {
                throw new ArgumentException("Selected year must bigger than 0.");
            }

            return administratorDAL.GetDailyRevenueByMonthAndCashier(cashierName, month, year);
        }
        public Tuple<Receipt, ObservableCollection<Product>> GetHighestReceiptProducts(int day, int month, int year)
        {
            // TODO: Call the offer manager at the same way as the stock checker
            // TODO: Now need a method to return for the receipt id and each product id from the list the quantity and subtotal from receipt_product
            if (day <= 0 || month<=0 || year<=0)
            {
                throw new ArgumentException("Can't have dates smaller or 0.");
            }

            return administratorDAL.GetHighestReceiptProducts(day, month, year);
        }
        public bool ApplyOfferToAllStocks()
        {
            int offersApplied = 0;

            ObservableCollection<ProductStock> stocks = administratorDAL.GetAllProductStocks();

            foreach (ProductStock stock in stocks)
            {
                int offerPercentage = 0;

                if (OfferManager.CanGetOffer(stock) == OfferTypes.EXPIRATION)
                {
                    offersApplied++;
                    offerPercentage = OfferManager.GetOfferPercentageByExpiration((int)(stock.DayOfExpiration - DateTime.Now.Day));
                    stock.SalePrice = stock.SalePrice - (stock.SalePrice * offerPercentage) / 100;

                    administratorDAL.UpdateProductStock(stock);

                    Offer offer = AddOfferProperties("Expiration", stock);

                    CheckAndAddOffer(offer);

                }
                else if (OfferManager.CanGetOffer(stock) == OfferTypes.STOCK_LIQUIDATION)
                {
                    offersApplied++;
                    offerPercentage = OfferManager.GetOfferPercentageByLiquidation();
                    stock.SalePrice = stock.SalePrice - (stock.SalePrice * offerPercentage) / 100;

                    administratorDAL.UpdateProductStock(stock);

                    Offer offer = AddOfferProperties("Liquidation", stock);

                    CheckAndAddOffer(offer);
                }
                else if (OfferManager.CanGetOffer(stock) == OfferTypes.BOTH)
                {
                    offersApplied++;
                    offerPercentage = Math.Max(OfferManager.GetOfferPercentageByLiquidation(), OfferManager.GetOfferPercentageByExpiration((int)(stock.DayOfExpiration - DateTime.Now.Day)));
                    stock.SalePrice = stock.SalePrice - (stock.SalePrice * offerPercentage) / 100;

                    administratorDAL.UpdateProductStock(stock);

                    Offer offer = AddOfferProperties("Liquidation", stock);

                    CheckAndAddOffer(offer);
                }
            }

            if (offersApplied > 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckStocks()
        {
            List<CustomDate> customDates = JsonPersitence.LoadFromJson<CustomDate>("..\\..\\Resources\\stock_check.json");

            CustomDate currentDate = new CustomDate();
            currentDate.Day = DateTime.Now.Day;
            currentDate.Month = DateTime.Now.Month;
            currentDate.Year = DateTime.Now.Year;

            if (customDates == null || customDates.Count == 0)
            {
                JsonPersitence.SaveToJson<CustomDate>(currentDate, "..\\..\\Resources\\stock_check.json");
                return StockValidityManager.CheckStocks();
            }
            else
            {
                CustomDate lastCheck = customDates.Last();

                if (lastCheck.Year < DateTime.Now.Year)
                {
                    JsonPersitence.SaveToJson<CustomDate>(currentDate, "..\\..\\Resources\\stock_check.json");
                    return StockValidityManager.CheckStocks();
                }
                else if (lastCheck.Month < DateTime.Now.Month)
                {
                    JsonPersitence.SaveToJson<CustomDate>(currentDate, "..\\..\\Resources\\stock_check.json");
                    return StockValidityManager.CheckStocks();
                }
                else if (lastCheck.Day < DateTime.Now.Day)
                {
                    JsonPersitence.SaveToJson<CustomDate>(currentDate, "..\\..\\Resources\\stock_check.json");
                    return StockValidityManager.CheckStocks();
                }
            }
            return false;
        }

        private void CheckAndAddOffer(Offer offer)
        {
            if (administratorDAL.DoesSimilarOfferExist(offer))
            {
                administratorDAL.UpdateOffer(offer);
            }
            else
            {
                administratorDAL.AddOffer(offer);
            }
        }
        private Offer AddOfferProperties(string reason, ProductStock stock)
        {
            Offer offer = new Offer();
            offer.ProductID = stock.ProductID;
            offer.Reason = reason;

            offer.ValidFromDay = DateTime.Now.Day;
            offer.ValidFromMonth = DateTime.Now.Month;
            offer.ValidFromYear = DateTime.Now.Year;

            offer.ValidToDay = stock.DayOfExpiration;
            offer.ValidToMonth = stock.MonthOfExpiration;
            offer.ValidToYear = stock.YearOfExpiration;

            return offer;
        }
        public void DeleteUser(string username)
        {
            administratorDAL.DeleteUser(username);
        }
        private void CheckManufacturerAndCategoryExists(int manufacturerId, int categoryId)
        {
            if (!administratorDAL.CheckManufacturerExistsById(manufacturerId))
            {
                throw new ArgumentException("Manufacturer with id " + manufacturerId + " doesn't exists.");
            }

            if (!administratorDAL.CheckCategoryExistsById(categoryId))
            {
                throw new ArgumentException("Category with id " + categoryId + " doesn't exists.");
            }
        }
        private void CheckProductExists(int id)
        {
            if (!administratorDAL.CheckProductById(id))
            {
                throw new ArgumentException("Product with id " + id + " doesn't exists.");
            }
        }
        public Product GetFullProduct(string productName, int barcode, int manufacturerId, int categoryId)
        {

            Product product = new Product();

            product.ProductName = productName;
            product.Barcode = barcode;
            product.ManufacturerID = manufacturerId;
            product.CategoryID = categoryId;
            product.ProductId = administratorDAL.GetProductId(product);

            return product;
        }
        public ProductCategory GetFullCategory(string categoryName)
        {
            ProductCategory category = new ProductCategory();
            category.CategoryName = categoryName;
            category.CategoryID = administratorDAL.GetCategoryId(categoryName);

            return category;
        }
        public Manufacturer GetFullManufacturer(string manufacturerName, string countryOfOrigin)
        {
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.Name = manufacturerName;
            manufacturer.CountryOfOrigin = countryOfOrigin;
            manufacturer.ManufacturerID = administratorDAL.GetManufacturerId(manufacturer);

            return manufacturer;
        }
        public ProductStock GetFullStock(decimal pPrice, int quantity, string unitOfMeasure, DateTime exp, int productId)
        {
            ProductStock stock = new ProductStock();
            stock.Quantity = quantity;
            stock.UnitOfMeasure = unitOfMeasure;
            stock.PurchasePrice = pPrice;
            stock.DayOfExpiration = exp.Day;
            stock.MonthOfExpiration = exp.Month;
            stock.YearOfExpiration = exp.Year;
            stock.ProductID = productId;

            return administratorDAL.GetStock(administratorDAL.GetStockId(stock));
        }
    }
}

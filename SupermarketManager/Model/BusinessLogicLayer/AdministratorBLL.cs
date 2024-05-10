using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.BusinessLogicLayer
{
    public class AdministratorBLL
    {
        private readonly AdministratorDAL _administratorDAL;

        public AdministratorBLL()
        {
            _administratorDAL = new AdministratorDAL();
        }
        public void ProductStockOperation(decimal purchasePrice, int quantity, string unitOfMeasure, DateTime experationDate, int productId, OperationsType opType = OperationsType.Insert)
        {
            if (purchasePrice == 0)
            {
                throw new ArgumentException("Can't have a purchase price of 0 when adding a stock.");
            }
            if (quantity == 0)
            {
                throw new ArgumentException("Can't have a quantity of 0 when adding a stock.");
            }

            decimal pricePerProduct = purchasePrice / quantity;
            int markupPercentage = _administratorDAL.GetMarkupByCategory(MarkupCategorySelector.GetMarkupCategory(pricePerProduct));
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
            stock.DayOfSupply = DateTime.Now.Day;
            stock.MonthOfSupply = DateTime.Now.Month;
            stock.YearOfSupply = DateTime.Now.Year;
            stock.ProductID = productId;

            if (opType == OperationsType.Insert)
            {
                _administratorDAL.AddProductStock(stock);
            }
            else if (opType == OperationsType.Update)
            {
                _administratorDAL.UpdateProductStock(stock);
            }
            else if (opType == OperationsType.Delete)
            {
                stock.ProductStockID = _administratorDAL.GetStockId(stock);
                _administratorDAL.DeleteProductStock(stock);
            }
            else { throw new ArgumentException("Can't have another option than add, update or delete for the stock."); }
        }
        public ObservableCollection<ProductStock> GetAllProductStocks()
        {
            return _administratorDAL.GetAllProductStocks();
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
            stock.ProductStockID = _administratorDAL.GetStockId(stock);

            if (newSalePrice >= _administratorDAL.GetStockPurchasePrice(stock))
            {
                _administratorDAL.UpdateProductStock(stock);
            }
            else
            {
                throw new ArgumentException("New sale price can't smaller then purchase price.");
            }
        }
        public void ManufacturerOperation(string name, string countryOfOrigin, OperationsType opType = OperationsType.Insert)
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

            if (opType == OperationsType.Insert)
            {
                _administratorDAL.AddManufacturer(manufacturer);
            }
            else if (opType == OperationsType.Update)
            {
                _administratorDAL.UpdateManufacturer(manufacturer);
            }
            else if (opType == OperationsType.Delete)
            {
                _administratorDAL.DeleteManufacturer(manufacturer);
            }
            else { throw new ArgumentException("Can't have another option than add, update or delete for the manufacturer."); }
        }
        public ObservableCollection<Manufacturer> GetAllManufacturers()
        {
            return _administratorDAL.GetAllManufacturers();
        }
        public ObservableCollection<User> GetAllUsers()
        {
            return _administratorDAL.GetAllUsers();
        }
        public void CategoryOperation(string categoryName, OperationsType opType = OperationsType.Insert)
        {
            if (categoryName == null || categoryName == "")
            {
                throw new ArgumentException("Category name required.");
            }

            ProductCategory category = new ProductCategory();
            category.CategoryName = categoryName;

            if (opType == OperationsType.Insert)
            {
                _administratorDAL.AddProductCategory(category);
            }
            else if (opType == OperationsType.Update)
            {
                _administratorDAL.UpdateProductCategory(category);
            }
            else if (opType == OperationsType.Delete)
            {
                _administratorDAL.DeleteProductCategory(category);
            }
            else { throw new ArgumentException("Can't have another option than add, update or delete for the category."); }
        }
        public ObservableCollection<ProductCategory> GetAllCategories()
        {
            return _administratorDAL.GetAllProductCategories();
        }
        public void ProductOperation(int barcode, int manufacturerID, int categoryID, OperationsType opType = OperationsType.Insert)
        {
            if (barcode <= 0)
            {
                throw new ArgumentException("A product shouldn't have it's barcode smaller then 0.");
            }

            Product product = new Product();
            product.Barcode = barcode;
            product.ManufacturerID = manufacturerID;
            product.CategoryID = categoryID;

            if (opType == OperationsType.Insert)
            {
                _administratorDAL.AddProduct(product);
            }
            else if (opType == OperationsType.Update)
            {
                _administratorDAL.UpdateProduct(product);
            }
            else if (opType == OperationsType.Delete)
            {
                _administratorDAL.DeleteProduct(product);
            }
            else { throw new ArgumentException("Can't have another option than add, update or delete for the product."); }
        }
        public ObservableCollection<Product> GetAllProducts()
        {
            return _administratorDAL.GetAllProducts();
        }
        public ObservableCollection<Product> GetProductsByManufacturer(Manufacturer manufacturer)
        {
            if (manufacturer.Name == null || manufacturer.Name.Length == 0)
            { throw new ArgumentException("Manufacturer with null or empty name."); }
            if (manufacturer.CountryOfOrigin == null || manufacturer.CountryOfOrigin.Length == 0)
            { throw new ArgumentException("Manufacturer with null or empty country of origin."); }

            return _administratorDAL.GetProductsByManufacturer(manufacturer);
        }
        public decimal GetTotalSalePriceOfCategory(string categoryName)
        {
            if (categoryName == null || categoryName.Length == 0) { throw new ArgumentException("Category name null or empty."); }

            return _administratorDAL.GetTotalSalePriceOfCategory(categoryName);
        }

        public ObservableCollection<DailyRevenue> GetDailyRevenueByMonthAndCashier(string cashierName, string month)
        {
            if (cashierName == null || cashierName.Length == 0)
            {
                throw new ArgumentException("Selected cashier must have a name.");
            }
            if (month == null || month.Length == 0)
            {
                throw new ArgumentException("Selected month must have a name.");
            }

            return _administratorDAL.GetDailyRevenueByMonthAndCashier(cashierName, month);
        }
        public Product GetHighestReceiptProduct(int day)
        {
            if (day == 0)
            {
                throw new ArgumentException("Can't have day 0.");
            }

            return _administratorDAL.GetHighestReceiptProduct(day);
        }
    }
}

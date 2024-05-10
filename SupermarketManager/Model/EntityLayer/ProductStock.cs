using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.EntityLayer
{
    public class ProductStock : BasePropertyChanged
    {
        private int? productStockID;
        public int? ProductStockID
        {
            get { return productStockID; }
            set
            {
                productStockID = value;
                NotifyPropertyChanged("ProductStockID");
            }
        }

        private int? productID;
        public int? ProductID
        {
            get { return  productID; }
            set
            {
                productID = value;
                NotifyPropertyChanged("StockProductID");
            }
        }

        private int? quantity;
        public int? Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        private string unitOfMeasure;
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set
            {
                unitOfMeasure = value;
                NotifyPropertyChanged("UnitOfMeasure");
            }
        }

        private int? monthOfSupply;
        public int? MonthOfSupply
        {
            get { return monthOfSupply; }
            set
            {
                monthOfSupply = value;
                NotifyPropertyChanged("MonthOfSupply");
            }
        }

        private int? dayOfSupply;
        public int? DayOfSupply
        {
            get { return dayOfSupply; }
            set
            {
                dayOfSupply = value;
                NotifyPropertyChanged("DayOfSupply");
            }
        }

        private int? yearOfSupply;
        public int? YearOfSupply
        {
            get { return yearOfSupply; }
            set
            {
                yearOfSupply = value;
                NotifyPropertyChanged("YearOfSupply");
            }
        }

        private int? monthOfExpiration;
        public int? MonthOfExpiration
        {
            get { return monthOfExpiration; }
            set
            {
                monthOfExpiration = value;
                NotifyPropertyChanged("MonthOfExpiration");
            }
        }

        private int? dayOfExpiration;
        public int? DayOfExpiration
        {
            get { return dayOfExpiration; }
            set
            {
                dayOfExpiration = value;
                NotifyPropertyChanged("DayOfExpiration");
            }
        }

        private int? yearOfExpiration;
        public int? YearOfExpiration
        {
            get { return yearOfExpiration; }
            set
            {
                yearOfExpiration = value;
                NotifyPropertyChanged("YearOfExpiration");
            }
        }

        private decimal purchasePrice;
        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set
            {
                purchasePrice = value;
                NotifyPropertyChanged("PurchasePrice");
            }
        }

        private decimal salePrice;
        public decimal SalePrice
        {
            get { return salePrice; }
            set
            {
                salePrice = value;
                NotifyPropertyChanged("SalePrice");
            }
        }
    }
}

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
                NotifyPropertyChanged("Display");
            }
        }

        private int? productID;
        public int? ProductID
        {
            get { return productID; }
            set
            {
                productID = value;
                NotifyPropertyChanged("StockProductID");
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
            }
        }
        // TODO: Delete unnecessary notify

        private int? monthOfExpiration;
        public int? MonthOfExpiration
        {
            get { return monthOfExpiration; }
            set
            {
                monthOfExpiration = value;
                NotifyPropertyChanged("MonthOfExpiration");
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
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
                NotifyPropertyChanged("Display");
            }
        }

        private decimal pricePerProduct;
        public decimal PricePerProduct
        {
            get { return pricePerProduct; }
            set
            {
                pricePerProduct = value;
                NotifyPropertyChanged("PricePerProduct");
                NotifyPropertyChanged("Display");
            }
        }

        public string Display
        {
            get { return $"ID: {productStockID}  |  PP: {purchasePrice}  |  " +
                    $"QTY: {quantity}  |  UM: {unitOfMeasure}  |  " +
                    $"DOS: {dayOfSupply}  |  MOS: {monthOfSupply}  |  YOS: {yearOfSupply}  |  " +
                    $"DOE: {dayOfExpiration}  |  MOE: {monthOfExpiration}  |  YOE:{yearOfExpiration}  |  " +
                    $"SP: {salePrice}  |  PPP: {pricePerProduct}"; }
        }
    }
}

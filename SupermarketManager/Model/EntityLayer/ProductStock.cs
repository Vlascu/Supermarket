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

        private DateTime supplyDate;
        public DateTime SupplyDate
        {
            get { return supplyDate; }
            set
            {
                supplyDate = value;
                NotifyPropertyChanged("SupplyDate");
            }
        }

        private DateTime expirationDate;
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set
            {
                expirationDate = value;
                NotifyPropertyChanged("ExpirationDate");
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

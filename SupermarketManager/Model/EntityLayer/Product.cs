using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.EntityLayer
{
    public class Product : BasePropertyChanged
    {
        private int? productID;
        public int? ProductId
        {
            get { return productID; }
            set
            {
                productID = value;
                NotifyPropertyChanged("ProductID");
                NotifyPropertyChanged("Display");
            }
        }
        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value;
                NotifyPropertyChanged("ProductName");
                NotifyPropertyChanged("Display");
            }
        }

        private int? barcode;
        public int? Barcode
        {
            get { return barcode; }
            set
            {
                barcode = value;
                NotifyPropertyChanged("Barcode");
                NotifyPropertyChanged("Display");
            }
        }

        private int? categoryID;
        public int? CategoryID
        {
            get { return categoryID; }
            set
            {
                categoryID = value;
                NotifyPropertyChanged("CategoryID");
                NotifyPropertyChanged("Display");
            }
        }

        private int? manufacturerID;

        public int? ManufacturerID
        {
            get { return manufacturerID; }
            set
            {
                manufacturerID = value;
                NotifyPropertyChanged("ManufacturerID");
                NotifyPropertyChanged("Display");
            }
        }
        public string Display
        {
            get { return $"P_ID: {productID}  |  M_ID: {ManufacturerID}  |  C_ID: {CategoryID}  |  Name: {ProductName}  |  Barcode: {Barcode} "; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Product product)
            {
                return Nullable.Equals(ProductId, product.ProductId) &&
                       string.Equals(ProductName, product.ProductName) &&
                       Nullable.Equals(Barcode, product.Barcode) &&
                       Nullable.Equals(CategoryID, product.CategoryID) &&
                       Nullable.Equals(ManufacturerID, product.ManufacturerID);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId, ProductName, Barcode, CategoryID, ManufacturerID);
        }

    }
}

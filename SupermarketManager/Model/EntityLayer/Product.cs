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
            }
        }
    }
}

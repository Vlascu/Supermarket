using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.EntityLayer
{
    public class ProductCategory : BasePropertyChanged
    {
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

        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                NotifyPropertyChanged("CategoryName");
                NotifyPropertyChanged("Display");
            }
        }
        private decimal totalValue;
        public decimal TotalValue
        {
            get { return totalValue; }
            set
            {
                totalValue = value;
                NotifyPropertyChanged("Display");
            }
        }
        public string Display
        {
            get { return $"ID: {categoryID}  |  Name: {categoryName}  |  Total Value: {totalValue}"; }
        }
    }
}

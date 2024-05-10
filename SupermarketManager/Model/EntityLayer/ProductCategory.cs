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
            }
        }
    }
}

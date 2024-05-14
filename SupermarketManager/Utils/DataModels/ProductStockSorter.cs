using SupermarketManager.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Utils.DataModels
{
    public class ProductStockSorter : IComparer<ProductStock>
    {
        public int Compare(ProductStock x, ProductStock y)
        {
            int yearComparison = ((int)x.YearOfSupply).CompareTo(y.YearOfSupply);
            if (yearComparison != 0)
            {
                return yearComparison;
            }

            int monthComparison = ((int)x.MonthOfSupply).CompareTo(y.MonthOfSupply);
            if (monthComparison != 0)
            {
                return monthComparison;
            }

            return ((int)x.DayOfSupply).CompareTo(y.DayOfSupply);

        }
    }
}

using SupermarketManager.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Utils
{
    public class OfferManager
    {
        public static int GetOfferPercentage(int daysUntilExpiration)
        {
            if (daysUntilExpiration == 0 && daysUntilExpiration == 1)
            {
                return 30;
            }
            else if (daysUntilExpiration > 1 && daysUntilExpiration <= 5)
            {
                return 20;
            }
            else if (daysUntilExpiration == 6 && daysUntilExpiration == 7)
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }
        public static bool CanGetOffer(ProductStock productStock)
        {
            if(productStock == null)
            {
                throw new ArgumentNullException("Can't check offer for a null stock.");
            }

            if(productStock.YearOfExpiration == DateTime.Now.Year && productStock.MonthOfExpiration == DateTime.Now.Month)
            {
                int daysUntilExpiration = (int)(productStock.DayOfExpiration - DateTime.Now.Day);

                if (daysUntilExpiration <= 7)
                {
                    int offerPercentage = GetOfferPercentage(daysUntilExpiration);

                    if(productStock.SalePrice - offerPercentage * productStock.SalePrice / 100 > productStock.PurchasePrice )
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

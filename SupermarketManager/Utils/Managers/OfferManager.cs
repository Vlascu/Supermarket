using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Utils
{
    public class OfferManager
    {
        public static int GetOfferPercentageByExpiration(int daysUntilExpiration)
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
        public static int GetOfferPercentageByLiquidation()
        {
            return 25;
        }
        public static OfferTypes CanGetOffer(ProductStock productStock)
        {
            bool liquidation = false;
            bool expiration = false;

            if (productStock == null)
            {
                throw new ArgumentNullException("Can't check offer for a null stock.");
            }

            if (productStock.Quantity < 10)
            {
                liquidation = true;
            }

            if (productStock.YearOfExpiration == DateTime.Now.Year && productStock.MonthOfExpiration == DateTime.Now.Month)
            {
                int daysUntilExpiration = (int)(productStock.DayOfExpiration - DateTime.Now.Day);

                if (daysUntilExpiration <= 7)
                {
                    int offerPercentage = GetOfferPercentageByExpiration(daysUntilExpiration);

                    if (productStock.SalePrice - offerPercentage * productStock.SalePrice / 100 > productStock.PurchasePrice)
                    {
                        expiration = true;
                    }
                }
            }

            if (liquidation && expiration)
            {
                return OfferTypes.BOTH;
            }
            else if (liquidation && !expiration)
            {
                return OfferTypes.STOCK_LIQUIDATION;
            }
            else if (!liquidation && expiration)
            {
                return OfferTypes.EXPIRATION;
            }

            return OfferTypes.NONE;
        }
    }
}

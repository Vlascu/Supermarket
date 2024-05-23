using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Utils.Managers
{
    public class StockValidityManager
    {
        public static bool CheckStocks()
        {
        
            int stocksDeleted = 0;

            AdministratorDAL administratorDAL = new AdministratorDAL();

            var stocks = administratorDAL.GetAllProductStocks();



            foreach (ProductStock stock in stocks)
            {
                DateTime expirationDate = new DateTime((int)stock.YearOfExpiration, (int)stock.MonthOfExpiration, (int)stock.DayOfExpiration);

                if (expirationDate < DateTime.Now)
                {
                    administratorDAL.DeleteProductStock(stock);
                    stocksDeleted++;
                }
            }
            if (stocksDeleted > 0)
            {
                return true;
            }
            return false;
        }
    }
}

﻿using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Utils.Managers
{
    public class StockValadityManager
    {
        public static bool CheckStocks()
        {
            // TODO: json system to store when the last check was done, so it only call this method once per day

            int stocksDeleted = 0;

            AdministratorDAL administratorDAL = new AdministratorDAL();

            var stocks = administratorDAL.GetAllProductStocks();

            foreach (ProductStock stock in stocks)
            {
                if (stock.YearOfExpiration < DateTime.Now.Year)
                {
                    administratorDAL.DeleteProductStock(stock);
                    stocksDeleted++;
                }
                else if (stock.MonthOfExpiration < DateTime.Now.Month)
                {
                    administratorDAL.DeleteProductStock(stock);
                    stocksDeleted++;
                }
                else if (stock.DayOfExpiration < DateTime.Now.Day)
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

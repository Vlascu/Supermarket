using SupermarketManager.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Utils
{
    public class DailyRevenue : BasePropertyChanged
    {
        private int dayNumber;
        public int DayNumber 
        {
            get {  return dayNumber; } set
            {
                dayNumber = value;
                NotifyPropertyChanged("DayNumber");
            }
        }
        private decimal totalAmount;
        public decimal TotalAmount
        {
            get { return totalAmount; } set
            {
                totalAmount = value;
                NotifyPropertyChanged("TotalAmount");
            }
        }
    }
}

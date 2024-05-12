using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.EntityLayer
{
    public class Offer : BasePropertyChanged
    {
        private int? offerID;
        public int? OfferID
        {
            get { return offerID; }
            set
            {
                offerID = value;
                NotifyPropertyChanged("OfferID");
            }
        }

        private string reason;
        public string Reason
        {
            get { return reason; }
            set
            {
                reason = value;
                NotifyPropertyChanged("Reason");
            }
        }

        private int? productID;
        public int? ProductID
        {
            get { return productID; }
            set
            {
                productID = value;
                NotifyPropertyChanged("ProductID");
            }
        }

        private decimal discountPercentage;
        public decimal DiscountPercentage
        {
            get { return discountPercentage; }
            set
            {
                discountPercentage = value;
                NotifyPropertyChanged("DiscountPercentage");
            }
        }

        private int? validFromDay;
        public int? ValidFromDay
        {
            get { return validFromDay; }
            set
            {
                validFromDay = value;
                NotifyPropertyChanged("ValidFromDay");
            }
        }
        private int? validFromMonth;
        public int? ValidFromMonth
        {
            get { return validFromMonth; }
            set
            {
                validFromMonth = value;
                NotifyPropertyChanged("ValidFromMonth");
            }
        }
        private int? validFromYear;
        public int? ValidFromYear
        {
            get { return validFromMonth; }
            set
            {
                validFromMonth = value;
                NotifyPropertyChanged("ValidFromYear");
            }
        }

        private int? validToDay;
        public int? ValidToDay
        {
            get { return validToDay; }
            set
            {
                validToDay = value;
                NotifyPropertyChanged("ValidToDay");
            }
        }
        private int? validToMonth;
        public int? ValidToMonth
        {
            get { return validToMonth; }
            set
            {
                validToMonth = value;
                NotifyPropertyChanged("ValidToMonth");
            }
        }
        private int? validToYear;
        public int? ValidToYear
        {
            get { return validToMonth; }
            set
            {
                validToMonth = value;
                NotifyPropertyChanged("ValidToYear");
            }
        }

    }
}

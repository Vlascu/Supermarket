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

        private DateTime validFromDate;
        public DateTime ValidFromDate
        {
            get { return validFromDate; }
            set
            {
                validFromDate = value;
                NotifyPropertyChanged("ValidFromDate");
            }
        }

        private DateTime validToDate;
        public DateTime ValidToDate
        {
            get { return validToDate; }
            set
            {
                validToDate = value;
                NotifyPropertyChanged("ValidToDate");
            }
        }
    }
}

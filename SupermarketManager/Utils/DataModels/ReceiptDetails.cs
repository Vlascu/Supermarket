using SupermarketManager.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Utils.DataModels
{
    public class ReceiptDetails : BasePropertyChanged
    {
        private int productQuantity;
        public int ProductQuantity
        {
            get { return productQuantity; }
            set
            {
                productQuantity = value;
                NotifyPropertyChanged("Display");
            }
        }
        private int productId;
        public int ProductId
        {
            get; set;
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                NotifyPropertyChanged("Display");
            }
        }
        private decimal subtotal;
        public decimal Subtotal
        {
            get { return subtotal; }
            set
            {
                subtotal = value;
                NotifyPropertyChanged("Display");
            }
        }
        private string offerType;
        public string OfferType
        {
            get { return offerType; }
            set
            {
                offerType = value;
                NotifyPropertyChanged("Display");
            }
        }
        private int offerPercentage;
        public int OfferPercentage
        {
            get { return offerPercentage; }
            set
            {
                offerPercentage = value;
                NotifyPropertyChanged("Display");
            }
        }
        public string Display
        {
            get { return $"Qty: {productQuantity}  |  Name: {productName}  |  Subtotal: {subtotal}  |  Offer Reason: {offerType}  |  Offer Value: {offerPercentage}%" ; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.EntityLayer
{
    public class Receipt_Product : BasePropertyChanged
    {
        private int? id;
        public int? Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }

        private int? receiptId;
        public int? ReceiptId
        {
            get { return receiptId; }
            set
            {
                receiptId = value;
                NotifyPropertyChanged("ReceiptId");
            }
        }

        private int? productId;
        public int? ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                NotifyPropertyChanged("ProductId");
            }
        }

        private int? quantity;
        public int? Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        private decimal subtotal;
        public decimal Subtotal
        {
            get { return subtotal; }
            set
            {
                subtotal = value;
                NotifyPropertyChanged("Subtotal");
            }
        }
    }
}

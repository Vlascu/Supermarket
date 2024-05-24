using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.BusinessLogicLayer
{
    public class CashierBLL
    {
        private readonly CashierDAL cashierDAL;

        public CashierBLL(CashierDAL cashierDAL)
        {
            this.cashierDAL = cashierDAL;
        }

        public Product GetProduct(string name, int barcode, int manufacturerId, int categoryId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Can't have a null or empty name.");
            }
            if (barcode == 0)
            {
                throw new ArgumentException("Can't have a 0 barcode");
            }
            if (manufacturerId == 0)
            {
                throw new ArgumentException("Can't have a 0 manufacturer id");
            }
            if (categoryId == 0)
            {
                throw new ArgumentException("Can't have a 0 category id");
            }

            Product product = new Product();
            product.ProductName = name;
            product.Barcode = barcode;
            product.ManufacturerID = manufacturerId;
            product.CategoryID = categoryId;

            return cashierDAL.GetProduct(product);
        }

        public decimal PutProductPriceOnReceipt(int productId, string productName, int quantity)
        {
            if (productId == 0)
            {
                throw new ArgumentException("Can't have a 0 product id");
            }
            if (String.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException("Can't have a null or empty product name");
            }
            if (quantity == 0)
            {
                throw new ArgumentException("Can't have a 0 quantity");
            }

            return cashierDAL.GetSelectedProductPrice(productId, productName, quantity);
        }
        public void SaveReceipt(Receipt receipt, List<ReceiptDetails> receiptDetails)
        {
            cashierDAL.AddReceipt(receipt, receiptDetails);

            foreach (var detail in  receiptDetails)
            {
                SellProduct(detail.ProductId, detail.ProductName, detail.ProductQuantity);
            }
        }
        
        private void SellProduct(int productId, string productName, int quantity)
        {
            if (productId == 0)
            {
                throw new ArgumentException("Can't have a 0 product id");
            }
            if (String.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException("Can't have a null or empty product name");
            }
            if (quantity == 0)
            {
                throw new ArgumentException("Can't have a 0 quantity");
            }

            cashierDAL.SellProduct(productId, productName, quantity);
        }
    }
}

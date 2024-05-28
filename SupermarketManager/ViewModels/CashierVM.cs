using Checkers.Utils;
using SupermarketManager.Model.BusinessLogicLayer;
using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils.DataModels;
using SupermarketManager.Views.Cashier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SupermarketManager.ViewModels
{
    public class CashierVM : BasePropertyChanged
    {
        private readonly Window currentWindow;
        private readonly CashierBLL cashierBLL;
        private readonly AdministratorBLL administratorBLL;
        public Window OpenedWindow { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<ReceiptDetails> ReceiptDetails { get; set; }
        public Dictionary<Product, int> addedProducts;
        public ReceiptDetails SelectedReceiptProduct { get; set; }

        private decimal totalValue;
        public decimal TotalValue
        {
            get { return totalValue; }
            set
            {
                totalValue = value;
                NotifyPropertyChanged("TotalValue");
            }
        }

        //Input biding
        public string ProductName { get; set; }
        public int ProductBarcode { get; set; } = 0;
        public int ManufacturerId { get; set; } = 0;
        public int CategoryId { get; set; } = 0;
        private string cashierName;

        private ICommand goBackCommand;
        private ICommand addCommand;
        private ICommand exitAddCommand;
        private ICommand saveCommand;
        private ICommand deleteCommand;
        private ICommand saveReceiptCommand;


        public ICommand SaveReceiptCommand
        {
            get
            {
                if (saveReceiptCommand == null)
                {
                    saveReceiptCommand = new ParameterlessRelayCommand(SaveReceipt, param => true);
                }
                return saveReceiptCommand;
            }
            set { saveReceiptCommand = value; }
        }
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new ParameterlessRelayCommand(Delete, param => true);
                }
                return deleteCommand;
            }
            set
            { deleteCommand = value; }
        }
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {

                    saveCommand = new ParameterlessRelayCommand(Save, param => true);
                }
                return saveCommand;
            }
            set
            {
                saveCommand = value;
            }
        }
        public ICommand ExitAddCommand
        {
            get
            {
                if (exitAddCommand == null)
                {
                    exitAddCommand = new ParameterlessRelayCommand(GoToCheckout, param => true);
                }
                return exitAddCommand;
            }
            set
            {
                exitAddCommand = value;
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new ParameterlessRelayCommand(Add, param => true);
                }
                return addCommand;
            }
            set { addCommand = value; }
        }
        public ICommand GoBackCommand
        {
            get
            {
                if (goBackCommand == null)
                {
                    goBackCommand = new ParameterlessRelayCommand(GoBack, param => true);
                }
                return goBackCommand;
            }
            set
            {
                goBackCommand = value;
            }
        }

        public CashierVM(Window currentWindow, string cashierName)
        {
            this.currentWindow = currentWindow;
            cashierBLL = new CashierBLL(new CashierDAL());
            administratorBLL = new AdministratorBLL(new AdministratorDAL());
            addedProducts = new Dictionary<Product, int>();
            ReceiptDetails = new ObservableCollection<ReceiptDetails>();
            this.cashierName = cashierName;
        }

        private void GoBack()
        {
            MainWindow mainWindow = new MainWindow();
            currentWindow.Close();
            mainWindow.ShowDialog();
        }
        private void Add()
        {
            Products = administratorBLL.GetAllProducts();

            AddProduct addProduct = new AddProduct(this);
            addProduct.ShowDialog();
        }
        private void GoToCheckout()
        {
            this.OpenedWindow.Close();
        }
        private void Save()
        {
            Product product = cashierBLL.GetProduct(ProductName, ProductBarcode, ManufacturerId, CategoryId);

            if (addedProducts.ContainsKey(product))
            {
                addedProducts[product]++;
            }
            else
            {
                addedProducts[product] = 1;
            }

            if (ReceiptDetails.Count > 0)
            {
                ReceiptDetails.Clear();
            }

            BuildReceipt();

            OpenedWindow.Close();
        }
        private void Delete()
        {
            if (SelectedReceiptProduct == null)
            {
                MessageBox.Show("Select a product to delete.");
            }
            else
            {
                var keysToRemove = new List<Product>();
                var keysToDecrement = new List<Product>();

                foreach (var product in addedProducts.Keys)
                {
                    if (SelectedReceiptProduct.ProductName == product.ProductName)
                    {
                        if (addedProducts[product] == 1)
                        {
                            keysToRemove.Add(product);
                        }
                        else
                        {
                            keysToDecrement.Add(product);
                        }
                    }
                }

                foreach (var product in keysToRemove)
                {
                    addedProducts.Remove(product);
                }

                foreach (var product in keysToDecrement)
                {
                    addedProducts[product]--;
                }

                ReceiptDetails.Clear();

                BuildReceipt();

            }
        }
        private void BuildReceipt()
        {
            TotalValue = 0;
            try
            {
                foreach (var addedProduct in addedProducts)
                {
                    var offerDetails = administratorBLL.GetOfferDetailsOfProduct((int)addedProduct.Key.ProductId);

                    ReceiptDetails details = new ReceiptDetails();
                    details.ProductQuantity = addedProduct.Value;
                    details.ProductName = addedProduct.Key.ProductName;
                    details.Subtotal = cashierBLL.PutProductPriceOnReceipt((int)addedProduct.Key.ProductId, addedProduct.Key.ProductName, addedProduct.Value);
                    details.OfferPercentage = offerDetails.Item2;
                    details.OfferType = offerDetails.Item1;
                    details.ProductId = (int)addedProduct.Key.ProductId;

                    TotalValue += details.Subtotal;

                    ReceiptDetails.Add(details);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void SaveReceipt()
        {
            if (ReceiptDetails.Count <= 0)
            {
                MessageBox.Show("First add products to the receipt.");
            }
            else
            {
                try
                {
                    Receipt receipt = new Receipt();
                    receipt.CashierName = cashierName;
                    receipt.AmountReceived = TotalValue;
                    receipt.DayOfIssuing = DateTime.Now.Day;
                    receipt.MonthOfIssuing = DateTime.Now.Month;
                    receipt.YearOfIssuing = DateTime.Now.Year;

                    cashierBLL.SaveReceipt(receipt, ReceiptDetails.ToList());

                    MessageBox.Show("Receipt saved succesfully");

                    addedProducts.Clear();
                    ReceiptDetails.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

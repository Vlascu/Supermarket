using SupermarketManager.Model.BusinessLogicLayer;
using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils.Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SupermarketManager.ViewModels
{
    public class AdminVM
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<ProductCategory> ProductCategories { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Manufacturer> Manufacturers { get; set; }
        public ObservableCollection<Offer> Offers { get; set; }
        public ObservableCollection<ProductStock> Stocks { get; set; }
        public ObservableCollection<Receipt> Receipts { get; set; }

        private readonly AdministratorBLL administratorBLL;
        private readonly Window window;

        public AdminVM(Window window)
        {
            this.window = window;
            this.administratorBLL = new AdministratorBLL(new AdministratorDAL());

            if(administratorBLL.CheckStocks())
            {
                MessageBox.Show("Some stocks expired and got deleted");
            } 
        }
    }
}

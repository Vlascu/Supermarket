using Checkers.Utils;
using SupermarketManager.Model.BusinessLogicLayer;
using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils;
using SupermarketManager.Utils.Managers;
using SupermarketManager.Views;
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
    public class AdminVM
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<ProductCategory> ProductCategories { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Manufacturer> Manufacturers { get; set; }
        public ObservableCollection<Offer> Offers { get; set; }
        public ObservableCollection<ProductStock> Stocks { get; set; }
        public ObservableCollection<Receipt> Receipts { get; set; }
        public string ProductName { get; set; }
        public int ProductBarcode { get; set; } = 0;
        public int ManufacturerId { get; set; } = 0;
        public int CategoryId { get; set; } = 0;

        private readonly AdministratorBLL administratorBLL;
        private readonly Window window;
        private Window subMenuWindow;

        public Window OpenedAddWindow { get; set; }
        public User SelectedUser { get; set; }
        public Product SelectedProduct { get; set; }
        public bool IsAdding { get; set; } = true;

        private ICommand goToUsersCommand;
        private ICommand goBackFromSubmenuCommand;
        private ICommand deleteUserCommand;
        private ICommand goBackToAuthCommand;
        private ICommand saveValuesCommand;
        private ICommand exitValuesCommand;
        private ICommand addCommand;
        private ICommand goToProductCommand;
        private ICommand deleteProductCommand;
        private ICommand updateCommand;

        public ICommand GoToUsersCommand
        {
            get
            {
                if (goToUsersCommand == null)
                {
                    goToUsersCommand = new ParameterlessRelayCommand(GoToUsers, param => true);
                }
                return goToUsersCommand;
            }
            set { goToUsersCommand = value; }
        }
        public ICommand GoBackFromSubmenuCommand
        {
            get
            {
                if (goBackFromSubmenuCommand == null)
                {
                    goBackFromSubmenuCommand = new ParameterlessRelayCommand(GoBackFromSubmenu, param => true);
                }
                return goBackFromSubmenuCommand;
            }
            set { goBackFromSubmenuCommand = value; }
        }
        public ICommand DeleteUserCommand
        {
            get
            {
                if (deleteUserCommand == null)
                {
                    deleteUserCommand = new ParameterlessRelayCommand(DeleteUser, param => true);
                }
                return deleteUserCommand;
            }
            set { deleteUserCommand = value; }
        }
        public ICommand GoBackToAuthCommand
        {
            get
            {
                if (goBackToAuthCommand == null)
                {
                    goBackToAuthCommand = new ParameterlessRelayCommand(GoBackToAuth, param => true);
                }
                return goBackToAuthCommand;
            }
            set { goBackToAuthCommand = value; }

        }
        public ICommand SaveValuesCommand
        {
            get
            {
                if (saveValuesCommand == null)
                {
                    saveValuesCommand = new ParameterlessRelayCommand(SaveValues, param => true);
                }
                return saveValuesCommand;
            }
            set
            {
                saveValuesCommand = value;
            }
        }
        public ICommand ExitValuesCommand
        {
            get
            {
                if (exitValuesCommand == null)
                {
                    exitValuesCommand = new ParameterlessRelayCommand(ExitValues, param => true);
                }
                return exitValuesCommand;
            }
            set
            {
                exitValuesCommand = value;
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new ParameterlessRelayCommand(AddProduct, param => true);
                }
                return addCommand;
            }
            set => addCommand = value;
        }
        public ICommand GoToProductCommand
        {
            get
            {
                if (goToProductCommand == null)
                {
                    goToProductCommand = new ParameterlessRelayCommand(GoToProduct, param => true);
                }
                return goToProductCommand;
            }
            set { goToProductCommand = value; }
        }
        public ICommand DeleteProductCommand
        {
            get
            {
                if (deleteProductCommand == null)
                {
                    deleteProductCommand = new ParameterlessRelayCommand(DeleteProduct, param => true);
                }
                return deleteProductCommand;
            }
            set
            {
                deleteProductCommand = value;
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new ParameterlessRelayCommand(UpdateProduct, param => true);
                }
                return updateCommand;
            }
            set
            {
                updateCommand = value;
            }
        }
        public AdminVM(Window window)
        {
            this.window = window;
            this.administratorBLL = new AdministratorBLL(new AdministratorDAL());

            if (administratorBLL.CheckStocks())
            {
                MessageBox.Show("Some stocks expired and got deleted");
            }
        }
        private void GoToUsers()
        {
            Users = administratorBLL.GetAllUsers();

            UserView userView = new UserView(this);
            subMenuWindow = userView;
            userView.ShowDialog();
        }
        private void GoBackFromSubmenu()
        {
            if (subMenuWindow != null)
            {
                subMenuWindow.Close();
            }
        }
        private void DeleteUser()
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("First select a user for deletion.");
            }
            else
            {
                try
                {
                    administratorBLL.DeleteUser(SelectedUser.Username);
                    Users.Remove(SelectedUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void GoBackToAuth()
        {
            MainWindow auth = new MainWindow();
            this.window.Close();
            auth.ShowDialog();
        }
        private void SaveValues()
        {
            try
            {
                OperationsType currentOpType = OperationsType.None;

                if (IsAdding)
                {
                    currentOpType = OperationsType.Insert;
                }
                else
                {
                    currentOpType = OperationsType.Update;
                }

                administratorBLL.ProductOperation(ProductName, ProductBarcode, ManufacturerId, CategoryId, currentOpType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ExitValues()
        {
            if (OpenedAddWindow != null)
            {
                OpenedAddWindow.Close();
            }
        }
        private void AddProduct()
        {
            NewProductView newProductView = new NewProductView(this);
            IsAdding = true;
            newProductView.ShowDialog();
        }
        private void GoToProduct()
        {
            Products = administratorBLL.GetAllProducts();

            ProductView productView = new ProductView(this);
            subMenuWindow = productView;
            productView.ShowDialog();
        }
        private void DeleteProduct()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("First select a product for deletion.");
            }
            else
            {
                try
                {
                    administratorBLL.ProductOperation(SelectedProduct.ProductName, (int)SelectedProduct.Barcode,
                        (int)SelectedProduct.ManufacturerID, (int)SelectedProduct.ProductId, OperationsType.Delete);
                    Products.Remove(SelectedProduct);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void UpdateProduct()
        {
            NewProductView newProductView = new NewProductView(this);
            IsAdding = false;
            newProductView.ShowDialog();
        }
    }
}

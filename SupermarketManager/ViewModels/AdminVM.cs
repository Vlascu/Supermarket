using Checkers.Utils;
using SupermarketManager.Model.BusinessLogicLayer;
using SupermarketManager.Model.DataAccessLayer;
using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils;
using SupermarketManager.Utils.Enums;
using SupermarketManager.Utils.Managers;
using SupermarketManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public string CategoryName { get; set; }
        public ViewType CurrentView { get; set; }

        private readonly AdministratorBLL administratorBLL;
        private readonly Window menuWindow;
        private Window subMenuWindow;

        public Window OpenedAddWindow { get; set; }
        public User SelectedUser { get; set; }
        public bool IsAdding { get; set; } = true;

        public Product SelectedProduct { get; set; }
        public ProductCategory SelectedCategory { get; set; }

        private ICommand goToUsersCommand;
        private ICommand goBackFromSubmenuCommand;
        private ICommand deleteUserCommand;
        private ICommand goBackToAuthCommand;
        private ICommand saveValuesCommand;
        private ICommand exitValuesCommand;
        private ICommand addCommand;
        private ICommand goToProductCommand;
        private ICommand deleteCommand;
        private ICommand updateCommand;
        private ICommand goToCategoryCommand;

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
                    addCommand = new ParameterlessRelayCommand(Add, param => true);
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
            {
                deleteCommand = value;
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new ParameterlessRelayCommand(Update, param => true);
                }
                return updateCommand;
            }
            set
            {
                updateCommand = value;
            }
        }
        public ICommand GoToCategoryCommand
        {
            get
            {
                if (goToCategoryCommand == null)
                {
                    goToCategoryCommand = new ParameterlessRelayCommand(GoToCategory, param => true);
                }
                return goToCategoryCommand;
            }
            set => goToCategoryCommand = value;
        }
        public AdminVM(Window window)
        {
            this.menuWindow = window;
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
            this.menuWindow.Close();
            auth.ShowDialog();
        }
        private void SaveValues()
        {
            try
            {
         
                if (CurrentView == ViewType.PRODUCT)
                {

                    if (IsAdding)
                    {
                        administratorBLL.ProductOperation(0, ProductName, ProductBarcode, ManufacturerId, CategoryId, OperationsType.Insert);
                        Products.Add(administratorBLL.GetFullProduct(ProductName, ProductBarcode, ManufacturerId, CategoryId));
                        MessageBox.Show("Product added");
                    }
                    else
                    {
                        administratorBLL.ProductOperation((int)SelectedProduct.ProductId
                            , ProductName, ProductBarcode, ManufacturerId, CategoryId, OperationsType.Update);
                        ObservableCollection<Product> newProducts = administratorBLL.GetAllProducts();

                        Products.Clear();

                        foreach (Product product in newProducts)
                        {
                            Products.Add(product);
                        }
                        MessageBox.Show("Product updated");
                    }
                }
                else if (CurrentView == ViewType.CATEGORY)
                {

                    if (IsAdding)
                    {
                        administratorBLL.CategoryOperation(CategoryName, 0, OperationsType.Insert);
                        ProductCategories.Add(administratorBLL.GetFullCategory(CategoryName));
                        MessageBox.Show("Category added.");

                    }
                    else
                    {
                        administratorBLL.CategoryOperation(CategoryName, (int)SelectedCategory.CategoryID,
                            OperationsType.Update);
                        ObservableCollection<ProductCategory> newCategories = administratorBLL.GetAllCategories();

                        ProductCategories.Clear();

                        foreach (ProductCategory category in newCategories)
                        {
                            ProductCategories.Add(category);
                        }

                        MessageBox.Show("Category updated.");
                    }

                }
                if (OpenedAddWindow != null)
                {
                    OpenedAddWindow.Close();
                }
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
        private void Add()
        {
            if (CurrentView == ViewType.PRODUCT)
            {
                NewProductView newProductView = new NewProductView(this);
                IsAdding = true;
                newProductView.ShowDialog();
            }
            else if (CurrentView == ViewType.CATEGORY)
            {
                NewCategoryView newCategoryView = new NewCategoryView(this);
                IsAdding = true;
                newCategoryView.ShowDialog();
            }

        }
        private void GoToProduct()
        {
            Products = administratorBLL.GetAllProducts();

            this.CurrentView = ViewType.PRODUCT;

            SupermarketOperations productView = new SupermarketOperations(this);
            subMenuWindow = productView;
            productView.ShowDialog();
        }
        private void GoToCategory()
        {
            ProductCategories = administratorBLL.GetAllCategories();

            this.CurrentView = ViewType.CATEGORY;
            SupermarketOperations categoryView = new SupermarketOperations(this);
            subMenuWindow = categoryView;
            categoryView.ShowDialog();
        }
        private void Delete()
        {
            if (CurrentView == ViewType.PRODUCT)
            {
                if (SelectedProduct == null)
                {
                    MessageBox.Show("First select a product for deletion.");
                }
                else
                {
                    try
                    {
                        administratorBLL.ProductOperation(0, SelectedProduct.ProductName, (int)SelectedProduct.Barcode,
                            (int)SelectedProduct.ManufacturerID, (int)SelectedProduct.ProductId, OperationsType.Delete);
                        Products.Remove(SelectedProduct);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            if (CurrentView == ViewType.CATEGORY)
            {
                if (SelectedCategory == null)
                {
                    MessageBox.Show("First select a category for deletion.");
                }
                else
                {
                    try
                    {
                        administratorBLL.CategoryOperation(SelectedCategory.CategoryName, 0, OperationsType.Delete);
                        ProductCategories.Remove(SelectedCategory);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        }
        private void Update()
        {
            if (CurrentView == ViewType.PRODUCT)
            {
                NewProductView newProductView = new NewProductView(this);
                IsAdding = false;
                newProductView.ShowDialog();
            }
            else if (CurrentView == ViewType.CATEGORY)
            {
                NewCategoryView newCategoryView = new NewCategoryView(this);
                IsAdding = false;
                newCategoryView.ShowDialog();
            }
        }
    }
}

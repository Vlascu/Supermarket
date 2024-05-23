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
        //Items
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<ProductCategory> ProductCategories { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Manufacturer> Manufacturers { get; set; }
        public ObservableCollection<Offer> Offers { get; set; }
        public ObservableCollection<ProductStock> Stocks { get; set; }
        public ObservableCollection<Receipt> Receipts { get; set; }
        public ObservableCollection<Product> ManufacturerProducts { get; set; }
        public ObservableCollection<DailyRevenue> DailyRevenuesList { get; set; }
 
        //Input binding
        public string ProductName { get; set; }
        public int ProductBarcode { get; set; } = 0;
        public int ManufacturerId { get; set; } = 0;
        public int CategoryId { get; set; } = 0;
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerCOO { get; set; }
        public decimal StockPurchasePrice { get; set; }
        public int StockQuantity { get; set; }
        public int StockProductId { get; set; }
        public int StockDOE { get; set; }
        public int StockMOE { get; set; }
        public int StockYOE { get; set; }
        public string StockUOM { get; set; }
        public int UserMOE { get; set; }
        public int UserYOE { get; set; }

        private readonly AdministratorBLL administratorBLL;
        private readonly Window menuWindow;
        private Window subMenuWindow;

        public ViewType CurrentView { get; set; }
        public Window OpenedAddWindow { get; set; }
        public bool IsAdding { get; set; } = true;

        //Update selected items
        public User SelectedUser { get; set; }
        public Product SelectedProduct { get; set; }
        public ProductCategory SelectedCategory { get; set; }
        public Manufacturer SelectedManufacturer { get; set; }
        public ProductStock SelectedStock { get; set; }

        //Commands
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
        private ICommand goToManufacturerCommand;
        private ICommand goToStockCommand;
        private ICommand goToManufacturerProducts;
        private ICommand goToDailyRevenues;

        public ICommand GoToDailyRevenues
        {
            get
            {
                if(goToDailyRevenues  == null)
                {
                    goToDailyRevenues = new ParameterlessRelayCommand(GoToRevenues, param=>true);
                }
                return goToDailyRevenues;
            }
            set
            {
                goToDailyRevenues = value;
            }
        }
        public ICommand GoToManufacturerProducts
        {
            get
            {
                if(goToManufacturerProducts == null)
                {
                    goToManufacturerProducts = new ParameterlessRelayCommand(ShowManufacturerProducts, param => true);
                }
                return goToManufacturerProducts;
            }
            set
            {
                goToManufacturerProducts = value;
            }
        }
        public ICommand GoToStockCommand
        {
            get
            {
                if (goToStockCommand == null)
                {
                    goToStockCommand = new ParameterlessRelayCommand(GoToStock, param => true);
                }
                return goToStockCommand;
            }
            set
            {
                goToStockCommand = value;
            }
        }
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
        public ICommand GoToManufacturerCommand
        {
            get
            {
                if (goToManufacturerCommand == null)
                {
                    goToManufacturerCommand = new ParameterlessRelayCommand(GoToManufacturer, param => true);
                }
                return goToManufacturerCommand;
            }
            set { goToManufacturerCommand = value; }

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


                        UpdateList<Product>(administratorBLL.GetAllProducts(), Products);

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

                        UpdateList<ProductCategory>(administratorBLL.GetAllCategories(), ProductCategories);

                        MessageBox.Show("Category updated.");
                    }

                }
                else if (CurrentView == ViewType.MANUFACTURER)
                {
                    if (IsAdding)
                    {
                        administratorBLL.ManufacturerOperation(0, ManufacturerName, ManufacturerCOO, OperationsType.Insert);

                        Manufacturers.Add(administratorBLL.GetFullManufacturer(ManufacturerName, ManufacturerCOO));
                        MessageBox.Show("Manufacturer added.");
                    }
                    else
                    {
                        administratorBLL.ManufacturerOperation((int)SelectedManufacturer.ManufacturerID, ManufacturerName,
                            ManufacturerCOO, OperationsType.Update);

                        UpdateList<Manufacturer>(administratorBLL.GetAllManufacturers(), Manufacturers);
                        MessageBox.Show("Manufacturer updated.");
                    }
                }
                else if (CurrentView == ViewType.STOCK)
                {
                    if (IsAdding)
                    {
                        administratorBLL.ProductStockOperation(0, StockPurchasePrice,
                            StockQuantity,
                            StockUOM,
                            new DateTime(StockYOE, StockMOE, StockDOE),
                            StockProductId,
                            OperationsType.Insert);

                        Stocks.Add(administratorBLL.GetFullStock(StockPurchasePrice,
                            StockQuantity,
                            StockUOM,
                            new DateTime(StockYOE, StockMOE, StockDOE),
                            StockProductId));
                        MessageBox.Show("Stock added.");
                    }
                    else
                    {
                        administratorBLL.ProductStockOperation((int)SelectedStock.ProductStockID, StockPurchasePrice,
                            StockQuantity,
                            StockUOM,
                            new DateTime(StockYOE, StockMOE, StockDOE),
                            StockProductId, OperationsType.Update);

                        UpdateList<ProductStock>(administratorBLL.GetAllProductStocks(), Stocks);
                        MessageBox.Show("Stock updated");
                    }
                } else if (CurrentView == ViewType.USER)
                {
                    DailyRevenuesList = new ObservableCollection<DailyRevenue>();

                    var foundValues = administratorBLL.GetDailyRevenueByMonthAndCashier(SelectedUser.Username, UserMOE, UserYOE);

                    if (foundValues == null || foundValues.Count ==0)
                    {
                        MessageBox.Show("No values found.");
                    } else
                    {
                        foreach (var foundValue in foundValues)
                        {
                            if (foundValue != null)
                            {
                                DailyRevenuesList.Add(foundValue);
                            }
                        }
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
            else if (CurrentView == ViewType.MANUFACTURER)
            {
                NewManufacturerView newManufacturerView = new NewManufacturerView(this);
                IsAdding = true;
                newManufacturerView.ShowDialog();
            }
            else if (CurrentView == ViewType.STOCK)
            {
                NewStockView newStockView = new NewStockView(this);
                IsAdding = true;
                newStockView.ShowDialog();
            }
        }
        private void GoToProduct()
        {
            Products = administratorBLL.GetAllProducts();

            this.CurrentView = ViewType.PRODUCT;

            OpenSubMenu();
        }
        private void GoToCategory()
        {
            ProductCategories = administratorBLL.GetAllCategories();

            this.CurrentView = ViewType.CATEGORY;

            OpenSubMenu();
        }
        private void GoToManufacturer()
        {
            Manufacturers = administratorBLL.GetAllManufacturers();

            this.CurrentView = ViewType.MANUFACTURER;

            OpenSubMenu();
        }
        private void GoToStock()
        {
            Stocks = administratorBLL.GetAllProductStocks();

            this.CurrentView = ViewType.STOCK;

            OpenSubMenu();
        }
        private void GoToRevenues()
        {
            if(SelectedUser == null)
            {
                MessageBox.Show("Please select a cashier");
            } else if (SelectedUser.UserType == "Admin")
            {
                MessageBox.Show("Please select a cashier");
            } else
            {
                DayRevenues  dayRevenues = new DayRevenues(this);
                this.CurrentView = ViewType.USER;
                dayRevenues.ShowDialog();
            }
        }
        private void OpenSubMenu()
        {
            SupermarketOperations supermarketOperationsView = new SupermarketOperations(this);
            subMenuWindow = supermarketOperationsView;
            supermarketOperationsView.ShowDialog();
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
            else if (CurrentView == ViewType.CATEGORY)
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
            else if (CurrentView == ViewType.MANUFACTURER)
            {
                if (SelectedManufacturer == null)
                {
                    MessageBox.Show("First select a manufacturer for deletion.");
                }
                else
                {
                    try
                    {
                        administratorBLL.ManufacturerOperation(0, SelectedManufacturer.Name, SelectedManufacturer.CountryOfOrigin, OperationsType.Delete);
                        Manufacturers.Remove(SelectedManufacturer);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (CurrentView == ViewType.STOCK)
            {
                if (SelectedStock == null)
                {
                    MessageBox.Show("First select a stock for deletion");
                }
                else
                {
                    try
                    {
                        administratorBLL.ProductStockOperation((int)SelectedStock.ProductStockID, SelectedStock.PurchasePrice,
                            (int)SelectedStock.Quantity,
                            SelectedStock.UnitOfMeasure,
                            new DateTime((int)SelectedStock.YearOfExpiration, (int)SelectedStock.MonthOfExpiration, (int)SelectedStock.DayOfExpiration),
                            (int)SelectedStock.ProductID, OperationsType.Delete);

                        Stocks.Remove(SelectedStock);
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
            else if (CurrentView == ViewType.MANUFACTURER)
            {
                NewManufacturerView newManufacturerView = new NewManufacturerView(this);
                IsAdding = false;
                newManufacturerView.ShowDialog();
            }
            else if (CurrentView == ViewType.STOCK)
            {
                NewStockView newStockView = new NewStockView(this);
                IsAdding = false;
                newStockView.ShowDialog();
            }
        }
        private void UpdateList<T>(ObservableCollection<T> newList, ObservableCollection<T> oldList)
        {
            oldList.Clear();

            foreach (T item in newList)
            {
                oldList.Add(item);
            }
        }
        private void ShowManufacturerProducts()
        {
            if(SelectedManufacturer == null)
            {
                MessageBox.Show("Select a manufacturer first.");
            } else
            {
                ManufacturerProducts = administratorBLL.GetProductsByManufacturer(SelectedManufacturer);

                ManufacturerProducts manufacturerProducts = new ManufacturerProducts(this);
                manufacturerProducts.ShowDialog();
            }
        }

    }
}

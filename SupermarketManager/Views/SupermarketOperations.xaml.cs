using SupermarketManager.Model.EntityLayer;
using SupermarketManager.Utils.Enums;
using SupermarketManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SupermarketManager.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class SupermarketOperations : Window
    {
        public SupermarketOperations(AdminVM adminVM)
        {
            InitializeComponent();
            DataContext = adminVM;

            if(adminVM.CurrentView == ViewType.PRODUCT)
            {
                ChangeListBoxBinding<Product>(adminVM.Products, "SelectedProduct");
            }
            else if (adminVM.CurrentView == ViewType.MANUFACTURER) 
            {
                ChangeListBoxBinding<Manufacturer>(adminVM.Manufacturers, "SelectedManufacturer");
            }
            else if(adminVM.CurrentView == ViewType.CATEGORY)
            {
                ChangeListBoxBinding<ProductCategory>(adminVM.ProductCategories, "SelectedCategory");
            }
            else if (adminVM.CurrentView == ViewType.STOCK)
            {
                ChangeListBoxBinding<ProductStock>(adminVM.Stocks, "SelectedStock");
            }
            else
            {
                MessageBox.Show("Invalid operations view");
            }
        }
        private void ChangeListBoxBinding<T>(ObservableCollection<T> items, string selectedItem)
        {

            var binding = new Binding
            {
                Source = items
            };

            ItemsListBox.SetBinding(ItemsControl.ItemsSourceProperty, binding);

            var itemBinding = new Binding
            {
                Path = new PropertyPath(selectedItem),
                Mode = BindingMode.TwoWay
            };
            ItemsListBox.SetBinding(ListBox.SelectedItemProperty, itemBinding);
        }
    }
}

using SupermarketManager.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for NewManufacturerView.xaml
    /// </summary>
    public partial class NewManufacturerView : Window
    {
        public NewManufacturerView(AdminVM adminVM)
        {
            InitializeComponent();
            adminVM.OpenedAddWindow = this;
            DataContext = adminVM;
        }
    }
}

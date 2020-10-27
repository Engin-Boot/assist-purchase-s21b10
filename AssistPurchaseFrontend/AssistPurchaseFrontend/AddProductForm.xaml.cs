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
using AssistPurchaseFrontend.Models;
using AssistPurchaseFrontend.Utility;

namespace AssistPurchaseFrontend
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddProductForm : Window
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private async void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            Add_Product product = new Add_Product();
            try
            {
                Products prod = new Products()
                {
                    Id = ProductId.Text,
                    Name = ProductName.Text,
                    Features = Features.Text.Split(',').ToArray(),
                    Services = Services.Text.Split(',').ToArray(),
                    DisplaySize = DisplaySize.Text,
                    OtherInfo = null
                };
                await product.AddAProduct(prod);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error Message : " + err.ToString());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow window = new ConfigurationWindow();
            window.Show();
            this.Close();
        }
    }
}

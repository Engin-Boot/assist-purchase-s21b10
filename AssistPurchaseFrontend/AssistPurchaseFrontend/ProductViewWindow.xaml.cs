using AssistPurchaseFrontend.Models;
using AssistPurchaseFrontend.Utility;
using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

namespace AssistPurchaseFrontend
{
    /// <summary>
    /// Interaction logic for ProductViewWindow.xaml
    /// </summary>
    public partial class ProductViewWindow : Window
    {
        private Products selectedProduct;
        public ProductViewWindow(Products product)
        {
            InitializeComponent();
            this.selectedProduct = product;
            
            Image Mole = new Image();
            string imgPath = @".\Images\" + product.Name + ".PNG";
            //if (File.Exists(Path.GetFullPath(imgPath)) ==false)
            //{
            //    imgPath = @".\Images\Demo Product.PNG";
            //}
            ImageSource MoleImage = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            Mole.Source = MoleImage;
            ProductImage.Children.Add(Mole);
            
            ProductId.Text = product.Id;
            ProductName.Text = product.Name;
            Features.Text = string.Join(",", product.Features);
            Services.Text = string.Join(",", product.Services);
            DisplaySize.Text = product.DisplaySize;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateProduct product = new UpdateProduct();
            selectedProduct = new Products()
            {
                Id = ProductId.Text,
                Name = ProductName.Text,
                Features = Features.Text.Split(','),
                Services = Services.Text.Split(','),
                DisplaySize = DisplaySize.Text,
                OtherInfo = null
            };
            await product.UpdateAProduct(selectedProduct);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow window = new ConfigurationWindow();
            window.Show();
            this.Close();
        }
    }
}

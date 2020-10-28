using AssistPurchaseFrontend.Models;
using AssistPurchaseFrontend.Utility;
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

namespace AssistPurchaseFrontend
{
    /// <summary>
    /// Interaction logic for CustomerDetailsForm.xaml
    /// </summary>
    public partial class CustomerDetailsForm : Window
    {
        public CustomerDetailsForm()
        {
            InitializeComponent();
            Products product = GetProductList.productSelected;
            ProductDescription.Text ="Product Id:- " + product.Id + Environment.NewLine + 
                                     "Product Name:- "+ product.Name + Environment.NewLine + 
                                     "Features:- "+ string.Join(",", product.Features) + Environment.NewLine + 
                                     "Services:- "+ string.Join(",", product.Services) + Environment.NewLine + 
                                     "Display Size:- "+string.Join(",", product.DisplaySize);
            Image img = new Image();
            string imgPath = @".\Images\" + product.Name + ".PNG";
            ImageSource productImage = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            img.Source = productImage;
            ImageGrid.Children.Add(img);
            ProductId.Text = product.Id;
        }

        public async Task getAllCustomerDetails()
        {
            AlertDataModel data = new AlertDataModel()
            {
                CustomerName = CustName.Text,
                CustomerContactNo = CustNo.Text,
                CustomerRegion = CustRegion.Text,
                CustomerEmailId = CustEmail.Text,
                ProductIdConfirmed = ProductId.Text
            };
            GetCustomerDetails details = new GetCustomerDetails();
            await details.productConfirmation(data);
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerServices window = new CustomerServices();
            window.Show();
            this.Close();
        }

        private async void Buy_Button_Click(object sender, RoutedEventArgs e)
        {
            await getAllCustomerDetails();
            MessageBoxResult messageBox = MessageBox.Show(GetCustomerDetails.notification);
            if (messageBox == MessageBoxResult.OK)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}

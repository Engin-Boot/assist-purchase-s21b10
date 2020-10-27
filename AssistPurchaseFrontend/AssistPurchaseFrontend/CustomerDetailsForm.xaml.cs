﻿using AssistPurchaseFrontend.Models;
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
            ProductDescription.Text = product.Id + Environment.NewLine + product.Name + Environment.NewLine + string.Join(",", product.Features) + Environment.NewLine + string.Join(",", product.Services) + Environment.NewLine + string.Join(",", product.DisplaySize);
            Image Mole = new Image();
            string imgPath = @".\Images\" + product.Name + ".PNG";
            ImageSource MoleImage = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            Mole.Source = MoleImage;
            ImageGrid.Children.Add(Mole);
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
            foreach (Window window in App.Current.Windows)
            {
                if (!window.IsActive)
                {
                    window.Show();
                }
            }
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

﻿using AssistPurchaseFrontend.Models;
using AssistPurchaseFrontend.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AssistPurchaseFrontend
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        private static string productIdSelected = "";
        public ConfigurationWindow()
        {
            InitializeComponent();
            AllProducts();
        }
        public async void AllProducts()
        {
            GetAllProducts products = new GetAllProducts();
            await products.GetAllProductsList();
            AddImages(GetAllProducts.productList);
        }

        public void AddImages(List<Products> productList)
        {
            int noOfProducts = productList.Count();
            double rowsingrid = noOfProducts / 4.0;
            int rows =((int)Math.Ceiling(rowsingrid));
            AddRowsInGrid(rows);
            AddColumnsInGrid();
            for(int i = 0; i < noOfProducts; i++)
            {
                int rowno = i / 4;
                int columnno = i % 4;
                ProductDashboard dashboard = new ProductDashboard();
                dashboard.ProductId.Content = productList[i].Id;
                dashboard.ProductId.Checked += ProductId_Checked;
                Image Mole = new Image();
                string imgPath = @".\Images\" + productList[i].Name + ".PNG";
                ImageSource MoleImage = new BitmapImage(new Uri(imgPath, UriKind.Relative));
                Mole.Source = MoleImage;
                Mole.Width = 200;
                Mole.Height = 200;
                dashboard.ImageGrid.Children.Add(Mole);
                Grid.SetRow(dashboard, rowno);
                Grid.SetColumn(dashboard, columnno);
                ProductImageGrid.Children.Add(dashboard);
            }
        }

        public void AddRowsInGrid(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                ProductImageGrid.RowDefinitions.Add(gridRow);
                ProductImageGrid.ShowGridLines = true;
            }
        }
        public void AddColumnsInGrid()
        {
            for (int i = 0; i < 4; i++)
            {
                ColumnDefinition gridColumn = new ColumnDefinition();
                ProductImageGrid.ColumnDefinitions.Add(gridColumn);
                ProductImageGrid.ShowGridLines = true;
            }
        }

        private void ProductId_Checked(object sender, RoutedEventArgs e)
        {
            productIdSelected = ((ToggleButton)sender).Content.ToString();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductForm newWindow = new AddProductForm();
            newWindow.Show();
            this.Close();
        }

        private async void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveAProduct product = new RemoveAProduct();
            await product.RemoveAProductByID(productIdSelected);
            this.RefreshButton_Click(sender, e);
        }

        private async void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            ViewParticularProduct product = new ViewParticularProduct();
            await product.GetAProductsByID(productIdSelected);
            Products productSelected = ViewParticularProduct.selectedProduct;
            ProductViewWindow viewWindow = new ProductViewWindow(productSelected);
            viewWindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow window = new ConfigurationWindow();
            window.Show();
            this.Close();
        }
    }
}

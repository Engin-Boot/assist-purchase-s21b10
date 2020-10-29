using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AssistPurchaseFrontend.Models;
using AssistPurchaseFrontend.Utility;

namespace AssistPurchaseFrontend
{
    /// <summary>
    /// Interaction logic for NotificationView.xaml
    /// </summary>
    public partial class NotificationView : UserControl
    {
        AlertDataModel _consumer = new AlertDataModel();
        public NotificationView(AlertDataModel consumer)
        {
            InitializeComponent();
            _consumer = consumer;
            this.Name.Text = consumer.CustomerName;
            this.Email.Text = consumer.CustomerEmailId;
            this.Contact.Text = consumer.CustomerContactNo;
            this.Region.Text = consumer.CustomerRegion;
            this.Product.Text = consumer.ProductIdConfirmed;
        }

        private async void Read_ClickAsync(object sender, RoutedEventArgs e)
        {
            MarkNotifAsRead marking = new MarkNotifAsRead();
            await marking.SendMarkNotifRead(_consumer.OrderId);
            if (marking.notifUpdated == true)
            {
                ((Panel)this.Parent).Children.Remove(this);
                
            }
        }
    }
}

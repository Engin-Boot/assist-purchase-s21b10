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
using System.Windows.Shapes;
using AssistPurchaseFrontend.Models;
using AssistPurchaseFrontend.Utility;

namespace AssistPurchaseFrontend
{
    /// <summary>
    /// Interaction logic for NewConsumerAlerts.xaml
    /// </summary>
    public partial class NewConsumerAlerts : Window
    {
        public NewConsumerAlerts()
        {
            InitializeComponent();
            AllAlerts();
        }
        public async void AllAlerts()
        {
            ConsumerNotification Notifs = new ConsumerNotification();
            await Notifs.GetConsumerNotificationsToBeSent();
            if(Notifs.NonNotified.Count > 0) 
            {
                AddNotifications(Notifs.NonNotified);
            }
            
        }
        public void AddNotifications(List<AlertDataModel> notifs)
        {
            int noOfNotifs = notifs.Count;
            AddRowsInGrid(noOfNotifs);
            for (int i = 0; i < noOfNotifs; i++)
            {
                NotificationView notifView = new NotificationView(notifs[i]);
                Grid.SetRow(notifView, i);
                NotificationGrid.Children.Add(notifView);
            }
        }

        public void AddRowsInGrid(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                NotificationGrid.RowDefinitions.Add(gridRow);
                NotificationGrid.ShowGridLines = true;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SalesWindow window = new SalesWindow();
            window.Show();
            this.Close();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            NewConsumerAlerts win = new NewConsumerAlerts();
            win.Show();
            this.Close();
        }
    }
}

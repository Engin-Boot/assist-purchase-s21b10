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
using AssistPurchaseFrontend.Utility;

namespace AssistPurchaseFrontend
{
    /// <summary>
    /// Interaction logic for CustomersInRegion.xaml
    /// </summary>
    public partial class CustomersInRegion : Window
    {
        //{ "north", "south", "east", "west", "unknown" };
        int[] regionCount = new int[5];
        public CustomersInRegion()
        {
            InitializeComponent();
            fillDetails();
        }
        public async void fillDetails()
        {
            SalesOperations sales = new SalesOperations();
            await sales.InitializeConsumers();
            Dictionary<string, int> dict = sales.GetNumberOfConsumersInEachRegion();
            string[] regions = new string[] { "north", "south", "east", "west", "unknown" };
            for (int i = 0; i < regions.Length; i++)
            {
                if (dict.ContainsKey(regions[i]))
                {
                    regionCount[i] = dict[regions[i]];
                }
            }
            this.north.Text = "" + regionCount[0];
            this.south.Text = "" + regionCount[1];
            this.east.Text = "" + regionCount[2];
            this.west.Text = "" + regionCount[3];
            this.unknown.Text = "" + regionCount[4];
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SalesWindow window = new SalesWindow();
            window.Show();
            this.Close();
        }

    }
}

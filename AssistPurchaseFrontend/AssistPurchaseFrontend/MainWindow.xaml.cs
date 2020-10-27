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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssistPurchaseFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerServices services = new CustomerServices();
            services.Show();
            this.Close();
        }

        private void Configure_Button_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow window = new ConfigurationWindow();
            window.Show();
            this.Close();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                window.Close();
            }
        }
    }
}

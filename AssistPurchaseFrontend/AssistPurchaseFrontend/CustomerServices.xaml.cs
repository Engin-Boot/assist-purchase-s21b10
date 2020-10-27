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
    /// Interaction logic for CustomerServices.xaml
    /// </summary>
    public partial class CustomerServices : Window
    {
        private int count = 0;
        public CustomerServices()
        {
            InitializeComponent();
            QuestionBlock block = new QuestionBlock();
            block.Choice_Question.Text = "Hi I am your shopping assistant.. click on the next button to view and choose various categories for the products..!!";
            panelForQuestion.Children.Add(block);
            
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (count == 4)
            {
                if (GetQuestions.choicesMade == "Yes,")
                {
                    GetProductList productList = new GetProductList();
                    await productList.getProductsMatchingTheChoices();
                    QuestionBlock display = productList.getQuestion();
                    panelForQuestion.Children.Add(display);
                    count = count + 1;
                }
                else
                {
                    GetQuestions getQuestions = new GetQuestions();
                    getQuestions.setPreviousQuestion();
                    panelForQuestion.Children.RemoveAt(count);
                    count = count - 1;
                }
            }
            else if (count > 4) 
            {
                CustomerDetailsForm form = new CustomerDetailsForm();
                form.Show();
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                GetQuestions getQuestions = new GetQuestions();
                QuestionBlock block = await getQuestions.Question();
                panelForQuestion.Children.Add(block);
                count = count + 1;
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (count == 0)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                GetQuestions getQuestions = new GetQuestions();
                getQuestions.setPreviousQuestion();
                panelForQuestion.Children.RemoveAt(count);
                count = count - 1;
            }
        }
    }
}

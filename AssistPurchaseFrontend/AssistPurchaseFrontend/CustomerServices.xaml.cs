﻿using AssistPurchaseFrontend.Utility;
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

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (count == 4)
            {
                QuestionAccordingToChoices();
            }
            else if (count > 4) 
            {
                CustomerDetailsForm form = new CustomerDetailsForm();
                form.Show();
                this.Close();
            }
            else
            {
                getNextQuestion();
            }
        }

        public async void getNextQuestion()
        {
            GetQuestions getQuestions = new GetQuestions();
            QuestionBlock block = await getQuestions.Question();
            if (block != null)
            {
                panelForQuestion.Children.Add(block);
                count += 1;
            }
        }

        public async void QuestionAccordingToChoices()
        {
            if (GetQuestions.choicesMade == "Yes,")
            {
                GetProductList productList = new GetProductList();
                await productList.GetProductsMatchingTheChoices(GetQuestions.question);
                QuestionBlock display = productList.GetQuestion();
                panelForQuestion.Children.Add(display);
                count += 1;
            }
            else
            {
                GetQuestions getQuestions = new GetQuestions();
                getQuestions.SetPreviousQuestion();
                panelForQuestion.Children.RemoveAt(count);
                count -= 1;
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (count == 0)
            {
                GetQuestions.question = new Models.RequestResponse();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                GetQuestions getQuestions = new GetQuestions();
                getQuestions.SetPreviousQuestion();
                panelForQuestion.Children.RemoveAt(count);
                count-= 1;
            }
        }
    }
}

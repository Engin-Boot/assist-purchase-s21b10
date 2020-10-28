using AssistPurchaseFrontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace AssistPurchaseFrontend.Utility
{
    class GetProductList
    {

        private static List<Products> productListByChoices = new List<Products>();
        private readonly static RequestResponse question = GetQuestions.question;
        public static Products productSelected = new Products();
        public async Task GetProductsMatchingTheChoices()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(question);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("api/product/questions/showproducts", data);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                productListByChoices = JsonConvert.DeserializeObject<List<Products>>(jsonContent);
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        public QuestionBlock GetQuestion()
        {
            QuestionBlock block = new QuestionBlock();
            block.Choice_Question.Text = "Choose products from the given options:-";
            AddChoices(block);
            return block;
        }

        public void AddChoices(QuestionBlock block)
        {
            foreach (Products product in productListByChoices)
            {
                ToggleButton b1 = new ToggleButton();
                string pathToImage =@".\Images\"+ product.Name + ".PNG";
                b1.Content = new Image
                {
                    Source = new BitmapImage(new Uri(pathToImage, UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center,
                };
                b1.Style = (Style)Application.Current.Resources["ImageButtonStyle"];
                b1.Click += B1_Click;
                block.ChoiceOptions.Children.Add(b1);
            }
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Image buttonImage = (Image)((ToggleButton)sender).Content;
            string[] splitPath = buttonImage.Source.ToString().Split('/');
            string buttonImageName = splitPath[splitPath.Length - 1];
            string productName = buttonImageName.Split('.')[0];
            SearchSelectedProductByName(productName);
        }
        private void SearchSelectedProductByName(string productName)
        {
            foreach(Products product in productListByChoices)
            {
                if(product.Name == productName)
                {
                    productSelected = product;
                }
            }
        }
    }
}

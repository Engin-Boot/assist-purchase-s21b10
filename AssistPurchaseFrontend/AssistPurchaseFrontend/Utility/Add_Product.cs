using AssistPurchaseFrontend.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AssistPurchaseFrontend.Utility
{
    public class Add_Product
    {
        public static bool isAdded = false; 
        public async Task AddAProduct(Products product)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonProductToBeAdded = JsonConvert.SerializeObject(product);
            var data = new StringContent(jsonProductToBeAdded, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/configureproducts/AddProduct", data);

            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result == "400")
                {
                    isAdded = false;
                    MessageBox.Show("Bad Request");
                }
                else
                {
                    isAdded = true;
                    MessageBox.Show("Product with ProductId:- " + product.Id + " has been successfully added");
                }
            }
            else
            {
                isAdded = false;
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
    }
}

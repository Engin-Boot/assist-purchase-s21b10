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
    class Add_Product
    {
        public async Task AddAProduct(Products product)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/configureproducts/AddProduct", data);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Product with ProductId:- " + product.Id + " has been successfully added");
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
    }
}

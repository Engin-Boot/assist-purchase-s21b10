﻿using AssistPurchaseFrontend.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AssistPurchaseFrontend.Utility
{
    public class UpdateProduct
    {
        public static bool productUpdated = false;
        public async Task UpdateAProduct(Products product)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonProductToBeUpdated = JsonConvert.SerializeObject(product);
            var data = new StringContent(jsonProductToBeUpdated, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("api/configureproducts/updateproduct/"+product.Id, data);

            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result == "404")
                {
                    productUpdated = false;
                    MessageBox.Show("No product exists");
                }
                else
                {
                    productUpdated = true;
                    MessageBox.Show("Product with ProductId" + product.Id + "has been successfully updated");
                }
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
    }
}

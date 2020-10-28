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
    class GetCustomerDetails
    {
        public static string notification;
        public async Task ProductConfirmation(AlertDataModel dataModel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(dataModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/alert/confirmationAlert", data);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                notification = jsonContent;
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
    }
}

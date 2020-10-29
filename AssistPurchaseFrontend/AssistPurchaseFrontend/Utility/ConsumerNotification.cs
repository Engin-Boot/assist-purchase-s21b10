using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AssistPurchaseFrontend.Models;
using Newtonsoft.Json;

namespace AssistPurchaseFrontend.Utility
{
    public class ConsumerNotification
    {
        public static List<AlertDataModel> NonNotified = new List<AlertDataModel>();

        public async Task GetConsumerNotificationsToBeSent()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/alert/NewConsumers");

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                NonNotified = JsonConvert.DeserializeObject<List<AlertDataModel>>(jsonContent);
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }


    }
}

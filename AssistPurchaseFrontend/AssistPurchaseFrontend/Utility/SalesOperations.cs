using AssistPurchaseFrontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace AssistPurchaseFrontend.Utility
{
    class SalesOperations
    {
        public static List<AlertDataModel> Consumers = new List<AlertDataModel>();

        public SalesOperations()
        {
            InitializeConsumers();
        }

        public async Task InitializeConsumers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/alert/Consumers");

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                Consumers = JsonConvert.DeserializeObject<List<AlertDataModel>>(jsonContent);
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        public Dictionary<string, int> GetNumberOfConsumersInEachRegion()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                { "east",0},
                { "west",0},
                { "north",0},
                { "south",0},
                { "unknown",0}
            };
            foreach (AlertDataModel i in Consumers)
            {
                string region = i.CustomerRegion.ToLower().Trim();
                if (dict.ContainsKey(region))
                {
                    dict[region]++;
                }
                else
                {
                    dict["unknown"]++;
                }
            }
            return dict;
        }
    }
}

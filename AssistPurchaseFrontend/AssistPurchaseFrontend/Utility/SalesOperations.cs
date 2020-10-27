using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssistPurchaseFrontend.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Windows;

namespace AssistPurchaseFrontend.Utility
{
    class SalesOperations
    {
        public static List <AlertDataModel> Consumers = new List<AlertDataModel>();

        public SalesOperations()
        {
            initializeConsumers();
        }

        public async Task initializeConsumers()
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

        public Dictionary<string,int> getNumberOfConsumersInEachRegion()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("east", 0);
            dict.Add("west", 0);
            dict.Add("north", 0);
            dict.Add("south", 0);
            dict.Add("unknown", 0);
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

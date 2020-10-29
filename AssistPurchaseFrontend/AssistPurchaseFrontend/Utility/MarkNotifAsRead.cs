using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AssistPurchaseFrontend.Utility
{
    class MarkNotifAsRead
    {
        public static bool productUpdated = false;
        public async Task SendMarkNotifRead(int orderId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = await client.GetAsync("api/alert/UpdateConsumerAlert/" + orderId);

            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result == "200")
                {
                    productUpdated = true;
                    MessageBox.Show("Marked As Read");
                }
                else
                {
                    productUpdated = false;
                    MessageBox.Show("No notif exists Kindly refresh");
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

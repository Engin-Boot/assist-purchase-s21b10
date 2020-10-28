using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace AssistPurchaseFrontend.Utility
{
    public class RemoveAProduct
    {
        public static bool isRemoved = false;
        public async Task RemoveAProductByID(string productId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.DeleteAsync("api/configureproducts/removeproduct/"+productId);

            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result == "404")
                {
                    isRemoved = false;
                    MessageBox.Show("No product exists");
                }
                else
                {
                    isRemoved = true;
                    MessageBox.Show("Product with ProductId" + productId + "has been successfully removed");
                }
            }
            else
            {
                isRemoved = false;
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
    }
}

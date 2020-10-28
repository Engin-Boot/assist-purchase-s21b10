using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace AssistPurchaseFrontend.Utility
{
    class RemoveAProduct
    {
        public async Task RemoveAProductByID(string productId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.DeleteAsync("api/configureproducts/removeproduct/"+productId);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Product with ProductId" + productId + "has been successfully removed");
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
    }
}

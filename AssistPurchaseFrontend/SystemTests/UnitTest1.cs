using AssistPurchaseFrontend.Utility;
using System;
using Xunit;

namespace SystemTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            GetAllProducts getAllProducts = new GetAllProducts();
            await getAllProducts.GetAllProductsList();
            var products = GetAllProducts.productList;
            Assert.NotEmpty(products);
        }
    }
}

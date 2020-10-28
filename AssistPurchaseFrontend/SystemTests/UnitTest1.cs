using AssistPurchaseFrontend.Models;
using AssistPurchaseFrontend.Utility;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace SystemTests
{
    public class UnitTest1
    {
        #region GetAllProducts
        [Fact]
        public async void Test1()
        {
            GetAllProducts getAllProducts = new GetAllProducts();
            await getAllProducts.GetAllProductsList();
            var products = GetAllProducts.productList;
            Assert.NotEmpty(products);
        }
        #endregion

        #region GetProductsByChoices
        [Fact]
        public async void Test2()
        {
            GetProductList getProductList = new GetProductList();
            RequestResponse choices = new RequestResponse()
            {
                Layer = "lastLayer",
                LayerMembers = new[] { "End" },
                ChoiceDictionary = new Dictionary<string, string[]>()
                {
                    { "startLayer", new[] { "" } },
                    { "Features", new[] { "Touch_Screen" } },
                    { "Services", new[] { "ESN" } },
                    { "DisplaySize", new[] { "upto 10" } }
                }
            };
            await getProductList.GetProductsMatchingTheChoices(choices);
            var products = GetProductList.productListByChoices;
            Assert.NotEmpty(products);
        }
        [Fact]
        public async void Test3()
        {
            GetProductList getProductList = new GetProductList();
            RequestResponse choices = new RequestResponse()
            {
                Layer = "lastLayer",
                LayerMembers = new[] { "End" },
                ChoiceDictionary = new Dictionary<string, string[]>()
                {
                    { "startLayer", new[] { "" } },
                    { "Features", new[] {"" } },
                    { "Services", new[] { "" } },
                    { "DisplaySize", new[] { "" } }
                }
            };
            await getProductList.GetProductsMatchingTheChoices(choices);
            var products = GetProductList.productListByChoices;
            Assert.Empty(products);
        }
        #endregion

        #region View Particular Product
        [Fact]
        public async void Test4()
        {
            ViewParticularProduct viewProduct = new ViewParticularProduct();
            await viewProduct.GetAProductsByID("P101");
            var product = ViewParticularProduct.selectedProduct;
            Assert.NotNull(product);
        }

        [Fact]
        public async void Test5()
        {
            ViewParticularProduct viewProduct = new ViewParticularProduct();
            await viewProduct.GetAProductsByID("P155");
            var product = ViewParticularProduct.selectedProduct;
            var serializedProduct = JsonConvert.SerializeObject(product);
            Products nullProduct = new Products();
            var serializedNullProduct = JsonConvert.SerializeObject(nullProduct);
            Assert.Equal(serializedNullProduct, serializedProduct);
        }
        #endregion

        #region Add Particular Product
        [Fact]
        public async void Test6()
        {
            GetAllProducts getAllProducts = new GetAllProducts();
            await getAllProducts.GetAllProductsList();
            var productsCount = GetAllProducts.productList.Count;
            Products product = new Products() 
            {
                 Id = "P114",
                 Name = "DemoProduct",
                 Features = new[] { "Touch_Screen"},
                 Services = new[] { "ESN"},
                 DisplaySize = "upto 10"
            };
            Add_Product addProduct = new Add_Product();
            await addProduct.AddAProduct(product);
            await getAllProducts.GetAllProductsList();
            var productsCountAfterAdding = GetAllProducts.productList.Count;
            Assert.Equal(productsCount + 1, productsCountAfterAdding);
        }

        [Fact]
        public async void Test7()
        {
            GetAllProducts getAllProducts = new GetAllProducts();
            await getAllProducts.GetAllProductsList();
            var productsCount = GetAllProducts.productList.Count;
            Products product = new Products()
            {
                Id = "P115",
                Name = "DemoProduct2",
                Features = new[] { "Alarm" },
                Services = new[] { "ESN" },
                DisplaySize = "upto 10"
            };
            Add_Product addProduct = new Add_Product();
            await addProduct.AddAProduct(product);
            await getAllProducts.GetAllProductsList();
            var productsCountAfterAdding = GetAllProducts.productList.Count;
            Assert.Equal(productsCount + 1, productsCountAfterAdding);
        }

        [Fact]
        public async void Test8()
        {
            GetAllProducts getAllProducts = new GetAllProducts();
            await getAllProducts.GetAllProductsList();
            var productsCount = GetAllProducts.productList.Count;
            Products product = new Products();
            Add_Product addProduct = new Add_Product();
            await addProduct.AddAProduct(product);
            await getAllProducts.GetAllProductsList();
            var productsCountAfterAdding = GetAllProducts.productList.Count;
            Assert.NotEqual(productsCount + 1, productsCountAfterAdding);
        }
        #endregion

        #region Update Particular Product
        [Fact]
        public async void Test9()
        {
            UpdateProduct updateProduct = new UpdateProduct();
            Products product = new Products()
            {
                Id = "P115",
                Name = "DemoProduct2",
                Features = new[] { "Touch_Screen","Alarm" },
                Services = new[] { "ESN" },
                DisplaySize = "upto 10"
            };
            await updateProduct.UpdateAProduct(product);
            Assert.True(UpdateProduct.productUpdated);
        }

        [Fact]
        public async void Test10()
        {
            UpdateProduct updateProduct = new UpdateProduct();
            Products product = new Products()
            {
                Id = "P125",
                Name = "DemoProduct",
                Features = new[] { "Touch_Screen", "Alarm" },
                Services = new[] { "ESN" },
                DisplaySize = "upto 10"
            };
            await updateProduct.UpdateAProduct(product);
            Assert.False(UpdateProduct.productUpdated);
        }
        #endregion

        #region Remove Particular Product
        [Fact]
        public async void Test11()
        {
            GetAllProducts getAllProducts = new GetAllProducts();
            await getAllProducts.GetAllProductsList();
            var productsCount = GetAllProducts.productList.Count;
            RemoveAProduct removeAProduct = new RemoveAProduct();
            await removeAProduct.RemoveAProductByID("P114");
            await getAllProducts.GetAllProductsList();
            var productsCountAfterRemoving = GetAllProducts.productList.Count;
            Assert.Equal(productsCount - 1, productsCountAfterRemoving);
        }

        [Fact]
        public async void Test12()
        {
            GetAllProducts getAllProducts = new GetAllProducts();
            await getAllProducts.GetAllProductsList();
            var productsCount = GetAllProducts.productList.Count;
            RemoveAProduct removeAProduct = new RemoveAProduct();
            await removeAProduct.RemoveAProductByID("P125");
            await getAllProducts.GetAllProductsList();
            var productsCountAfterRemoving = GetAllProducts.productList.Count;
            Assert.NotEqual(productsCount - 1, productsCountAfterRemoving);
        }
        #endregion
    }
}

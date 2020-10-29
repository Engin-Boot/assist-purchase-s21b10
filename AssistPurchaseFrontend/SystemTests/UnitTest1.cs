using AssistPurchaseFrontend.Models;
using AssistPurchaseFrontend.Utility;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
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
        [Fact]
        public void Test19()
        {
            GetProductList getProductList = new GetProductList();
            getProductList.SearchSelectedProductByName("Goldway G40E");
            var product = GetProductList.productSelected;
            Assert.NotNull(product);
        }
        [Fact]
        public void Test20()
        {
            GetProductList getProductList = new GetProductList();
            getProductList.SearchSelectedProductByName("ABC");
            string product = JsonConvert.SerializeObject(GetProductList.productSelected);
            string nullProduct = JsonConvert.SerializeObject( new Products());
            Assert.Equal(nullProduct,product);
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
            Products product = new Products();
            Add_Product addProduct = new Add_Product();
            await addProduct.AddAProduct(product);
            Assert.False(Add_Product.isAdded);
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
            RemoveAProduct removeAProduct = new RemoveAProduct();
            await removeAProduct.RemoveAProductByID("P125");
            Assert.False(RemoveAProduct.isRemoved);
        }
        #endregion

        #region Get Confirmation Alert
        [Fact]
        public async void Test13()
        {
            GetCustomerDetails alert = new GetCustomerDetails();
            AlertDataModel data = new AlertDataModel()
            {
                CustomerName = "Niki",
                CustomerContactNo = "9876543210",
                CustomerRegion = "South",
                CustomerEmailId = "niki@gmail.com",
                ProductIdConfirmed = "P106"
            };
            await alert.ProductConfirmation(data);
            string notification = GetCustomerDetails.notification;
            string expected = "\"Order with ProductId P106 has been Confirmed\"";
            Assert.Equal(expected, notification);
        }

        [Fact]
        public async void Test14()
        {
            GetCustomerDetails alert = new GetCustomerDetails();
            AlertDataModel data = new AlertDataModel()
            {
                CustomerName = "Niki",
                CustomerContactNo = "98765430",
                CustomerRegion = "South",
                CustomerEmailId = "niki@gmail.com",
                ProductIdConfirmed = "P106"
            };
            await alert.ProductConfirmation(data);
            string notification = GetCustomerDetails.notification;
            string expected = "";
            Assert.Equal(expected, notification);
        }
        #endregion

        #region Get Next Question
        [Fact]
        public async void Test15()
        {
            GetQuestions getQuestions = new GetQuestions();
            await getQuestions.GetNextQuestions(new[] { "Touch_Screen","Alarm"});
            string serializedQuestion = JsonConvert.SerializeObject(GetQuestions.question);
            string serializedNullQuestion = JsonConvert.SerializeObject(new RequestResponse());
            Assert.NotEqual(serializedQuestion,serializedNullQuestion);
        }
        [Fact]
        public async void Test16()
        {
            GetQuestions getQuestions = new GetQuestions();
            await getQuestions.GetNextQuestions(new[] {""});
            string serializedQuestion = JsonConvert.SerializeObject(GetQuestions.question);
            string serializedNullQuestion = JsonConvert.SerializeObject(new RequestResponse());
            Assert.NotEqual(serializedNullQuestion,serializedQuestion);
        }
        #endregion

        #region Sales Operations
        [Fact]
        public async void Test17()
        {
            SalesOperations salesOperations = new SalesOperations();
            await salesOperations.InitializeConsumers();
            List<AlertDataModel> consumers =  SalesOperations.Consumers;
            Assert.NotEmpty(consumers);
        }
        [Fact]
        public void Test18()
        {
            SalesOperations salesOperations = new SalesOperations();
            Dictionary<string, int> dict = salesOperations.GetNumberOfConsumersInEachRegion();
            Assert.NotEmpty(dict);
        }
        #endregion
    }
}

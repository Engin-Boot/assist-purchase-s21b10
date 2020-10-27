using AssistPurchaseCaseStudy.Models;
using AssistPurchaseCaseStudy.Repository;
using AssistPurchaseCaseStudy.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchaseCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductRepository _repository;
        readonly IRequestResponseHandling _requestResponseHandling = new RequestResponseHandling();
        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }

        //POST: api/<ProductController>/questions
        [HttpPost("questions")]
        public RequestResponse GetNextQuestion([FromBody] RequestResponse recievedResponse)
        {
            var sendResponse = new RequestResponse();
            var requestvalidator = new RequestResponseValidation();
            if (requestvalidator.IsRequestResponseCorrect(recievedResponse))
            {
                var suggestionPathObj = new SuggestionPaths();
                sendResponse.Layer = suggestionPathObj.NextLayer(recievedResponse.Layer);
                if (recievedResponse.Layer == "startLayer")
                {
                    sendResponse.LayerMembers = suggestionPathObj.NextLayerMembers(new[] { sendResponse.Layer });
                }
                else
                {
                    sendResponse.LayerMembers = suggestionPathObj.NextLayerMembers(recievedResponse.ChoiceDictionary[recievedResponse.Layer]);
                }
                sendResponse.ChoiceDictionary = recievedResponse.ChoiceDictionary;
            }
            else
            {
                sendResponse.Layer = "Invalid RequestResponse Sent";
            }

            return sendResponse;
        }

        //GET: api/<ProductController>/questions
        [HttpGet("questions")]
        public RequestResponse GetSampleRequestResponse()
        {
            var sendResponse = _requestResponseHandling.GetSampleResponse();
            return sendResponse;
        }

        //GET: api/<ProductController>/questions/showproducts
        [HttpPost("questions/showproducts")]
        public IEnumerable<Products> Get([FromBody] RequestResponse recievedResponse)
        {
            var requestvalidator = new RequestResponseValidation();
            if (requestvalidator.IsGetProductRequestCorrect(recievedResponse))
            {
                return this._repository.GetAllProductsBasedOnQuestions(recievedResponse.ChoiceDictionary);
            }
            else
            {
                return new List<Products>() { new Products("Invalid GetProductRequest") };
            }
        }
    }
}

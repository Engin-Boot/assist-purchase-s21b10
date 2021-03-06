using System.Collections.Generic;
using System.Linq;
using System.Net;
using AssistPurchaseCaseStudy.Utility;
using Microsoft.AspNetCore.Mvc;

namespace AssistPurchaseCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        readonly Repository.IAlertRepository _alertDataBaseRepository;

        public AlertController(Repository.IAlertRepository repository)
        {
            this._alertDataBaseRepository = repository;
        }
        // GET: api/<AlertController>
        [HttpGet("Consumers")]
        public IEnumerable<Models.AlertDataModel> Get()
        {
            return this._alertDataBaseRepository.GetCustomers();
        }

        // POST api/<AlertController>
        [HttpPost("ConfirmationAlert")]
        public ActionResult Post([FromBody] Models.AlertDataModel dataModel)
        {
            Validation validations = new Validation();
            bool response = validations.CheckValidity(dataModel);
            if (response == false)
            {
                return BadRequest("Please Enter Valid Details");
            }
            else
            {
                this._alertDataBaseRepository.Add(dataModel);
                string message = "Order with ProductId " + dataModel.ProductIdConfirmed + " has been Confirmed";
                return Ok(message);
            }
        }
        [HttpGet("Consumers/{region}")]
        public ActionResult Get(string region)
        {
            var customers = this._alertDataBaseRepository.GetRegionSpecificCustomers(region);
            if (customers.Any())
            {
                return Ok(customers);
            }
            else
            {
                return NotFound("No Customers");
            }
        }
        [HttpGet("NewConsumers")]
        public ActionResult NewConsumers()
        {
            var customers = this._alertDataBaseRepository.GetNewCustomers();
            if (customers.Any())
            {
                return Ok(customers);
            }
            else
            {
                return NotFound("No Customers");
            }
        }

        [HttpGet("UpdateConsumerAlert/{orderId}")]
        public HttpStatusCode Put(int orderId)
        {
            if (!_alertDataBaseRepository.CheckConsumerExist(orderId))
                return HttpStatusCode.BadRequest;
            bool flag = this._alertDataBaseRepository.UpdateConsumerAlert(orderId);
            if (flag == false)
            {
                return HttpStatusCode.NotFound;

            }
            else
            {
                return HttpStatusCode.OK;
            }
        }

    }
}

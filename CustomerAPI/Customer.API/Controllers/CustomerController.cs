using Customer.API.Filters;
using Customer.Domain.DTOs;
using Customer.Domain.Helpers;
using Customer.Domain.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUtility _util;
        public CustomerController(ICustomerService customerService, IUtility util)
        {
            _customerService = customerService;
            _util = util;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetCustomerResponseData>>> GetCustomers()
        {
            try
            {

                var rspdata = await _customerService.GetAllCustomers();
               // var response = new List<GetCustomerResponseData>();

                  return Ok(rspdata.Data.ToList());
                // var statusCode = _util.GetStatusCode(response.Code);
                //return StatusCode(statusCode, response);


            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500, new ApiResponse() { Code = "96", Description = "System malfunction" });
            }
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<GetAllCustomerResponse>> GetCustomer(int ID)
        {
            try
            {
                var response = await _customerService.GetCustomer(ID);
                var statusCode = _util.GetStatusCode(response.Code);

                return StatusCode(statusCode, response);



            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500, new ApiResponse() { Code = "96", Description = "System malfunction" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddCustomer([FromBody] CreateCustomerRequest request)
        {
            try
            {
                CreateCustomerValidator validator = new CreateCustomerValidator();
                ValidationResult results = validator.Validate(request);

                if (!results.IsValid)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var failure in results.Errors)
                    {
                        sb.Append("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }

                    return BadRequest(new ApiResponse() { Code = "26", Description = sb.ToString() });
                }
                
                var response = await _customerService.AddCustomer(request);
                var statusCode = _util.GetStatusCode(response.Code);

                return StatusCode(statusCode, response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500, new ApiResponse() { Code = "96", Description = "System malfunction" });
            }
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> UpdateCustomer([FromBody] UpdateCustomerRequest request)
        {
            try
            {
                UpdateCustomerValidator validator = new UpdateCustomerValidator();
                ValidationResult results = validator.Validate(request);

                if (!results.IsValid)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var failure in results.Errors)
                    {
                        sb.Append("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }

                    return BadRequest(new ApiResponse() { Code = "26", Description = sb.ToString() });
                }

                var response = await _customerService.UpdateCustomer(request);
                var statusCode = _util.GetStatusCode(response.Code);

                return StatusCode(statusCode, response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500, new ApiResponse() { Code = "96", Description = "System malfunction" });
            }
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<ApiResponse>> DeleteCustomer(int ID)
        {
            try
            {
                var response = await _customerService.DeleteCustomer(ID);
                var statusCode = _util.GetStatusCode(response.Code);

                return StatusCode(statusCode, response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500, new ApiResponse() { Code = "96", Description = "System malfunction" });
            }
        }
    }
}

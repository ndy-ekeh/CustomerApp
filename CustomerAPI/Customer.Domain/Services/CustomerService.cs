using Customer.Domain.DTOs;
using Customer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<ApiResponse> AddCustomer(CreateCustomerRequest request)
        {
            var result = await _customerRepo.AddCustomer(request);

            if(result == -2)
            {
                return new ApiResponse
                {
                    Code = "99",
                    Description = "System Malfunction"
                };
            }

            return new ApiResponse
            {
                Code = "00",
                Description = "Success"
            };
        }

        public async Task<ApiResponse> UpdateCustomer(UpdateCustomerRequest request)
        {
            var result = await _customerRepo.UpdateCustomer(request);

            if (result == -2)
            {
                return new ApiResponse
                {
                    Code = "99",
                    Description = "System Malfunction"
                };
            }

            if (result == 0)
            {
                return new ApiResponse
                {
                    Code = "25",
                    Description = "Record not found"
                };
            }

            return new ApiResponse
            {
                Code = "00",
                Description = "Success"
            };
        }

        public async Task<ApiResponse> DeleteCustomer(int ID)
        {
            var result = await _customerRepo.DeleteCustomer(ID);

            if (result == -2)
            {
                return new ApiResponse
                {
                    Code = "99",
                    Description = "System Malfunction"
                };
            }

            if (result == 0)
            {
                return new ApiResponse
                {
                    Code = "25",
                    Description = "Record not found"
                };
            }

            return new ApiResponse
            {
                Code = "00",
                Description = "Success"
            };
        }

        public async Task<GetCustomerResponse> GetCustomer(int ID)
        {
            var query = "Select TOP(1) ID, FirstName, LastName, AccountNumber, HseAddress, PhoneNo, Email, CustomerCode, " +
                "DateCreated from tbl_CustomerDetails where ID = @ID";

            var result = await _customerRepo.GetCustomer(query, ID);

            if (result == null)
            {
                return new GetCustomerResponse
                {
                    Code = "99",
                    Description = "System Malfunction"
                };
            }

            if (result.Count > 0)
            {
                return new GetCustomerResponse
                {
                    Code = "00",
                    Description = "Success",
                    Data = result[0]
                };
            }

            return new GetCustomerResponse
            {
                Code = "25",
                Description = "Record Not Found"
            };

        }

        public async Task<GetAllCustomerResponse> GetAllCustomers()
        {
            var query = @"Select ID, FirstName, LastName, AccountNumber, HseAddress, PhoneNo, Email, CustomerCode from tbl_CustomerDetails ";

            var result = await _customerRepo.GetCustomer(query);

            if (result == null)
            {
                return new GetAllCustomerResponse
                {
                    Code = "99",
                    Description = "System Malfunction"
                };
            }

            if (result.Count == 0)
            {
                return new GetAllCustomerResponse
                {
                    Code = "25",
                    Description = "Record Not Found",
                };
            }

            return new GetAllCustomerResponse
            {
                Code = "00",
                Description = "Success",
                Data = result
            };
        }

    }
}

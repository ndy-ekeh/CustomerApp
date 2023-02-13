using Customer.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Services
{
    public interface ICustomerService
    {
        Task<GetAllCustomerResponse> GetAllCustomers();
        Task<GetCustomerResponse> GetCustomer(int ID);
        Task<ApiResponse> DeleteCustomer(int ID);
        Task<ApiResponse> AddCustomer(CreateCustomerRequest request);
        Task<ApiResponse> UpdateCustomer(UpdateCustomerRequest request);
    }
}

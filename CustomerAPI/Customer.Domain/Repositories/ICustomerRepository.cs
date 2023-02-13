using Customer.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomer(CreateCustomerRequest request);
        Task<int> UpdateCustomer(UpdateCustomerRequest request);
        Task<List<GetCustomerResponseData>?> GetCustomer(string query, int ID = 0);
        Task<int> DeleteCustomer(int ID);
    }
}

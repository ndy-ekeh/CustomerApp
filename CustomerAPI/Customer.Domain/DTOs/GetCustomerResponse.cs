using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.DTOs
{
    public class GetCustomerResponseData:CreateCustomerRequest
    {
        public int ID { get; set; }
       // public DateTime DateCreated { get; set; }
    }

    public class GetCustomerResponse:ApiResponse
    {
        public GetCustomerResponseData? Data { get; set; }
    }
}

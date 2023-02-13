using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.DTOs
{
    public class CreateCustomerRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AccountNumber { get; set; }
        public string? HouseAddress { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public long CustomerCode { get; set; }

    }
}

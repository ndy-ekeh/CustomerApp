using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.DTOs
{
    public class UpdateCustomerRequest:CreateCustomerRequest
    {
        public int ID { get; set;}
    }
}

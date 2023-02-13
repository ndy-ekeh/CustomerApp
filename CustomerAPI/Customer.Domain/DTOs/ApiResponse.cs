using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.DTOs
{
    public class ApiResponse
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
    }
}

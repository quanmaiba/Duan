using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaynhanh3s.Domain.Request.Customer
{
    public class CustomerRegister : SpCustomerRegister
    {
        public string GRecaptchaResponse { get; set; }
    }
}

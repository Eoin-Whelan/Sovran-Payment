using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Model
{
    public class PaymentResponse
    {
        public string Result
        {
            get; set;
        }
        public string ValidationCode
        {
            get; set;
        }
        public PaymentResponse()
        {

        }
    }
}

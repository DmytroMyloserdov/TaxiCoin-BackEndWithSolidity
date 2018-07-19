using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.RequestObjectPatterns
{
    public class CreatePaymentPattern
    {
        public UInt64 Value { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }
        public string PassPhrase { get; set; }
    }
}

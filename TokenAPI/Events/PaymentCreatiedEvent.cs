using Nethereum.ABI.FunctionEncoding.Attributes;
using System;

namespace TokenAPI.Events
{
    public class PaymentCreatiedEvent
    {
        [Parameter("uint", "orderId", 1, true)]
        public UInt64 OrderID { get; set; }

        [Parameter("address", "customer", 2, true)]
        public string Sender { get; set; }

        [Parameter("uint", "value", 3, false)]
        public UInt64 Value { get; set; }
    }
}

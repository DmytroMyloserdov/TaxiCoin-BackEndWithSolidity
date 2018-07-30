using System;

namespace App.RequestObjectPatterns
{
     public class DepositControllerPattern : IControllerPattern
    {
        public string Sender { get; set; }
        public string Password { get; set; }
        public string PassPhrase { get; set; }
        public UInt64 Value { get; set; }
        public UInt64 Gas { get; set; } = 2100000;
    }
}

using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class PaymentController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Create(UInt64 id, [FromBody] CreatePaymentPattern req)
        {
            var contractFunctions = Globals.GetInstance().ContractFunctions;

            var senderAddress = Crypto.DecryptString(req.Sender, req.PassPhrase);
            var password = Crypto.DecryptString(req.Password, req.PassPhrase);

            var result = contractFunctions.CallFunctionByName<UInt64>(senderAddress, password, FunctionNames.CreatePayment, id, req.Value).Result;

            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
            return response;
        }
    }
}

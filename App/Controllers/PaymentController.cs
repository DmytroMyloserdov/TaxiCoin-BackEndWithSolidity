using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class PaymentController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Create(UInt64 id, [FromBody] CreatePaymentPattern req)
        {
            var result = TokenFunctionsResults<UInt64, CreatePaymentPattern>.Invoke(id, req, FunctionNames.CreatePayment);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}

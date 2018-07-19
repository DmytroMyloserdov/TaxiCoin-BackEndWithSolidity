using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetOrderStatus(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            var result = TokenFunctionsResults<UInt64, DefaultControllerPattern>.Invoke(id, req, FunctionNames.GetOrder);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }

        [HttpPut]
        public HttpResponseMessage CompleteOrder(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            var result = TokenFunctionsResults<UInt64, DefaultControllerPattern>.Invoke(id, req, FunctionNames.CompleteOrder);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}

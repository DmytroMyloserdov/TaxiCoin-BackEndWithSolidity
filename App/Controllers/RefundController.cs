using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class RefundController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Create(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            var result = TokenFunctionsResults<int, DefaultControllerPattern>.Invoke(id, req, FunctionNames.Refund);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage Approve(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            var result = TokenFunctionsResults<int, DefaultControllerPattern>.Invoke(id, req, FunctionNames.ApproveRefund);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}

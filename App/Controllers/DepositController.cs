using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class DepositController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody] DefaultControllerPattern req)
        {
            var result = TokenFunctionsResults<UInt64, DefaultControllerPattern>.InvokeByCall(req, FunctionNames.Deposit);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}

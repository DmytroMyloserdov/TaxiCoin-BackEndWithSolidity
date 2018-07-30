using App.RequestObjectPatterns;
using App.Utils;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class DepositController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody] DepositControllerPattern req)
        {
            TransactionReceipt result;
            try
            {
                result = TokenFunctionsResults<UInt64, DepositControllerPattern>.InvokeByTransaction(req, FunctionNames.Deposit, Value: req.Value, Gas: req.Gas);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, true));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}

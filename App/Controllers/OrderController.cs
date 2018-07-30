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
    public class OrderController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetOrder(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            TransactionReceipt result;
            try
            {
                result = TokenFunctionsResults<TransactionReceipt, DefaultControllerPattern>.InvokeByTransaction(req, FunctionNames.GetOrder, req.Gas, funcParametrs: id);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, false));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage CompleteOrder(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            TransactionReceipt result;
            try
            {
                result = TokenFunctionsResults<int, DefaultControllerPattern>.InvokeByTransaction(req, FunctionNames.CompleteOrder, req.Gas, funcParametrs: id);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, false));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}

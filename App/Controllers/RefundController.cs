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
    public class RefundController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Create(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            TransactionReceipt result;
            try
            {
                result = TokenFunctionsResults<int, DefaultControllerPattern>.InvokeByTransaction(req, FunctionNames.Refund, req.Gas, funcParametrs: id);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, false));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage Approve(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            TransactionReceipt result;
            try
            {
                result = TokenFunctionsResults<int, DefaultControllerPattern>.InvokeByTransaction(req, FunctionNames.ApproveRefund, req.Gas, funcParametrs: id);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, false));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage DisApprove(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            TransactionReceipt result;
            try
            {
                result = TokenFunctionsResults<int, DefaultControllerPattern>.InvokeByTransaction(req, FunctionNames.DisApproveRefund, req.Gas, funcParametrs: id);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, false));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}

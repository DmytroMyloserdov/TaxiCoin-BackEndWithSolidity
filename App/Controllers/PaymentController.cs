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
    public class PaymentController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetById(UInt64 id, [FromBody] DefaultControllerPattern req)
        {
            Crypto.DecryptTwoStringsAndGetContractFunctions(out string senderAddress, req.Sender, out string password, req.Password, req.PassPhrase, out ContractFunctions contractFunctions);
            Payment res;
            try
            {
                res = contractFunctions.DeserializePaymentById(senderAddress, password, id).Result;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, false));
            }

            return Request.CreateResponse(HttpStatusCode.OK, res, new HttpConfiguration());
        }

        [HttpPost]
        public HttpResponseMessage Create(UInt64 id, [FromBody] CreatePaymentPattern req)
        {
            TransactionReceipt result;
            try
            {
                result = TokenFunctionsResults<int, CreatePaymentPattern>.InvokeByTransaction(req, FunctionNames.CreatePayment, req.Gas, new object[] { id, req.Value });
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, false));
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}

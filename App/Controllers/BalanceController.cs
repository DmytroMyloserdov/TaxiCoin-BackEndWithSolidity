using App.RequestObjectPatterns;
using App.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    public class BalanceController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody] DefaultControllerPattern req)
        {
            Crypto.DecryptTwoStringsAndGetContractFunctions(out string senderAddress, req.Sender, out string password, req.Password, req.PassPhrase, out ContractFunctions contractFunctions);
            ulong res = 0;

            try
            {
                res = contractFunctions.CallFunctionByName<System.UInt64>(senderAddress, password, FunctionNames.Balance, senderAddress).Result;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, new HttpError(e, true));
            }
            return Request.CreateResponse(HttpStatusCode.OK, res.ToString());
        }
    }
}

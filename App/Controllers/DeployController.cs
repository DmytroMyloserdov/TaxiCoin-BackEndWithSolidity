using App.RequestObjectPatterns;
using App.Utils;
using System.Net.Http;
using System.Web.Http;
using TokenAPI;

namespace App.Controllers
{
    class DeployController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody] DeployControllerPattern req)
        {
            Crypto.DecryptTwoStringsAndGetContractFunctions(out string senderAddress, req.Sender, out string password, req.Password, req.PassPhrase, out ContractFunctions contractFunctions);
            contractFunctions.DeployContract(senderAddress, password, req.Gas, req.TotalSupply);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }
    }
}

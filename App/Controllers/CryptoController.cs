using App.RequestObjectPatterns;
using App.Utils;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;

namespace App.Controllers
{
    public class CryptoController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Encrypt([FromBody] DefaultControllerPattern req)
        {
            Crypto.EncryptTwoStrings(out string senderAddress, req.Sender, out string password, req.Password, req.PassPhrase);
            CryptoResponsePattern cryptoResponse = new CryptoResponsePattern
            {
                PassPhrase = req.PassPhrase,
                Password = password,
                Sender = senderAddress
            };

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, JsonConvert.SerializeObject(cryptoResponse));
        }

        [HttpPost]
        public HttpResponseMessage Decrypt([FromBody] DefaultControllerPattern req)
        {
            Crypto.DecryptTwoStrings(out string senderAddress, req.Sender, out string password, req.Password, req.PassPhrase);
            CryptoResponsePattern cryptoResponse = new CryptoResponsePattern
            {
                PassPhrase = req.PassPhrase,
                Password = password,
                Sender = senderAddress
            };

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, JsonConvert.SerializeObject(cryptoResponse));
        }
    }
}

using System.Web.Http;

namespace App.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return "OK!";
        }
    }
}

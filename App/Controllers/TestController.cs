using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

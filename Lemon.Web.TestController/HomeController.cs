using System;
using System.Web.Http;

namespace Lemon.Web.TestController
{
    [RoutePrefix("Api/TestHome")]
    public class HomeController:ApiController
    {
        [HttpGet]
        [Route("Index")]
        public string Index()
        {
            return "Test" + Guid.NewGuid().ToString("N");
        }
    }
}
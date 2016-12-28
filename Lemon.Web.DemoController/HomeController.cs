using System;
using System.Web.Http;

namespace Lemon.Web.DemoController
{
    [RoutePrefix("Api/DemoHome")]
    public class LemonController : ApiController
    {
        [HttpGet]
        [Route("Index")]
       
        public string Index()
        {
            return "Demo"+ Guid.NewGuid().ToString("N");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_DI.BAL;

namespace WebAPI_DI.Controllers
{
    public class TestController : ApiController
    {
        private Test_BAL _obj;
        public TestController(Test_BAL obj)
        {
            _obj = obj;
        }

        [Route("api/Test/Get")]
        public IEnumerable<string> Get()
        {
            int res = _obj.sum(5, 6);
            return new string[] { "value1", "value2" };
        }
    }
}

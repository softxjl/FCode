using FCode.Utility;
using FCode.VModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FCode.Api
{
    public class IndexController : ApiBaseController
    {
        [HttpGet]
        public ReturnResult GetHome()
        {
            var result = new ReturnResult();
            var token = this.GetToken();
            if (token != null) result.data = "访问成功！";
            return result;
        }
    }
}

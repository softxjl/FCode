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
        [HttpPost]
        public ReturnResult Index(UserReq req)
        {
            var result = new ReturnResult();
            if (token != null) result.msg = "访问成功！";
            return result;
        }
    }
}

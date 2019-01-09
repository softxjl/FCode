using FCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FCode.Api
{
    [ApiActionFilter]
    public class ApiBaseController : ApiController
    {
        public ApiBaseController()
        {
            token = this.RequestContext.RouteData.Values["auth"] as TokenInfo;
        }
        public static TokenInfo token { get; set; }

    }
}

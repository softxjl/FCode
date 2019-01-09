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
    public class LoginController : ApiController
    {
        [HttpPost]
        public ReturnResult Login(UserReq req)
        {
            var result = new ReturnResult();
            if (req.userName == "jace" && req.password == "123")
            {
                var token = TokenHelper.JWTEncode(new TokenInfo { UserId = 1001, UserName = "jace" });
                result.data = token;
            }
            else
            {
                result.code = (int)ReturnResultEnum.self_error;
                result.msg = "登录失败！";
            }
            return result;
        }
    }
}

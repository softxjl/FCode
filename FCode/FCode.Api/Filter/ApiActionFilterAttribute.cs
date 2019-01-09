using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Text;
using FCode.VModel;
using FCode.Utility;

namespace FCode.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ApiActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Action执行前调用
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                var authInfo = this.AuthorizeCore(actionContext);
                if (authInfo.code != (int)ReturnResultEnum.success)
                {
                    //ReturnResult result = new ReturnResult { code = authInfo.code, msg = authInfo.msg, data = authInfo.data };
                    string content = JsonHelper.Seriallize(authInfo);
                    actionContext.Response = new HttpResponseMessage { Content = new StringContent(content, Encoding.GetEncoding("UTF-8"), "application/json") };
                    return;
                }
                base.OnActionExecuting(actionContext);
            }
            catch (Exception ex)
            {
                LogHelper.Exception(ex);
                ReturnResult result = new ReturnResult { code = (int)ReturnResultEnum.system_exception, msg = "权限认证发生异常,请联系管理员！" };
                string content = JsonHelper.Seriallize(result);
                actionContext.Response = new HttpResponseMessage { Content = new StringContent(content, Encoding.GetEncoding("UTF-8"), "application/json") };
                return;
            }
        }


        /// <summary>
        /// 授权中心
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected virtual ReturnResult AuthorizeCore(HttpActionContext actionContext)
        {
            ReturnResult result = new ReturnResult { code = (int)ReturnResultEnum.token_error, msg = "登录信息无效，请重新登录！" };
            try
            {
                TokenInfo token = this.GetTokenFromHeader(actionContext);
                if (this.TokenValidate(token))
                {
                    result.code = (int)ReturnResultEnum.success;
                    result.msg = string.Empty;
                    actionContext.RequestContext.RouteData.Values.Add("auth", token);
                }
                else
                {
                    result.code = (int)ReturnResultEnum.invalid_identity;
                    result.msg = "无效身份,请重新登录";
                }
            }
            catch (Exception ex)
            {
                result.code = (int)ReturnResultEnum.system_exception;
                result.msg = "系统发生异常,请稍候重试";
                LogHelper.Error($"ApiAuthorizeAttribute/IsAuthorized Error:{ex.Message}--{ex.InnerException?.Message} from：{actionContext.Request.RequestUri}");
            }
            return result;
        }

        /// <summary>
        /// token验证
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool TokenValidate(TokenInfo token)
        {
            if (token != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 从请求头获取token
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        public TokenInfo GetTokenFromHeader(HttpActionContext actionContext)
        {
            TokenInfo token = null;
            var authHeader = from h in actionContext.Request.Headers where h.Key == "auth" select h.Value.FirstOrDefault();
            if (authHeader != null)
            {
                string tokenStr = authHeader.FirstOrDefault();
                if (!string.IsNullOrEmpty(tokenStr))
                {
                    try
                    {
                        token = TokenHelper.JWTDecode(tokenStr);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error($"GetTokenFromHeader Error:{ex.Message}--{ex.InnerException?.Message} from：{actionContext.Request.RequestUri}");
                    }
                }
            }
            return token;
        }
    }
}
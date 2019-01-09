using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FCode.Utility
{
    /// <summary>
    /// Jace
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TokenHelper
    {

        private static string SecretKey = "This is a private key for Server";//这个服务端加密秘钥 属于私钥
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="key"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static string JWTEncode(TokenInfo token)
        {
            string result = string.Empty;
            try
            {
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder jwtEncoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                result = jwtEncoder.Encode(token, SecretKey);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"JWTHelper/JWTEncode ERROR:{ex.Message}");
            }
            return result;
        }
        /// <summary>
        /// 解析token
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static TokenInfo JWTDecode(string token)
        {
            try
            {
                IJsonSerializer jsonSerializer = new JsonNetSerializer();
                IDateTimeProvider dateTimeProvider = new UtcDateTimeProvider();
                IJwtValidator jwtValidator = new JwtValidator(jsonSerializer, dateTimeProvider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder jwtDecoder = new JwtDecoder(jsonSerializer, jwtValidator, urlEncoder);

                var obj = jwtDecoder.DecodeToObject<TokenInfo>(token, SecretKey, true);

                return obj;
            }
            catch (Exception ex)
            {
                LogHelper.Error($"JWTHelper/JWTDecode ERROR:{ex.Message}");
            }
            return null;
        }
    }

    public class TokenInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
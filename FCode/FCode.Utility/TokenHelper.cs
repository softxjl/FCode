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
    public class JWTHelper<T> where T : class
    {

        public static string SecretKey = "This is a private key for Server";//这个服务端加密秘钥 属于私钥
        /// <summary>
        /// kian
        /// </summary>
        /// <param name="key"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static string JWTEncode(object payload)
        {
            string result = string.Empty;
            try
            {
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder jwtEncoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                result = jwtEncoder.Encode(payload, SecretKey);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"JWTHelper/JWTEncode ERROR:{ex.Message}");
            }
            return result;
        }
        /// <summary>
        /// Jace
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static T JWTDecode(string token)
        {
            try
            {
                IJsonSerializer jsonSerializer = new JsonNetSerializer();
                IDateTimeProvider dateTimeProvider = new UtcDateTimeProvider();
                IJwtValidator jwtValidator = new JwtValidator(jsonSerializer, dateTimeProvider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder jwtDecoder = new JwtDecoder(jsonSerializer, jwtValidator, urlEncoder);

                var obj = jwtDecoder.DecodeToObject<T>(token, SecretKey, true);

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
        public TokenInfo()
        {
            iss = "签发者信息";
            aud = "http://example.com";
            sub = "HomeCare.VIP";
            jti = DateTime.Now.ToString("yyyyMMddhhmmss");
            UserName = "jack.chen";
            UserPwd = "jack123456";
            UserRole = "HomeCare.Administrator";
        }
        //
        public string iss { get; set; }
        public string aud { get; set; }
        public string sub { get; set; }
        public string jti { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserRole { get; set; }
    }
}
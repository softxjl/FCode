using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCode.Utility
{
    public class JsonHelper
    {

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Dseriallize<T>(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            return default(T);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string Seriallize(object o)
        {
            if (o != null)
            {
                return JsonConvert.SerializeObject(o);
            }
            return string.Empty;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DseriallizeWithTimeFormat<T>(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
                timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

                return JsonConvert.DeserializeObject<T>(json, timeFormat);
            }
            return default(T);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string SeriallizeWithTimeFormat(object o)
        {
            if (o != null)
            {
                IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
                timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

                return JsonConvert.SerializeObject(o, timeFormat);
            }
            return string.Empty;
        }


    }


}

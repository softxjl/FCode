using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCode.VModel
{
    public class ReturnResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ReturnResult()
        {
            this.code = (int)ReturnResultEnum.success;
            this.msg = ReturnResultEnum.success.ToString();
            this.data = "";
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_code">返回码</param>
        /// <param name="_msg">返回信息</param>
        public ReturnResult(ReturnResultEnum _code, string _msg)
        {
            this.code = (int)_code;
            this.msg = _msg;
            this.data = "";
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_code">返回码</param>
        /// <param name="_msg">返回信息</param>
        public ReturnResult(int _code, string _msg)
        {
            this.code = _code;
            this.msg = _msg;
            this.data = "";
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_code">返回码</param>
        /// <param name="_msg">返回信息</param>
        /// <param name="_data">返回数据</param>
        public ReturnResult(ReturnResultEnum _code, string _msg, object _data)
        {
            this.code = (int)_code;
            this.msg = _msg;
            this.data = _data;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_code">返回码</param>
        /// <param name="_msg">返回信息</param>
        /// <param name="_data">返回数据</param>
        public ReturnResult(int _code, string _msg, object _data)
        {
            this.code = _code;
            this.msg = _msg;
            this.data = _data;
        }
        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }
    }


    /// <summary>
    /// API请求结果
    /// </summary>
    public class ReturnResult<T>
    {
        public ReturnResult()
        {
            this.code = (int)ReturnResultEnum.success;
            this.msg = ReturnResultEnum.success.ToString();
            this.data = default(T);
        }

        public ReturnResult(int code, string msg)
        {
            this.code = code;
            this.msg = msg;
            this.data = default(T);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="code">返回码</param>
        /// <param name="msg">返回信息</param>
        /// <param name="data">返回数据</param>
        public ReturnResult(ReturnResultEnum code, string msg, T data)
        {
            this.code = (int)code;
            this.msg = msg;
            this.data = data;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="code">返回码</param>
        /// <param name="msg">返回信息</param>
        /// <param name="data">返回数据</param>
        public ReturnResult(int code, string msg, T data)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        #region property
        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public T data { get; set; }
        #endregion
    }

    /// <summary>
    /// jace
    /// </summary>
    public enum ReturnResultEnum
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        success = 0,
        /// <summary>
        /// 权限不足
        /// </summary>
        permission_error = 401,
        /// <summary>
        /// 参数有误
        /// </summary>
        para_error = 500001,
        /// <summary>
        /// 系统异常
        /// </summary>
        system_exception = 500002,
        /// <summary>
        /// 自定义错误
        /// </summary>
        self_error = 500003,
        /// <summary>
        /// appid有误
        /// </summary>
        appid_error = 500004,
        /// <summary>
        /// token有误
        /// </summary>
        token_error = 500005,
        /// <summary>
        /// 过期请求
        /// </summary>
        expired_error = 500006,
        /// <summary>
        /// 签名有误
        /// </summary>
        signature_error = 500007,
        /// <summary>
        /// token过期
        /// </summary>
        expired_token = 500008,
        /// <summary>
        /// 无效身份
        /// </summary>
        invalid_identity = 500009,
        /// <summary>
        /// 多合同信息
        /// </summary>
        multi_prducts = 500010
    }
}

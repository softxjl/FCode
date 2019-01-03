using System;

namespace FCode.Utility
{
    /// <summary>
    /// 类，事件日志类。
    /// 单态封装log4net
    /// </summary>
    public class LogHelper
    {
        static LogHelper()
        {
            if (_log == null)
            {
                _log = log4net.LogManager.GetLogger("DisLogFile");
                log4net.Config.XmlConfigurator.Configure();
            }
        }

        private static log4net.ILog _log = null;
        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        public static bool IsDebugEnabled
        {
            get
            {
                return _log.IsDebugEnabled;
            }
        }

        public static log4net.ILog Log
        {
            get
            {
                return _log;
            }
        }

        /// <summary>
        /// 记录调试日志
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            if (Log.IsDebugEnabled)
            {
                Log.Debug(message);
            }
        }

        /// <summary>
        /// 记录消息日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            if (Log.IsInfoEnabled)
            {
                Log.Info(message);
            }
        }

        /// <summary>
        /// 记录消息日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(object message)
        {
            if (Log.IsInfoEnabled)
            {
                Log.Info(message);
            }
        }

        /// <summary>
        /// 记录警告日志
        /// </summary>
        /// <param name="message"></param>
        public static void Warning(string message)
        {
            if (Log.IsWarnEnabled)
            {
                Log.Warn(message);
            }
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            if (Log.IsErrorEnabled)
            {
                Log.Error(message);
            }
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message, Exception ex)
        {
            if (Log.IsErrorEnabled)
            {
                Log.Error(string.Format("错误方法:{0}，错误信息:{1}，详细信息:{2}", message, ex.Message, ex.StackTrace));
            }
        }

        /// <summary>
        /// 记录指定的一个Exception的日志
        /// </summary>
        /// <param name="exception"></param>
        public static void Exception(Exception exception)
        {
            if (Log.IsErrorEnabled)
            {
                Log.Fatal(exception.Message, exception);
            }
        }

        /// <summary>
        /// 记录指定的一个Exception的日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常</param>
        public static void Exception(string message, Exception exception)
        {
            if (Log.IsErrorEnabled)
            {
                Log.Fatal(message, exception);
            }
        }

        //日志异步处理
        private delegate void delegateHandler(string info);
        public static string InfoAsync(string info)
        {
            if (Log.IsInfoEnabled)
            {
                delegateHandler LogDelegate = new delegateHandler(Log.Info);
                IAsyncResult Opt_result = LogDelegate.BeginInvoke(info, null, null);
            }
            return "";
        }
        public static string ErrorAsync(string info)
        {
            if (Log.IsErrorEnabled)
            {
                delegateHandler LogDelegate = new delegateHandler(Log.Error);
                IAsyncResult Opt_result = LogDelegate.BeginInvoke(info, null, null);
            }
            return "";
        }
        public static string WarnAsync(string info)
        {
            if (Log.IsWarnEnabled)
            {
                delegateHandler LogDelegate = new delegateHandler(Log.Warn);
                IAsyncResult Opt_result = LogDelegate.BeginInvoke(info, null, null);
            }
            return "";
        }
        public static string DebugAsync(string info)
        {
            if (Log.IsDebugEnabled)
            {
                delegateHandler LogDelegate = new delegateHandler(Log.Debug);
                IAsyncResult Opt_result = LogDelegate.BeginInvoke(info, null, null);
            }
            return "";
        }
    }
}

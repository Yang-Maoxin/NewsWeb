using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApi.Common
{
        /// <summary>
        /// 请求结果结构
        /// </summary>
        public struct HttpActionResult
        {

            private int _code;
            /// <summary>
            /// 操作代码（200为成功）返回的状态码可以参照http请求返回码定义(2**服务器成功接收请求状态3**重定向4**客户端状态5**服务器端异常)
            /// </summary>
            public int code
            {
                get { return _code; }
                set { value = _code; }
            }

            private string _message;

            /// <summary>
            /// 提示信息
            /// </summary>
            public string message
            {
                get { return _message; }
                set { value = _message; }
            }

            private object _data;
            /// <summary>
            /// 结果数据
            /// </summary>
            public object data
            {
                get { return _data; }
                set { value = _data; }
            }
            /// <summary>
            /// 失败的操作
            /// </summary>
            /// <param name="code">错误代码</param>
            /// <param name="message">错误消息</param>
            /// <param name="data">结果数据</param>
            /// <returns></returns>
            public static HttpActionResult Failure(int code, string message = "失败", object data = null)
            {
                return new HttpActionResult { _code = code, _message = message, _data = data };
            }

            /// <summary>
            /// 成功的结果
            /// </summary>
            /// <param name="message">成功消息</param>
            /// <returns></returns>
            public static HttpActionResult Successful(string message = "成功", object data = null)
            {
                return new HttpActionResult { _code = 200, _message = message, _data = data };
            }
        }



        /// <summary>
        /// 泛型结果结构
        /// </summary>
        public struct HttpActionResult<T>
        {

            private int _code;
            /// <summary>
            /// 操作代码（200为成功）
            /// </summary>
            public int code
            {
                get { return _code; }
                set { value = _code; }
            }

            private string _message;

            /// <summary>
            /// 提示信息
            /// </summary>
            public string message
            {
                get { return _message; }
                set { value = _message; }
            }

            private T _data;
            /// <summary>
            /// 结果数据
            /// </summary>
            public T data
            {
                get { return _data; }
                set { value = _data; }
            }

            /// <summary>
            /// 失败的操作
            /// </summary>
            /// <param name="code"></param>
            /// <param name="message"></param>
            /// <returns></returns>
            public static HttpActionResult<T> Failure(T t, int code = 500, string message = "失败")
            {
                return new HttpActionResult<T> { _data = t, _code = code, _message = message };
            }

            /// <summary>
            /// 成功的结果
            /// </summary>
            /// <param name="message"></param>
            /// <returns></returns>
            public static HttpActionResult<T> Successful(T t, string message = "成功")
            {
                return new HttpActionResult<T> { _data = t, _code = 200, _message = message };
            }
        }
    }


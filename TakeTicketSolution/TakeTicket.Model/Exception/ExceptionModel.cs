using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeTicket.Model
{
    public class ExceptionModel
    {
        private string _ClientIP;
        /// <summary>
        /// 用户访问IP
        /// </summary>
        public string ClientIP
        {
            get { return this._ClientIP; }
            set { this._ClientIP = value; }
        }
        private string _ServerIP;
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerIP
        {
            get { return this._ServerIP; }
            set { this._ServerIP = value; }
        }
        private string _ThrowTime;
        /// <summary>
        /// 异常类型
        /// </summary>
        public string ThrowTime
        {
            get { return this._ThrowTime; }
            set { this._ThrowTime = value; }
        }
        private string _RequestUrl;
        /// <summary>
        /// 当前请求的URL字符串
        /// </summary>
        public string RequestUrl
        {
            get { return this._RequestUrl; }
            set { this._RequestUrl = value; }
        }
        private string _UrlReferrer = "";
        /// <summary>
        /// 当前url的上一个url地址字符串
        /// </summary>
        public string UrlReferrer
        {
            get { return this._UrlReferrer; }
            set { this._UrlReferrer = value; }
        }
        private string _ExMessage;
        /// <summary>
        /// 异常消息
        /// </summary>
        public string ExMessage
        {
            get { return this._ExMessage; }
            set { this._ExMessage = value; }
        }
        private string _ExDetail;
        /// <summary>
        /// 异常详细信息
        /// </summary>
        public string ExDetail
        {
            get { return this._ExDetail; }
            set { this._ExDetail = value; }
        }
        private string _SiteName;
        /// <summary>
        /// 异常信息所属站点
        /// </summary>
        public string SiteName
        {
            get { return this._SiteName; }
            set { this._SiteName = value; }
        }
    }
}



namespace OBS.Model
{
    /// <summary>
    /// 下载对象时可重写的响应消息头信息。 
    /// </summary>
    public class ResponseHeaderOverrides
    {

        /// <summary>
        /// 重写响应中的Content-Type头。
        /// </summary>

        public string ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// 重写响应中的Content-Language头。
        /// </summary>
        public string ContentLanguage
        {
            get;
            set;
        }

        /// <summary>
        /// 重写响应中的Expires头。
        /// </summary>
        public string Expires
        {
            get;
            set;
        }

        /// <summary>
        /// 重写响应中的Cache-Control头。
        /// </summary>
        public string CacheControl
        {
            get;
            set;
        }

        /// <summary>
        /// 重写响应中的Content-Disposition头。
        /// </summary>
        public string ContentDisposition
        {
            get;
            set;
        }

        /// <summary>
        /// 重写响应中的Content-Encoding头。
        /// </summary>
        public string ContentEncoding
        {
            get;
            set;
        }
    }
}


using System.Net;
using OBS.Internal;

namespace OBS
{
    /// <summary>
    /// 客户端配置参数。
    /// </summary>
    public partial class ObsConfig
    {

        private AuthTypeEnum authType = Constants.DefaultAuthType;
        private int maxErrorRetry = Constants.DefaultMaxErrorRetry;
        private int connectTimeout = Constants.DefaultConnectTimeout;
        private int bufferSize = Constants.DefaultBufferSize;
        private int connectionLimit = Constants.DefaultConnectionLimit;
        private int maxIdleTime = Constants.DefaultMaxIdleTime;
        private int readWriteTimeout = Constants.DefaultReadWriteTimeout;
        private int receiveBufferSize = Constants.DefaultBufferSize;
        private int asyncSocketTimeout = Constants.DefaultAsyncSocketTimeout;
        private bool keepAlive = Constants.DefaultKeepAlive;
        private bool authTypeNegotiation = Constants.DefaultAuthTypeNegotiation;

        /// <summary>
        /// 是否验证证书。
        /// </summary>
        public bool ValidateCertificate
        {
            get;
            set;
        }

        /// <summary>
        /// 是否进行鉴权方式协商，默认值：true。
        /// </summary>
        public bool AuthTypeNegotiation
        {
            get
            {
                return this.authTypeNegotiation;
            }
            set
            {
                this.authTypeNegotiation = value;
            }
        }

        /// <summary>
        /// 连接OBS使用的鉴权方式，当开启协议协商时，该值被忽略。
        /// </summary>
        public AuthTypeEnum AuthType
        {
            get { return this.authType; }
            set { this.authType = value; }
        }

        /// <summary>
        /// 请求失败后最大的重试次数，默认值为3。
        /// </summary>
        public int MaxErrorRetry
        {
            get { return this.maxErrorRetry; }
            set { this.maxErrorRetry = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// 套接字接收缓冲区的大小。
        /// </summary>
        public int ReceiveBufferSize
        {
            get { return this.receiveBufferSize; }
            set { this.receiveBufferSize = value <= 0 ? Constants.DefaultBufferSize : value; }
        }

        /// <summary>
        /// 上传对象时的读写缓存大小。
        /// </summary>
        public int BufferSize
        {
            get { return this.bufferSize; }
            set { this.bufferSize = value <= 0 ? Constants.DefaultBufferSize : value; }
        }

        /// <summary>
        /// HTTPS协议类型。
        /// </summary>
        public SecurityProtocolType? SecurityProtocolType
        {
            get;
            set;
        }


        /// <summary>
        /// 请求超时前等待的时间，单位：毫秒。
        /// </summary>
        public int Timeout
        {
            get { return this.connectTimeout; }
            set
            {
                this.connectTimeout = value <= 0 ? Constants.DefaultConnectTimeout : value;
            }
        }

        /// <summary>
        /// 异步请求的超时时间，单位：毫秒。
        /// </summary>
        public int AsyncSocketTimeout
        {
            get { return this.asyncSocketTimeout; }
            set
            {
                this.asyncSocketTimeout = value <= 0 ? Constants.DefaultAsyncSocketTimeout : value;
            }
        }

        /// <summary>
        /// 是否使用长连接，默认值：true。
        /// </summary>
        public bool KeepAlive
        {
            get
            {
                return this.keepAlive;
            }
            set
            {
                this.keepAlive = value;
            }
        }


        /// <summary>
        /// 代理地址。
        /// </summary>
        public string ProxyHost
        {
            get;
            set;
        }


        /// <summary>
        /// 代理端口。
        /// </summary>
        public int ProxyPort
        {
            get;
            set;
        }

        /// <summary>
        /// 连接代理服务器时使用的用户名。
        /// </summary>
        public string ProxyUserName
        {
            get;
            set;
        }

        /// <summary>
        /// 连接代理服务器时使用的密码。
        /// </summary>
        public string ProxyPassword
        {
            get;
            set;
        }

        /// <summary>
        /// 代理服务器的域。
        /// </summary>
        public string ProxyDomain
        {
            get;
            set;
        }

        /// <summary>
        /// 连接池中连接的最大空闲时间，单位：毫秒。
        /// 默认值为30000毫秒。
        /// </summary>
        public int MaxIdleTime
        {
            get { return this.maxIdleTime; }
            set
            {
                if (value <= 0)
                {
                    this.maxIdleTime = Constants.DefaultMaxIdleTime;
                }
                else
                {

                    this.maxIdleTime = value;
                }
            }
        }

        /// <summary>
        /// 允许打开的最大HTTP连接数。
        /// 默认值为1000。
        /// </summary>
        public int ConnectionLimit
        {
            get { return this.connectionLimit; }
            set
            {
                this.connectionLimit = value <= 0 ? Constants.DefaultConnectionLimit : value;
            }
        }


        /// <summary>
        /// 读写数据超时时间，单位：毫秒。
        /// 默认值为60000毫秒。
        /// </summary>
        public int ReadWriteTimeout
        {
            get { return this.readWriteTimeout; }
            set
            {
                this.readWriteTimeout = value <= 0 ? Constants.DefaultReadWriteTimeout : value;
            }
        }

    }
}

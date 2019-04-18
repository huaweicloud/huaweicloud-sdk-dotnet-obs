
using OBS.Internal;
using OBS.Internal.Log;
using OBS.Internal.Negotiation;
using OBS.Model;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace OBS
{
    /// <summary>
    /// 访问OBS的客户端。
    /// </summary>
    public partial class ObsClient
    {


        private HttpClient httpClient;
        private LocksHolder locksHolder;
        private AuthTypeCache authTypeCache;
        private volatile SecurityProvider sp;

        internal delegate void DoValidateDelegate();


        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="accessKeyId">访问密钥中的AK</param>
        /// <param name="secretAccessKey">访问密钥中的SK</param>
        /// <param name="obsConfig">OBS客户端配置参数</param>
        public ObsClient(string accessKeyId, string secretAccessKey, ObsConfig obsConfig) : this(accessKeyId, secretAccessKey, "", obsConfig)
        {

        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="accessKeyId">访问密钥中的AK</param>
        /// <param name="secretAccessKey">访问密钥中的SK</param>
        /// <param name="securityToken">安全令牌</param>
        /// <param name="obsConfig">OBS客户端配置参数</param>
        public ObsClient(string accessKeyId, string secretAccessKey, string securityToken, ObsConfig obsConfig)
        {
            this.init(accessKeyId, secretAccessKey, securityToken, obsConfig);
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="accessKeyId">访问密钥中的AK</param>
        /// <param name="secretAccessKey">访问密钥中的SK</param>
        /// <param name="endpoint">OBS的服务地址</param>
        public ObsClient(string accessKeyId, string secretAccessKey, string endpoint) : this(accessKeyId, secretAccessKey, "", endpoint)
        {

        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="accessKeyId">访问密钥中的AK</param>
        /// <param name="secretAccessKey">访问密钥中的SK</param>
        /// <param name="securityToken">安全令牌</param>
        /// <param name="endpoint">OBS的服务地址</param>
        public ObsClient(string accessKeyId, string secretAccessKey, string securityToken, string endpoint)
        {
            ObsConfig obsConfig = new ObsConfig()
            {
                Endpoint = endpoint
            };
            this.init(accessKeyId, secretAccessKey, securityToken, obsConfig);
        }

        internal ObsConfig ObsConfig
        {
            get;
            set;
        }

        internal IParser GetIParser(HttpContext context)
        {
            switch (context.ChooseAuthType)
            {
                case AuthTypeEnum.V2:
                case AuthTypeEnum.V4:
                    return V2Parser.GetInstance(this.httpClient.GetIHeaders(context));
                default:
                    return ObsParser.GetInstance(this.httpClient.GetIHeaders(context));
            }
        }

        internal IConvertor GetIConvertor(HttpContext context)
        {
            switch (context.ChooseAuthType)
            {
                case AuthTypeEnum.V2:
                case AuthTypeEnum.V4:
                    return V2Convertor.GetInstance(this.httpClient.GetIHeaders(context));
                default:
                    return ObsConvertor.GetInstance(this.httpClient.GetIHeaders(context));
            }
        }


        internal void init(string accessKeyId, string secretAccessKey, string securityToken, ObsConfig obsConfig)
        {
            if (obsConfig == null || string.IsNullOrEmpty(obsConfig.Endpoint))
            {
                throw new ObsException(Constants.InvalidEndpointMessage, ErrorType.Sender, Constants.InvalidEndpoint, "");
            }

            SecurityProvider sp = new SecurityProvider();
            sp.Ak = accessKeyId;
            sp.Sk = secretAccessKey;
            sp.Token = securityToken;

            this.sp = sp;
            this.ObsConfig = obsConfig;
            this.httpClient = new HttpClient(this.ObsConfig);

            if (this.ObsConfig.PathStyle)
            {
                this.ObsConfig.AuthTypeNegotiation = false;
                if(this.ObsConfig.AuthType == AuthTypeEnum.OBS)
                {
                    this.ObsConfig.AuthType = AuthTypeEnum.V2;
                }
            }

            if (this.ObsConfig.AuthTypeNegotiation)
            {
                this.locksHolder = new LocksHolder();
                authTypeCache = new AuthTypeCache();
            }

            LoggerMgr.Initialize();

            if (LoggerMgr.IsWarnEnabled)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("[OBS SDK Version=")
                    .Append(Constants.ObsSdkVersion)
                    .Append("];[")
                    .Append("Endpoint=")
                    .Append(obsConfig.Endpoint)
                     .Append("];[")
                     .Append("Access Mode=")
                     .Append(obsConfig.PathStyle ? "Path" : "Virtual Hosting")
                     .Append("]");
                LoggerMgr.Warn(sb.ToString());
            }
        }

        /// <summary>
        /// 刷新临时访问密钥接口。
        /// </summary>
        /// <param name="accessKeyId">访问密钥中的AK</param>
        /// <param name="secretAccessKey">访问密钥中的SK</param>
        /// <param name="securityToken">安全令牌</param>
        public void Refresh(string accessKeyId, string secretAccessKey, string securityToken)
        {
            SecurityProvider sp = new SecurityProvider();
            sp.Ak = accessKeyId;
            sp.Sk = secretAccessKey;
            sp.Token = securityToken;
            this.sp = sp;
        }

        internal GetApiVersionResponse GetApiVersion(GetApiVersionRequest request)
        {
            return this.DoRequest<GetApiVersionRequest, GetApiVersionResponse>(request);
        }

        internal AuthTypeEnum? NegotiateAuthType(string bucketName, bool async)
        {
            AuthTypeEnum? authType = AuthTypeEnum.V2;
            GetApiVersionRequest request = new GetApiVersionRequest();
            request.BucketName = bucketName;
            try
            {

                GetApiVersionResponse response = async ?  this.GetApiVersionAsync(request) : this.GetApiVersion(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    if ((response.Headers.ContainsKey(Constants.ObsApiHeader)
                    && response.Headers[Constants.ObsApiHeader].CompareTo("3.0") >= 0) || (response.Headers.ContainsKey(Constants.ObsApiHeaderWithPrefix)
                    && response.Headers[Constants.ObsApiHeaderWithPrefix].CompareTo("3.0") >= 0))
                    {
                        authType = AuthTypeEnum.OBS;
                    }
                }
            }
            catch (ObsException ex)
            {
                int statusCode = Convert.ToInt32(ex.StatusCode);
                if (statusCode <= 0 || statusCode == 404 || statusCode >= 500)
                {
                    throw ex;
                }

                if (LoggerMgr.IsInfoEnabled)
                {
                    string msg = string.IsNullOrEmpty(bucketName) ? "The target server doesnot support OBS protocol, use S3 protocol" : string.Format("The target server doesnot support OBS protocol, use S3 protocol, Bucket:{0}", bucketName);
                    LoggerMgr.Info(msg, ex);
                }
            }

            return authType;
        }

        private HttpContext BeforeRequest<T>(T request, DoValidateDelegate doValidateDelegate, bool async) where T : ObsWebServiceRequest
        {
            if (request == null)
            {
                throw new ObsException(Constants.NullRequestMessage, ErrorType.Sender, Constants.NullRequest, "");
            }

            HttpContext context = new HttpContext(this.sp, this.ObsConfig);

            if (request is GetApiVersionRequest)
            {
                context.SkipAuth = true;
            }
            else
            {
                ObsBucketWebServiceRequest _request = request as ObsBucketWebServiceRequest;
                if (_request != null && string.IsNullOrEmpty(_request.BucketName))
                {
                    throw new ObsException(Constants.InvalidBucketNameMessage, ErrorType.Sender, Constants.InvalidBucketName, "");
                }
                if (this.ObsConfig.AuthTypeNegotiation)
                {
                    AuthTypeEnum? authType;
                    if (_request == null)
                    {
                        //list buckets
                        authType = this.NegotiateAuthType(null, async);
                    }
                    else
                    {
                        if ((authType = this.authTypeCache.GetAuthType(_request.BucketName)) == null)
                        {
                            lock (this.locksHolder.GetLock(_request.BucketName))
                            {
                                if ((authType = this.authTypeCache.GetAuthType(_request.BucketName)) == null)
                                {
                                    if (request is CreateBucketRequest)
                                    {
                                        authType = this.NegotiateAuthType(null, async);
                                    }
                                    else
                                    {
                                        authType = this.NegotiateAuthType(_request.BucketName, async);
                                        this.authTypeCache.RefreshAuthType(_request.BucketName, authType.Value);
                                        if (LoggerMgr.IsInfoEnabled)
                                        {
                                            LoggerMgr.Info(string.Format("Refresh auth type {0} for bucket {1}", authType, _request.BucketName));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (LoggerMgr.IsDebugEnabled)
                    {
                        LoggerMgr.Debug(string.Format("Get auth type {0}", authType));
                    }
                    context.AuthType = authType;
                }
            }

            request.Sender = this;
            doValidateDelegate?.Invoke();

            if (LoggerMgr.IsInfoEnabled)
            {
                LoggerMgr.Info(request.GetAction() + " begin.");
            }
            return context;
        }

        private HttpRequest PrepareHttpRequest<T>(T request, HttpContext context) where T : ObsWebServiceRequest
        {
            IConvertor iconvertor = this.GetIConvertor(context);
            MethodInfo info = CommonUtil.GetTransMethodInfo(request.GetType(), iconvertor);
            HttpRequest httpRequest = info.Invoke(iconvertor, new object[] { request }) as HttpRequest;
            if (httpRequest == null)
            {
                throw new ObsException(string.Format("Cannot trans request:{0} to HttpRequest", request.GetType()), ErrorType.Sender, "Trans error", "");
            }
            httpRequest.Endpoint = this.ObsConfig.Endpoint;
            httpRequest.PathStyle = this.ObsConfig.PathStyle;
            return httpRequest;
        }

        private K PrepareResponse<T, K>(T request, HttpContext context, HttpRequest httpRequest, HttpResponse httpResponse)
            where T : ObsWebServiceRequest
            where K : ObsWebServiceResponse
        {
            K response;
            httpResponse.RequestUrl = httpRequest.GetUrlWithoutQuerys();
            IParser iparser = this.GetIParser(context);
            Type responseType = typeof(K);
            MethodInfo info = CommonUtil.GetParseMethodInfo(responseType, iparser);
            if (info != null)
            {
                response = info.Invoke(iparser, new object[] { httpResponse }) as K;
            }
            else
            {
                ConstructorInfo cinfo = responseType.GetConstructor(new Type[] { });
                response = cinfo.Invoke(null) as K;
            }
            if (response == null)
            {
                throw new ObsException(string.Format("Cannot parse HttpResponse to {0}", responseType), ErrorType.Sender, "Parse error", "");
            }
            CommonParser.ParseObsWebServiceResponse(httpResponse, response, this.httpClient.GetIHeaders(context));
            response.HandleObsWebServiceRequest(request);
            return response;
        }

        internal K DoRequest<T, K>(T request, DoValidateDelegate doValidateDelegate)
            where T : ObsWebServiceRequest
            where K : ObsWebServiceResponse
        {

            HttpContext context = this.BeforeRequest(request, doValidateDelegate, false);
            DateTime reqTime = DateTime.Now;
            HttpRequest httpRequest = null;
            try
            {
                httpRequest = this.PrepareHttpRequest(request, context);
                HttpResponse httpResponse = this.httpClient.PerformRequest(httpRequest, context);
                return PrepareResponse<T, K>(request, context, httpRequest, httpResponse);
            }
            catch (ObsException ex)
            {
                if ("CreateBucket".Equals(request.GetAction()) 
                    && ex.StatusCode == HttpStatusCode.BadRequest
                    && "Unsupported Authorization Type".Equals(ex.ErrorMessage)
                    && this.ObsConfig.AuthTypeNegotiation 
                    && context.AuthType == AuthTypeEnum.OBS) 
                {
                    try
                    {
                        if (httpRequest.Content != null && httpRequest.Content.CanSeek)
                        {
                            httpRequest.Content.Seek(0, SeekOrigin.Begin);
                        }
                        context.AuthType = AuthTypeEnum.V2;
                        return PrepareResponse<T, K>(request, context, httpRequest, this.httpClient.PerformRequest(httpRequest, context));
                    }catch(ObsException _ex)
                    {
                        if (LoggerMgr.IsErrorEnabled)
                        {
                            LoggerMgr.Error(string.Format("{0} exception code: {1}, with message: {2}", request.GetAction(), _ex.ErrorCode, _ex.Message));

                        }
                        throw _ex;
                    }
                    catch(Exception _ex)
                    {
                        if (LoggerMgr.IsErrorEnabled)
                        {
                            LoggerMgr.Error(string.Format("{0} exception with message: {1}", request.GetAction(), _ex.Message));
                        }
                        throw new ObsException(_ex.Message, _ex);
                    }
                }

                if (LoggerMgr.IsErrorEnabled)
                {
                    LoggerMgr.Error(string.Format("{0} exception code: {1}, with message: {2}", request.GetAction(), ex.ErrorCode, ex.Message));

                }
                throw ex;
            }
            catch (Exception ex)
            {
                if (LoggerMgr.IsErrorEnabled)
                {
                    LoggerMgr.Error(string.Format("{0} exception with message: {1}", request.GetAction(), ex.Message));
                }
                throw new ObsException(ex.Message, ex);
            }
            finally
            {
                if (request != null)
                {
                    request.Sender = null;
                }

                CommonUtil.CloseIDisposable(httpRequest);

                if (LoggerMgr.IsInfoEnabled)
                {

                    LoggerMgr.Info(string.Format("{0} end, cost {1} ms", request.GetAction(), (DateTime.Now - reqTime).TotalMilliseconds));
                }
            }
        }

        internal K DoRequest<T, K>(T request)
            where T : ObsWebServiceRequest
            where K : ObsWebServiceResponse
        {
            return this.DoRequest<T, K>(request, null);
        }




    }
}

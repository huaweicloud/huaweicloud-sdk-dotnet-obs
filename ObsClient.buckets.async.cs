using System;
using System.Net;
using OBS.Model;


namespace OBS
{
    public partial class ObsClient
    {

        /// <summary>
        /// 开始对获取桶列表的异步请求。
        /// </summary>
        /// <param name="request">获取桶列表的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginListBuckets(ListBucketsRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<ListBucketsRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶列表的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶列表的响应结果。</returns>
        public ListBucketsResponse EndListBuckets(IAsyncResult ar)
        {
            return this.EndDoRequest<ListBucketsRequest, ListBucketsResponse>(ar);
        }

        /// <summary>
        /// 开始对创建桶的异步请求。
        /// </summary>
        /// <param name="request">创建桶请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginCreateBucket(CreateBucketRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<CreateBucketRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对创建桶的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>创建桶响应结果。</returns>
        public CreateBucketResponse EndCreateBucket(IAsyncResult ar)
        {
            return this.EndDoRequest<CreateBucketRequest, CreateBucketResponse>(ar);
        }

        /// <summary>
        /// 开始对查询桶是否存在的异步请求。
        /// </summary>
        /// <param name="request">查询桶是否存在的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginHeadBucket(HeadBucketRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<HeadBucketRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对查询桶是否存在的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>查询桶是否存在的响应结果。</returns>
        public bool EndHeadBucket(IAsyncResult ar)
        {
            try
            {
                this.EndDoRequest<HeadBucketRequest, ObsWebServiceResponse>(ar);
                return true;
            }
            catch (ObsException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                throw e;
            }
        }

        /// <summary>
        /// 开始对获取桶元数据的异步请求。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketMetadata(GetBucketMetadataRequest request, AsyncCallback callback, object state)
        {
            return BeginDoRequest<GetBucketMetadataRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶元数据的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶元数据信息的响应结果。</returns>
        public GetBucketMetadataResponse EndGetBucketMetadata(IAsyncResult ar)
        {
            return EndDoRequest<GetBucketMetadataRequest, GetBucketMetadataResponse>(ar);
        }

        /// <summary>
        /// 开始对设置桶配额的异步请求。
        /// </summary>
        /// <param name="request">设置桶配额的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketQuota(SetBucketQuotaRequest request, AsyncCallback callback, object state)
        {
            return BeginDoRequest<SetBucketQuotaRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶配额的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶配额的响应结果。</returns>
        public SetBucketQuotaResponse EndSetBucketQuota(IAsyncResult ar)
        {
            return EndDoRequest<SetBucketQuotaRequest, SetBucketQuotaResponse>(ar);
        }

        /// <summary>
        /// 开始对设置桶的访问权限的异步请求。
        /// </summary>
        /// <param name="request">设置访问权限请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketAcl(SetBucketAclRequest request, AsyncCallback callback, object state)
        {
            return BeginDoRequest<SetBucketAclRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶的访问权限的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置访问权限响应结果。</returns>
        public SetBucketAclResponse EndSetBucketAcl(IAsyncResult ar)
        {
            return EndDoRequest<SetBucketAclRequest, SetBucketAclResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶的区域位置的异步请求。
        /// </summary>
        /// <param name="request">获取桶区域位置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketLocation(GetBucketLocationRequest request, AsyncCallback callback, object state)
        {
            return BeginDoRequest<GetBucketLocationRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶的区域位置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶区域位置的响应结果。</returns>
        public GetBucketLocationResponse EndGetBucketLocation(IAsyncResult ar)
        {
            return EndDoRequest<GetBucketLocationRequest, GetBucketLocationResponse>(ar);
        }

        /// <summary>
        /// 开始对列举桶内对象的异步请求。
        /// </summary>
        /// <param name="request">列举桶内对象的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginListObjects(ListObjectsRequest request, AsyncCallback callback, object state)
        {
            return BeginDoRequest<ListObjectsRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对列举桶内对象的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>列举桶内对象的响应结果。</returns>
        public ListObjectsResponse EndListObjects(IAsyncResult ar)
        {
            return EndDoRequest<ListObjectsRequest, ListObjectsResponse>(ar);
        }

        /// <summary>
        /// 开始对列举桶内多版本对象的异步请求。
        /// </summary>
        /// <param name="request">列举多版本对象的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginListVersions(ListVersionsRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<ListVersionsRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对列举桶内多版本对象的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>列举多版本对象响应结果。</returns>
        public ListVersionsResponse EndListVersions(IAsyncResult ar)
        {
            return this.EndDoRequest<ListVersionsRequest, ListVersionsResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶的存量信息的异步请求。
        /// </summary>
        /// <param name="request">获取桶存量信息的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketStorageInfo(GetBucketStorageInfoRequest request, AsyncCallback callback, object state)
        {
            return BeginDoRequest<GetBucketStorageInfoRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶的存量信息的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶存量信息的响应结果。</returns>
        public GetBucketStorageInfoResponse EndGetBucketStorageInfo(IAsyncResult ar)
        {
            return EndDoRequest<GetBucketStorageInfoRequest, GetBucketStorageInfoResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶配额的异步请求。
        /// </summary>
        /// <param name="request">获取桶配额的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketQuota(GetBucketQuotaRequest request, AsyncCallback callback, object state)
        {
            return BeginDoRequest<GetBucketQuotaRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶配额的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶配额的响应结果。</returns>
        public GetBucketQuotaResponse EndGetBucketQuota(IAsyncResult ar)
        {
            return EndDoRequest<GetBucketQuotaRequest, GetBucketQuotaResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶访问权限的异步请求。
        /// </summary>
        /// <param name="request">获取桶访问权限的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketAcl(GetBucketAclRequest request, AsyncCallback callback, object state)
        {
            return BeginDoRequest<GetBucketAclRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶访问权限的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶访问权限的响应结果。</returns>
        public GetBucketAclResponse EndGetBucketAcl(IAsyncResult ar)
        {
            return EndDoRequest<GetBucketAclRequest, GetBucketAclResponse>(ar);
        }

        /// <summary>
        /// 开始对列举分段上传任务的异步请求。
        /// </summary>
        /// <param name="request">列举分段上传任务的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginListMultipartUploads(ListMultipartUploadsRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<ListMultipartUploadsRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对列举分段上传任务的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>列举分段上传任务的响应结果。</returns>
        public ListMultipartUploadsResponse EndListMultipartUploads(IAsyncResult ar)
        {
            return this.EndDoRequest<ListMultipartUploadsRequest, ListMultipartUploadsResponse>(ar);
        }

        /// <summary>
        /// 开始对删除桶的异步请求。
        /// </summary>
        /// <param name="request">删除桶的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginDeleteBucket(DeleteBucketRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<DeleteBucketRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对删除桶的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>删除桶的响应结果。</returns>
        public DeleteBucketResponse EndDeleteBucket(IAsyncResult ar)
        {
            return this.EndDoRequest<DeleteBucketRequest, DeleteBucketResponse>(ar);
        }


        /// <summary>
        /// 开始对设置桶访问日志配置的异步请求。
        /// </summary>
        /// <param name="request">设置桶访问日志配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketLogging(SetBucketLoggingRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<SetBucketLoggingRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶访问日志配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶访问日志配置的响应结果。</returns>
        public SetBucketLoggingResponse EndSetBucketLogging(IAsyncResult ar)
        {
            return this.EndDoRequest<SetBucketLoggingRequest, SetBucketLoggingResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶访问日志配置的异步请求。
        /// </summary>
        /// <param name="request">获取桶访问日志配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketLogging(GetBucketLoggingRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetBucketLoggingRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶访问日志配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶访问日志配置的响应结果。</returns>
        public GetBucketLoggingResponse EndGetBucketLogging(IAsyncResult ar)
        {
            return this.EndDoRequest<GetBucketLoggingRequest, GetBucketLoggingResponse>(ar);
        }

        /// <summary>
        /// 开始对配置桶的策略的异步请求。
        /// </summary>
        /// <param name="request">设置桶策略的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketPolicy(SetBucketPolicyRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<SetBucketPolicyRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对配置桶的策略的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶策略的响应结果。</returns>
        public SetBucketPolicyResponse EndSetBucketPolicy(IAsyncResult ar)
        {
            return this.EndDoRequest<SetBucketPolicyRequest, SetBucketPolicyResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶策略的异步请求。
        /// </summary>
        /// <param name="request">获取桶策略的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketPolicy(GetBucketPolicyRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetBucketPolicyRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶策略的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶策略的响应结果。</returns>
        public GetBucketPolicyResponse EndGetBucketPolicy(IAsyncResult ar)
        {
            return this.EndDoRequest<GetBucketPolicyRequest, GetBucketPolicyResponse>(ar);
        }

        /// <summary>
        /// 开始对删除桶策略的异步请求。
        /// </summary>
        /// <param name="request">删除桶策略的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginDeleteBucketPolicy(DeleteBucketPolicyRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<DeleteBucketPolicyRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对删除桶策略的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>删除桶策略的响应结果。</returns>
        public DeleteBucketPolicyResponse EndDeleteBucketPolicy(IAsyncResult ar)
        {
            return this.EndDoRequest<DeleteBucketPolicyRequest, DeleteBucketPolicyResponse>(ar);
        }

        /// <summary>
        /// 开始对设置桶跨域资源共享配置的异步请求。
        /// </summary>
        /// <param name="request">设置桶跨域资源共享配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketCors(SetBucketCorsRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<SetBucketCorsRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶跨域资源共享配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶跨域资源共享配置的响应结果。</returns>
        public SetBucketCorsResponse EndSetBucketCors(IAsyncResult ar)
        {
            return this.EndDoRequest<SetBucketCorsRequest, SetBucketCorsResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶的跨域资源共享配置的异步请求。
        /// </summary>
        /// <param name="request">获取桶跨域资源共享配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketCors(GetBucketCorsRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetBucketCorsRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶的跨域资源共享配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶跨域资源共享配置的响应结果。</returns>
        public GetBucketCorsResponse EndGetBucketCors(IAsyncResult ar)
        {
            return this.EndDoRequest<GetBucketCorsRequest, GetBucketCorsResponse>(ar);
        }

        /// <summary>
        /// 开始对删除指定桶的跨域资源共享配置的异步请求。
        /// </summary>
        /// <param name="request">删除指定桶跨域资源共享配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginDeleteBucketCors(DeleteBucketCorsRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<DeleteBucketCorsRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对删除指定桶的跨域资源共享配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>删除指定桶跨域资源共享配置的响应结果。</returns>
        public DeleteBucketCorsResponse EndDeleteBucketCors(IAsyncResult ar)
        {
            return this.EndDoRequest<DeleteBucketCorsRequest, DeleteBucketCorsResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶的生命周期配置的异步请求。
        /// </summary>
        /// <param name="request">获取桶生命周期配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketLifecycle(GetBucketLifecycleRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetBucketLifecycleRequest>(request, callback, state);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶生命周期配置的响应结果。</returns>
        public GetBucketLifecycleResponse EndGetBucketLifecycle(IAsyncResult ar)
        {
            return this.EndDoRequest<GetBucketLifecycleRequest, GetBucketLifecycleResponse>(ar);
        }

        /// <summary>
        /// 开始对设置桶的生命周期配置的异步请求。
        /// </summary>
        /// <param name="request">设置桶生命周期配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketLifecycle(SetBucketLifecycleRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<SetBucketLifecycleRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶的生命周期配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶生命周期配置的响应结果。</returns>
        public SetBucketLifecycleResponse EndSetBucketLifecycle(IAsyncResult ar)
        {
            return this.EndDoRequest<SetBucketLifecycleRequest, SetBucketLifecycleResponse>(ar);
        }

        /// <summary>
        /// 开始对删除桶的生命周期配置的异步请求。
        /// </summary>
        /// <param name="request">删除桶生命周期配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginDeleteBucketLifecycle(DeleteBucketLifecycleRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<DeleteBucketLifecycleRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对删除桶的生命周期配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>删除桶生命周期配置的响应结果。</returns>
        public DeleteBucketLifecycleResponse EndDeleteBucketLifecycle(IAsyncResult ar)
        {
            return this.EndDoRequest<DeleteBucketLifecycleRequest, DeleteBucketLifecycleResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶的Website（托管）配置的异步请求。
        /// </summary>
        /// <param name="request">获取桶的Website（托管）配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketWebsite(GetBucketWebsiteRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetBucketWebsiteRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶的Website（托管）配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶的Website（托管）配置响应结果。</returns>
        public GetBucketWebsiteResponse EndGetBucketWebsite(IAsyncResult ar)
        {
            return this.EndDoRequest<GetBucketWebsiteRequest, GetBucketWebsiteResponse>(ar);
        }

        /// <summary>
        /// 开始对设置桶的Website（托管）配置的异步请求。
        /// </summary>
        /// <param name="request">设置桶Website（托管）配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketWebsiteConfiguration(SetBucketWebsiteRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<SetBucketWebsiteRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶的Website（托管）配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶Website（托管）配置的响应结果。</returns>
        public SetBucketWebsiteResponse EndSetBucketWebsiteConfiguration(IAsyncResult ar)
        {
            return this.EndDoRequest<SetBucketWebsiteRequest, SetBucketWebsiteResponse>(ar);
        }

        /// <summary>
        /// 开始对删除桶的Website（托管）配置的异步请求。
        /// </summary>
        /// <param name="request">删除桶Website（托管）配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginDeleteBucketWebsite(DeleteBucketWebsiteRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<DeleteBucketWebsiteRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对删除桶的Website（托管）配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>删除桶Website（托管）配置的响应结果。</returns>
        public DeleteBucketWebsiteResponse EndDeleteBucketWebsite(IAsyncResult ar)
        {
            return this.EndDoRequest<DeleteBucketWebsiteRequest, DeleteBucketWebsiteResponse>(ar);
        }

        /// <summary>
        /// 开始对设置桶的多版本配置的异步请求。
        /// </summary>
        /// <param name="request">设置桶多版本配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketVersioning(SetBucketVersioningRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<SetBucketVersioningRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶的多版本配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶多版本配置的响应结果。</returns>
        public SetBucketVersioningResponse EndSetBucketVersioning(IAsyncResult ar)
        {
            return this.EndDoRequest<SetBucketVersioningRequest, SetBucketVersioningResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶的多版本配置的异步请求。
        /// </summary>
        /// <param name="request">获取桶多版本配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketVersioning(GetBucketVersioningRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetBucketVersioningRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶的多版本配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶多版本配置的响应结果。</returns>
        public GetBucketVersioningResponse EndGetBucketVersioning(IAsyncResult ar)
        {
            return this.EndDoRequest<GetBucketVersioningRequest, GetBucketVersioningResponse>(ar);
        }

        /// <summary>
        /// 开始对设置桶标签的异步请求。
        /// </summary>
        /// <param name="request">设置桶标签的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketTagging(SetBucketTaggingRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<SetBucketTaggingRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶标签的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶标签的响应结果。</returns>
        public SetBucketTaggingResponse EndSetBucketTagging(IAsyncResult ar)
        {
            return this.EndDoRequest<SetBucketTaggingRequest, SetBucketTaggingResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶的标签配置的异步请求。
        /// </summary>
        /// <param name="request">获取桶标签的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketTagging(GetBucketTaggingRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetBucketTaggingRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶的标签配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶标签的响应结果。</returns>
        public GetBucketTaggingResponse EndGetBucketTagging(IAsyncResult ar)
        {
            return this.EndDoRequest<GetBucketTaggingRequest, GetBucketTaggingResponse>(ar);
        }

        /// <summary>
        /// 开始对删除桶的标签的异步请求。
        /// </summary>
        /// <param name="request">删除桶标签的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginDeleteBucketTagging(DeleteBucketTaggingRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<DeleteBucketTaggingRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对删除桶的标签的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>删除桶标签的响应结果。</returns>
        public DeleteBucketTaggingResponse EndDeleteBucketTagging(IAsyncResult ar)
        {
            return this.EndDoRequest<DeleteBucketTaggingRequest, DeleteBucketTaggingResponse>(ar);
        }

        /// <summary>
        /// 开始对设置桶的跨区域复制配置的异步请求。
        /// </summary>
        /// <param name="request">设置桶跨区域复制配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketReplication(SetBucketReplicationRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<SetBucketReplicationRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶的跨区域复制配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶跨区域复制配置的响应结果。</returns>
        public SetBucketReplicationResponse EndSetBucketReplication(IAsyncResult ar)
        {
            return this.EndDoRequest<SetBucketReplicationRequest, SetBucketReplicationResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶的跨区域复制配置的异步请求。
        /// </summary>
        /// <param name="request">获取桶跨区域复制配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketReplication(GetBucketReplicationRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetBucketReplicationRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶的跨区域复制配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶跨区域复制配置的响应结果。</returns>
        public GetBucketReplicationResponse EndGetBucketReplication(IAsyncResult ar)
        {
            return this.EndDoRequest<GetBucketReplicationRequest, GetBucketReplicationResponse>(ar);
        }

        /// <summary>
        /// 开始对删除桶的跨区域复制配置的异步请求。
        /// </summary>
        /// <param name="request">删除桶跨区域复制配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginDeleteBucketReplication(DeleteBucketReplicationRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<DeleteBucketReplicationRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对删除桶的跨区域复制配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>删除桶跨区域复制配置的响应结果。</returns>
        public DeleteBucketReplicationResponse EndDeleteBucketReplication(IAsyncResult ar)
        {
            return this.EndDoRequest<DeleteBucketReplicationRequest, DeleteBucketReplicationResponse>(ar);
        }

        /// <summary>
        /// 开始对设置桶的消息通知配置的异步请求。
        /// </summary>
        /// <param name="request">设置桶消息通知配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketNotification(SetBucketNotificationRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<SetBucketNotificationRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶的消息通知配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶消息通知配置的响应结果。</returns>
        public SetBucketNotificationResponse EndSetBucketNotification(IAsyncResult ar)
        {
            return this.EndDoRequest<SetBucketNotificationRequest, SetBucketNotificationResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶的消息通知配置的异步请求。
        /// </summary>
        /// <param name="request">获取桶消息通知配置的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketNotification(GetBucketNotificationRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetBucketNotificationRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶的消息通知配置的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶消息通知配置的响应结果。</returns>
        public GetBucketNotificationReponse EndGetBucketNotification(IAsyncResult ar)
        {
            return this.EndDoRequest<GetBucketNotificationRequest, GetBucketNotificationReponse>(ar);
        }

        /// <summary>
        /// 开始对设置桶存储类型的异步请求。
        /// </summary>
        /// <param name="request">设置桶存储类型的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetBucketStoragePolicy(SetBucketStoragePolicyRequest request, AsyncCallback callback, object state)
        {
            return BeginDoRequest<SetBucketStoragePolicyRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对设置桶存储类型的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置桶存储类型的响应结果。</returns>
        public SetBucketStoragePolicyResponse EndSetBucketStoragePolicy(IAsyncResult ar)
        {
            return EndDoRequest<SetBucketStoragePolicyRequest, SetBucketStoragePolicyResponse>(ar);
        }

        /// <summary>
        /// 开始对获取桶的存储策略的异步请求。
        /// </summary>
        /// <param name="request">获取桶的存储策略的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetBucketStoragePolicy(GetBucketStoragePolicyRequest request, AsyncCallback callback, object state)
        {
            return BeginDoRequest<GetBucketStoragePolicyRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对获取桶的存储策略的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取桶的存储策略响应结果。</returns>
        public GetBucketStoragePolicyResponse EndGetBucketStoragePolicy(IAsyncResult ar)
        {
            return EndDoRequest<GetBucketStoragePolicyRequest, GetBucketStoragePolicyResponse>(ar);
        }

    }
}

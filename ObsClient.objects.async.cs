
using OBS.Internal;
using OBS.Model;
using System;

namespace OBS
{
    public partial class ObsClient
    {
        /// <summary>
        /// 开始对上传对象的异步请求。
        /// </summary>
        /// <param name="request">上传对象的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginPutObject(PutObjectRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<PutObjectRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对上传对象的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>上传对象的响应结果。</returns>
        public PutObjectResponse EndPutObject(IAsyncResult ar)
        {
            return this.EndDoRequest<PutObjectRequest, PutObjectResponse>(ar);
        }

        /// <summary>
        /// 开始对追加上传对象的异步请求。
        /// </summary>
        /// <param name="request">追加上传对象的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginAppendObject(AppendObjectRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<AppendObjectRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对追加上传对象的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>追加上传对象的响应结果。</returns>
        public AppendObjectResponse EndAppendObject(IAsyncResult ar)
        {
            return this.EndDoRequest<AppendObjectRequest, AppendObjectResponse>(ar);
        }

        /// <summary>
        /// 开始对复制对象的异步请求。
        /// </summary>
        /// <param name="request">复制对象的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginCopyObject(CopyObjectRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<CopyObjectRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
                if (string.IsNullOrEmpty(request.SourceBucketName))
                {
                    throw new ObsException(Constants.InvalidSourceBucketNameMessage, ErrorType.Sender, Constants.InvalidBucketName, "");
                }
                if (request.SourceObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidSourceObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对复制对象的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>复制对象的响应结果。</returns>
        public CopyObjectResponse EndCopyObject(IAsyncResult ar)
        {
            return this.EndDoRequest<CopyObjectRequest, CopyObjectResponse>(ar);
        }

        /// <summary>
        /// 开始对上传段的异步请求。
        /// </summary>
        /// <param name="request">上传段的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginUploadPart(UploadPartRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<UploadPartRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
                if (string.IsNullOrEmpty(request.UploadId))
                {
                    throw new ObsException(Constants.InvalidUploadIdMessage, ErrorType.Sender, Constants.InvalidUploadId, "");
                }

                if (request.PartNumber <= 0)
                {
                    throw new ObsException(Constants.InvalidPartNumberMessage, ErrorType.Sender, Constants.InvalidPartNumber, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对上传段的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>上传段的响应结果。</returns>
        public UploadPartResponse EndUploadPart(IAsyncResult ar)
        {
            UploadPartResponse response = this.EndDoRequest<UploadPartRequest, UploadPartResponse>(ar);
            HttpObsAsyncResult result = ar as HttpObsAsyncResult;
            UploadPartRequest request = result.AdditionalState as UploadPartRequest;
            response.PartNumber = request.PartNumber;
            return response;
        }

        /// <summary>
        /// 开始对复制段的异步请求。
        /// </summary>
        /// <param name="request">复制段的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginCopyPart(CopyPartRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<CopyPartRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
                if (string.IsNullOrEmpty(request.UploadId))
                {
                    throw new ObsException(Constants.InvalidUploadIdMessage, ErrorType.Sender, Constants.InvalidUploadId, "");
                }

                if (request.PartNumber <= 0)
                {
                    throw new ObsException(Constants.InvalidPartNumberMessage, ErrorType.Sender, Constants.InvalidPartNumber, "");
                }

                if (string.IsNullOrEmpty(request.SourceBucketName))
                {
                    throw new ObsException(Constants.InvalidSourceBucketNameMessage, ErrorType.Sender, Constants.InvalidBucketName, "");
                }
                if (request.SourceObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidSourceObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);

        }

        /// <summary>
        /// 结束对复制段的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>复制段的响应结果。</returns>
        public CopyPartResponse EndCopyPart(IAsyncResult ar)
        {
            CopyPartResponse response = this.EndDoRequest<CopyPartRequest, CopyPartResponse>(ar);
            HttpObsAsyncResult result = ar as HttpObsAsyncResult;
            CopyPartRequest request = result.AdditionalState as CopyPartRequest;
            response.PartNumber = request.PartNumber;
            return response;
        }

        /// <summary>
        /// 开始对下载对象的异步请求。
        /// </summary>
        /// <param name="request">下载对象的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetObject(GetObjectRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetObjectRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);

        }

        /// <summary>
        /// 结束对下载对象的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>下载对象的响应结果。</returns>
        public GetObjectResponse EndGetObject(IAsyncResult ar)
        {
            GetObjectResponse response = this.EndDoRequest<GetObjectRequest, GetObjectResponse>(ar);
            HttpObsAsyncResult result = ar as HttpObsAsyncResult;
            GetObjectRequest request = result.AdditionalState as GetObjectRequest;
            response.BucketName = request.BucketName;
            response.ObjectKey = request.ObjectKey;
            return response;
        }

        /// <summary>
        /// 开始对获取对象属性的异步请求。
        /// </summary>
        /// <param name="request">获取对象属性的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetObjectMetadata(GetObjectMetadataRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetObjectMetadataRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);

        }

        /// <summary>
        /// 结束对获取对象属性的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取对象属性的响应结果。</returns>
        public GetObjectMetadataResponse EndGetObjectMetadata(IAsyncResult ar)
        {
            GetObjectMetadataResponse response = this.EndDoRequest<GetObjectMetadataRequest, GetObjectMetadataResponse>(ar);
            HttpObsAsyncResult result = ar as HttpObsAsyncResult;
            GetObjectMetadataRequest request = result.AdditionalState as GetObjectMetadataRequest;
            response.BucketName = request.BucketName;
            response.ObjectKey = request.ObjectKey;
            return response;
        }

        /// <summary>
        /// 开始对初始化分段上传任务的异步请求。
        /// </summary>
        /// <param name="request">初始化分段上传任务的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginInitiateMultipartUpload(InitiateMultipartUploadRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<InitiateMultipartUploadRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对初始化分段上传任务的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>初始化分段上传任务的响应结果。</returns>
        public InitiateMultipartUploadResponse EndInitiateMultipartUpload(IAsyncResult ar)
        {
            return this.EndDoRequest<InitiateMultipartUploadRequest, InitiateMultipartUploadResponse>(ar);
        }

        /// <summary>
        /// 开始对合并段的异步请求。
        /// </summary>
        /// <param name="request">合并段的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginCompleteMultipartUpload(CompleteMultipartUploadRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<CompleteMultipartUploadRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
                if (string.IsNullOrEmpty(request.UploadId))
                {
                    throw new ObsException(Constants.InvalidUploadIdMessage, ErrorType.Sender, Constants.InvalidUploadId, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对合并段的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>合并段的响应结果。</returns>
        public CompleteMultipartUploadResponse EndCompleteMultipartUpload(IAsyncResult ar)
        {
            return this.EndDoRequest<CompleteMultipartUploadRequest, CompleteMultipartUploadResponse>(ar);
        }


        /// <summary>
        /// 开始对取消分段上传任务的异步请求。
        /// </summary>
        /// <param name="request">取消分段上传任务的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginAbortMultipartUpload(AbortMultipartUploadRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<AbortMultipartUploadRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
                if (string.IsNullOrEmpty(request.UploadId))
                {
                    throw new ObsException(Constants.InvalidUploadIdMessage, ErrorType.Sender, Constants.InvalidUploadId, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对取消分段上传任务的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>取消分段上传的响应结果。</returns>
        public AbortMultipartUploadResponse EndAbortMultipartUpload(IAsyncResult ar)
        {
            return this.EndDoRequest<AbortMultipartUploadRequest, AbortMultipartUploadResponse>(ar);
        }


        /// <summary>
        /// 开始对列举已上传的段的异步请求。
        /// </summary>
        /// <param name="request">列举已上传段的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginListParts(ListPartsRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<ListPartsRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
                if (string.IsNullOrEmpty(request.UploadId))
                {
                    throw new ObsException(Constants.InvalidUploadIdMessage, ErrorType.Sender, Constants.InvalidUploadId, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对列举已上传的段的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>列举已上传段的响应结果。</returns>
        public ListPartsResponse EndListParts(IAsyncResult ar)
        {
            return this.EndDoRequest<ListPartsRequest, ListPartsResponse>(ar);
        }

        /// <summary>
        /// 开始对删除对象的异步请求。
        /// </summary>
        /// <param name="request">删除对象的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginDeleteObject(DeleteObjectRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<DeleteObjectRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对删除对象的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>删除对象的响应结果。</returns>
        public DeleteObjectResponse EndDeleteObject(IAsyncResult ar)
        {
            return this.EndDoRequest<DeleteObjectRequest, DeleteObjectResponse>(ar);
        }


        /// <summary>
        /// 开始对批量删除对象的异步请求。
        /// </summary>
        /// <param name="request">批量删除对象的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginDeleteObjects(DeleteObjectsRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<DeleteObjectsRequest>(request, callback, state);
        }

        /// <summary>
        /// 结束对批量删除对象的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>批量删除对象的响应结果。</returns>
        public DeleteObjectsResponse EndDeleteObjects(IAsyncResult ar)
        {
            return this.EndDoRequest<DeleteObjectsRequest, DeleteObjectsResponse>(ar);
        }


        /// <summary>
        /// 开始对取回归档存储对象的异步请求。
        /// </summary>
        /// <param name="request">取回归档存储对象的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginRestoreObject(RestoreObjectRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<RestoreObjectRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对取回归档存储对象的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>取回归档存储对象的响应结果。</returns>
        public RestoreObjectResponse EndRestoreObject(IAsyncResult ar)
        {
            return this.EndDoRequest<RestoreObjectRequest, RestoreObjectResponse>(ar);
        }

        /// <summary>
        /// 开始对获取对象访问权限的异步请求。
        /// </summary>
        /// <param name="request">获取对象访问权限请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginGetObjectAcl(GetObjectAclRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<GetObjectAclRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对获取对象访问权限的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>获取对象访问权限响应结果。</returns>
        public GetObjectAclResponse EndGetObjectAcl(IAsyncResult ar)
        {
            return this.EndDoRequest<GetObjectAclRequest, GetObjectAclResponse>(ar);
        }


        /// <summary>
        /// 开始对设置对象访问权限的异步请求。
        /// </summary>
        /// <param name="request">设置对象访问权限的请求参数。</param>
        /// <param name="callback">异步请求回调函数。</param>
        /// <param name="state">异步请求状态对象。</param>
        /// <returns>异步请求的响应结果。</returns>
        public IAsyncResult BeginSetObjectAcl(SetObjectAclRequest request, AsyncCallback callback, object state)
        {
            return this.BeginDoRequest<SetObjectAclRequest>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            }, callback, state);
        }

        /// <summary>
        /// 结束对设置对象访问权限的异步请求。
        /// </summary>
        /// <param name="ar">异步请求的响应结果。</param>
        /// <returns>设置对象访问权限的响应结果。</returns>
        public SetObjectAclResponse EndSetObjectAcl(IAsyncResult ar)
        {
            return this.EndDoRequest<SetObjectAclRequest, SetObjectAclResponse>(ar);
        }


    }
}

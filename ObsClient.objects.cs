/*----------------------------------------------------------------------------------
// Copyright 2019 Huawei Technologies Co.,Ltd.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License.  You may obtain a copy of the
// License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations under the License.
//----------------------------------------------------------------------------------*/
using OBS.Internal;
using OBS.Model;
using System;

namespace OBS
{
    public partial class ObsClient
    {
        /// <summary>
        /// 上传对象。
        /// </summary>
        /// <param name="request">上传对象的请求参数。</param>
        /// <returns>上传对象的响应结果。</returns>
        public PutObjectResponse PutObject(PutObjectRequest request)
        {
            return this.DoRequest<PutObjectRequest, PutObjectResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            });
        }

        /// <summary>
        /// 追加上传对象。
        /// </summary>
        /// <param name="request">追加上传对象的请求参数。</param>
        /// <returns>追加上传对象的响应结果。</returns>
        public AppendObjectResponse AppendObject(AppendObjectRequest request)
        {
            return this.DoRequest<AppendObjectRequest, AppendObjectResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            });
        }


        /// <summary>
        /// 复制对象。
        /// </summary>
        /// <param name="request">复制对象的请求参数。</param>
        /// <returns>复制对象的响应结果。</returns>
        public CopyObjectResponse CopyObject(CopyObjectRequest request)
        {
            return this.DoRequest<CopyObjectRequest, CopyObjectResponse>(request, delegate ()
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
            });
        }


        /// <summary>
        /// 上传段。
        /// </summary>
        /// <param name="request">上传段的请求参数。</param>
        /// <returns>上传段的响应结果。</returns>
        public UploadPartResponse UploadPart(UploadPartRequest request)
        {
            UploadPartResponse response = this.DoRequest<UploadPartRequest, UploadPartResponse>(request, delegate ()
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
            });
            response.PartNumber = request.PartNumber;

            return response;
        }



        /// <summary>
        /// 复制段。
        /// </summary>
        /// <param name="request">复制段的请求参数。</param>
        /// <returns>复制段的响应结果。</returns>
        public CopyPartResponse CopyPart(CopyPartRequest request)
        {
            CopyPartResponse response = this.DoRequest<CopyPartRequest, CopyPartResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
                if (string.IsNullOrEmpty(request.UploadId))
                {
                    throw new ObsException(Constants.InvalidUploadIdMessage, ErrorType.Sender, Constants.InvalidUploadId, "");
                }

                if(request.PartNumber <= 0)
                {
                    throw new ObsException(Constants.InvalidPartNumberMessage, ErrorType.Sender, Constants.InvalidPartNumber, "");
                }

                if(string.IsNullOrEmpty(request.SourceBucketName))
                {
                    throw new ObsException(Constants.InvalidSourceBucketNameMessage, ErrorType.Sender, Constants.InvalidBucketName, "");
                }
                if (request.SourceObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidSourceObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            });
            response.PartNumber = request.PartNumber;
            return response;
        }

        /// <summary>
        /// 下载对象。
        /// </summary>
        /// <param name="request">下载对象的请求参数。</param>
        /// <returns>下载对象的响应结果。</returns>
        public GetObjectResponse GetObject(GetObjectRequest request)
        {
            GetObjectResponse response = this.DoRequest<GetObjectRequest, GetObjectResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            });
            response.BucketName = request.BucketName;
            response.ObjectKey = request.ObjectKey;
            return response;
        }

        /// <summary>
        /// 获取对象属性。
        /// </summary>
        /// <param name="request">获取对象属性的请求参数。</param>
        /// <returns>获取对象属性的响应结果。</returns>
        public GetObjectMetadataResponse GetObjectMetadata(GetObjectMetadataRequest request)
        {
            GetObjectMetadataResponse response = this.DoRequest<GetObjectMetadataRequest, GetObjectMetadataResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            });
            response.BucketName = request.BucketName;
            response.ObjectKey = request.ObjectKey;
            return response;
        }


        /// <summary>
        /// 初始化分段上传任务。
        /// </summary>
        /// <param name="request">初始化分段上传任务的请求参数。</param>
        /// <returns>初始化分段上传任务的响应结果。</returns>

        public InitiateMultipartUploadResponse InitiateMultipartUpload(InitiateMultipartUploadRequest request)
        {
            return this.DoRequest<InitiateMultipartUploadRequest, InitiateMultipartUploadResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            });
        }

        /// <summary>
        /// 获取对象属性。
        /// </summary>
        /// <param name="bucketName">桶名。</param>
        /// <param name="objectKey">对象名。</param>
        /// <returns>获取对象属性的响应结果。</returns>
        public GetObjectMetadataResponse GetObjectMetadata(string bucketName, string objectKey)
        {
            GetObjectMetadataRequest request = new GetObjectMetadataRequest();
            request.BucketName = bucketName;
            request.ObjectKey = objectKey;
            return this.GetObjectMetadata(request);
        }


        /// <summary>
        /// 获取对象属性。
        /// </summary>
        /// <param name="bucketName">桶名。</param>
        /// <param name="objectKey">对象名。</param>
        /// <param name="versionId">版本号。</param>
        /// <returns>获取对象属性的响应结果。</returns>
        public GetObjectMetadataResponse GetObjectMetadata(string bucketName, string objectKey, string versionId)
        {
            GetObjectMetadataRequest request = new GetObjectMetadataRequest();
            request.BucketName = bucketName;
            request.ObjectKey = objectKey;
            request.VersionId = versionId;
            return this.GetObjectMetadata(request);
        }


        /// <summary>
        /// 合并段。
        /// </summary>
        /// <param name="request">合并段的请求参数。</param>
        /// <returns>合并段的响应结果。</returns>
        public CompleteMultipartUploadResponse CompleteMultipartUpload(CompleteMultipartUploadRequest request)
        {
            return this.DoRequest<CompleteMultipartUploadRequest, CompleteMultipartUploadResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
                if (string.IsNullOrEmpty(request.UploadId))
                {
                    throw new ObsException(Constants.InvalidUploadIdMessage, ErrorType.Sender, Constants.InvalidUploadId, "");
                }
            });
        }


        /// <summary>
        /// 取消分段上传任务。
        /// </summary>
        /// <param name="request">取消分段上传任务的请求参数。</param>
        /// <returns>取消分段上传的响应结果。</returns>
        public AbortMultipartUploadResponse AbortMultipartUpload(AbortMultipartUploadRequest request)
        {
            return this.DoRequest<AbortMultipartUploadRequest, AbortMultipartUploadResponse>(request, delegate()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
                if (string.IsNullOrEmpty(request.UploadId))
                {
                    throw new ObsException(Constants.InvalidUploadIdMessage, ErrorType.Sender, Constants.InvalidUploadId, "");
                }
            });
        }


        /// <summary>
        /// 列举已上传的段。
        /// </summary>
        /// <param name="request">列举已上传段的请求参数。</param>
        /// <returns>列举已上传段的响应结果。</returns>
        public ListPartsResponse ListParts(ListPartsRequest request)
        {
            return this.DoRequest<ListPartsRequest, ListPartsResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
                if (string.IsNullOrEmpty(request.UploadId))
                {
                    throw new ObsException(Constants.InvalidUploadIdMessage, ErrorType.Sender, Constants.InvalidUploadId, "");
                }
            });
        }

        /// <summary>
        /// 删除对象。
        /// </summary>
        /// <param name="request">删除对象的请求参数。</param>
        /// <returns>删除对象的响应结果。</returns>
        public DeleteObjectResponse DeleteObject(DeleteObjectRequest request)
        {
            return this.DoRequest<DeleteObjectRequest, DeleteObjectResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            });
        }


        /// <summary>
        /// 批量删除对象。
        /// </summary>
        /// <param name="request">批量删除对象的请求参数。</param>
        /// <returns>批量删除对象的响应结果。</returns>
        public DeleteObjectsResponse DeleteObjects(DeleteObjectsRequest request)
        {
            return this.DoRequest<DeleteObjectsRequest, DeleteObjectsResponse>(request);
        }

        /// <summary>
        /// 取回归档存储对象。
        /// </summary>
        /// <param name="request">取回归档存储对象的请求参数。</param>
        /// <returns>取回归档存储对象的响应结果。</returns>
        public RestoreObjectResponse RestoreObject(RestoreObjectRequest request)
        {
            return this.DoRequest<RestoreObjectRequest, RestoreObjectResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            });
        }

        /// <summary>
        /// 获取对象访问权限。
        /// </summary>
        /// <param name="request">获取对象访问权限请求参数。</param>
        /// <returns>获取对象访问权限响应结果。</returns>
        public GetObjectAclResponse GetObjectAcl(GetObjectAclRequest request)
        {
            return this.DoRequest<GetObjectAclRequest, GetObjectAclResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            });
        }


        /// <summary>
        /// 设置对象访问权限。
        /// </summary>
        /// <param name="request">设置对象访问权限的请求参数。</param>
        /// <returns>设置对象访问权限的响应结果。</returns>
        public SetObjectAclResponse SetObjectAcl(SetObjectAclRequest request)
        {
            return this.DoRequest<SetObjectAclRequest, SetObjectAclResponse>(request, delegate ()
            {
                if (request.ObjectKey == null)
                {
                    throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
                }
            });
        }


    }
}

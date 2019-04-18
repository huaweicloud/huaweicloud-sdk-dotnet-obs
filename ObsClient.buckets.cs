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
using System;
using System.Net;
using OBS.Model;


namespace OBS
{
    public partial class ObsClient
    {
        /// <summary>
        /// 获取桶列表，返回结果按照桶名字典顺序排列。
        /// </summary>
        /// <param name="request">获取桶列表的请求参数。</param>
        /// <returns>获取桶列表的响应结果。</returns>
        public ListBucketsResponse ListBuckets(ListBucketsRequest request)
        {
            return this.DoRequest<ListBucketsRequest, ListBucketsResponse>(request);
        }

        /// <summary>
        /// 创建桶。
        /// 新创建桶的桶名在OBS中必须是唯一的。
        /// 如果是同一个用户重复创建同一区域的同名桶时返回HTTP状态码200。
        /// 除此以外的其他场景重复创建同名桶返回HTTP状态码409，表明桶已存在。一个用户可以拥有的桶的数量不能超过100个。
        /// </summary>
        /// <param name="request">创建桶请求参数。</param>
        /// 
        /// <returns>创建桶响应结果。</returns>
        public CreateBucketResponse CreateBucket(CreateBucketRequest request)
        {
            return this.DoRequest<CreateBucketRequest, CreateBucketResponse>(request);
        }

        /// <summary>
        /// 查询桶是否存在，返回的结果中HTTP状态码为200表明桶存在，否则返回404表明桶不存在。
        /// </summary>
        /// <param name="request">查询桶是否存在的请求参数。</param>
        /// 
        /// <returns>查询桶是否存在的响应结果。</returns>
        /// 
        public bool HeadBucket(HeadBucketRequest request)
        {
            try
            {
                this.DoRequest<HeadBucketRequest, ObsWebServiceResponse>(request);
                return true;
            }catch(ObsException e)
            {
                if(e.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                throw e;
            }
        }

        /// <summary>
        /// 获取桶元数据。
        /// </summary>
        /// <param name="request">获取桶元数据信息的请求参数。</param>
        /// 
        /// <returns>获取桶元数据信息的响应结果。</returns>
        /// 
        public GetBucketMetadataResponse GetBucketMetadata(GetBucketMetadataRequest request)
        {
            return DoRequest<GetBucketMetadataRequest, GetBucketMetadataResponse>(request);
        }


        /// <summary>
        /// 设置桶配额。
        /// </summary>
        /// <param name="request">设置桶配额的请求参数。</param>
        /// <returns>设置桶配额的响应结果。</returns>
        public SetBucketQuotaResponse SetBucketQuota(SetBucketQuotaRequest request)
        {
            return DoRequest<SetBucketQuotaRequest, SetBucketQuotaResponse>(request);
        }



        /// <summary>
        /// 设置桶的访问权限。
        /// </summary>
        /// <param name="request">设置访问权限请求参数。</param>
        /// 
        /// <returns>设置访问权限响应结果。</returns>
        public SetBucketAclResponse SetBucketAcl(SetBucketAclRequest request)
        {
            return DoRequest<SetBucketAclRequest, SetBucketAclResponse>(request);
        }


        /// <summary>
        /// 获取桶的区域位置。
        /// </summary>
        /// <param name="request">获取桶区域位置的请求参数。</param>
        /// <returns>获取桶区域位置的响应结果。</returns>
        public GetBucketLocationResponse GetBucketLocation(GetBucketLocationRequest request)
        {
            return DoRequest<GetBucketLocationRequest, GetBucketLocationResponse>(request);
        }


        /// <summary>
        /// 列举桶内对象。
        /// </summary>
        /// <param name="request">列举桶内对象的请求参数。</param>
        /// <returns>列举桶内对象的响应结果。</returns>
        public ListObjectsResponse ListObjects(ListObjectsRequest request)
        {
            return DoRequest<ListObjectsRequest, ListObjectsResponse>(request);
        }

        /// <summary>
        /// 列举桶内多版本对象。
        /// </summary>
        /// <param name="request">列举多版本对象的请求参数。</param>
        /// <returns>列举多版本对象响应结果。</returns>
        public ListVersionsResponse ListVersions(ListVersionsRequest request)
        {
            return this.DoRequest<ListVersionsRequest, ListVersionsResponse>(request);
        }

        /// <summary>
        /// 获取桶的存量信息，包含桶的空间大小以及对象个数。
        /// </summary>
        /// <param name="request">获取桶存量信息的请求参数。</param>
        /// <returns>获取桶存量信息的响应结果。</returns>
        public GetBucketStorageInfoResponse GetBucketStorageInfo(GetBucketStorageInfoRequest request)
        {
            return DoRequest<GetBucketStorageInfoRequest, GetBucketStorageInfoResponse>(request);
        }

        /// <summary>
        /// 获取桶配额，0代表配额没有上限。
        /// </summary>
        /// <param name="request">获取桶配额的请求参数。</param>
        /// <returns>获取桶配额的响应结果。</returns>
        public GetBucketQuotaResponse GetBucketQuota(GetBucketQuotaRequest request)
        {
            return DoRequest<GetBucketQuotaRequest, GetBucketQuotaResponse>(request);
        }


        /// <summary>
        /// 获取桶访问权限。
        /// </summary>
        /// <param name="request">获取桶访问权限的请求参数。</param>
        /// <returns>获取桶访问权限的响应结果。</returns>
        public GetBucketAclResponse GetBucketAcl(GetBucketAclRequest request)
        {
            return DoRequest<GetBucketAclRequest, GetBucketAclResponse>(request);
        }

        /// <summary>
        /// 列举分段上传任务。
        /// </summary>
        /// <param name="request">列举分段上传任务的请求参数。</param>
        /// 
        /// <returns>列举分段上传任务的响应结果。</returns>
        public ListMultipartUploadsResponse ListMultipartUploads(ListMultipartUploadsRequest request)
        {
            return this.DoRequest<ListMultipartUploadsRequest, ListMultipartUploadsResponse>(request);
        }

        /// <summary>
        /// 删除桶，待删除的桶必须为空（不包含对象、历史版本对象或分段上传碎片）。
        /// </summary>
        /// <param name="request">删除桶的请求参数。</param>
        /// <returns>删除桶的响应结果。</returns>
        public DeleteBucketResponse DeleteBucket(DeleteBucketRequest request)
        {
            return this.DoRequest<DeleteBucketRequest, DeleteBucketResponse>(request);
        }


        /// <summary>
        /// 设置桶访问日志配置。
        /// </summary>
        /// <param name="request">设置桶访问日志配置的请求参数。</param>
        /// <returns>设置桶访问日志配置的响应结果。</returns>
        public SetBucketLoggingResponse SetBucketLogging(SetBucketLoggingRequest request)
        {
            return this.DoRequest<SetBucketLoggingRequest, SetBucketLoggingResponse>(request);
        }

        /// <summary>
        /// 获取桶访问日志配置。
        /// </summary>
        /// <param name="request">获取桶访问日志配置的请求参数。</param>
        /// <returns>获取桶访问日志配置的响应结果。</returns>
        public GetBucketLoggingResponse GetBucketLogging(GetBucketLoggingRequest request)
        {
            return this.DoRequest<GetBucketLoggingRequest, GetBucketLoggingResponse>(request);
        }


        /// <summary>
        /// 配置桶的策略，如果桶已经存在一个策略，那么当前请求中的策略将完全覆盖桶中现存的策略。
        /// </summary>
        /// <param name="request">设置桶策略的请求参数。</param>
        /// <returns>设置桶策略的响应结果。</returns>
        public SetBucketPolicyResponse SetBucketPolicy(SetBucketPolicyRequest request)
        {
            return this.DoRequest<SetBucketPolicyRequest, SetBucketPolicyResponse>(request);
        }

        /// <summary>
        /// 获取桶策略。
        /// </summary>
        /// <param name="request">获取桶策略的请求参数。</param>
        /// <returns>获取桶策略的响应结果。</returns>
        public GetBucketPolicyResponse GetBucketPolicy(GetBucketPolicyRequest request)
        {
            return this.DoRequest<GetBucketPolicyRequest, GetBucketPolicyResponse>(request);
        }

        /// <summary>
        /// 删除桶策略。
        /// </summary>
        /// <param name="request">删除桶策略的请求参数。</param>
        /// <returns>删除桶策略的响应结果。</returns>
        public DeleteBucketPolicyResponse DeleteBucketPolicy(DeleteBucketPolicyRequest request)
        {
            return this.DoRequest<DeleteBucketPolicyRequest, DeleteBucketPolicyResponse>(request);
        }



        /// <summary>
        /// 设置桶跨域资源共享配置，以允许客户端浏览器进行跨域请求。
        /// </summary>
        /// <param name="request">设置桶跨域资源共享配置的请求参数。</param>
        /// <returns>设置桶跨域资源共享配置的响应结果。</returns>
        public SetBucketCorsResponse SetBucketCors(SetBucketCorsRequest request)
        {
            return this.DoRequest<SetBucketCorsRequest, SetBucketCorsResponse>(request);
        }


        /// <summary>
        /// 获取桶的跨域资源共享配置。
        /// </summary>
        /// <param name="request">获取桶跨域资源共享配置的请求参数。</param> 
        /// <returns>获取桶跨域资源共享配置的响应结果。</returns>
        public GetBucketCorsResponse GetBucketCors(GetBucketCorsRequest request)
        {
            return this.DoRequest<GetBucketCorsRequest, GetBucketCorsResponse>(request);
        }



        /// <summary>
        /// 删除指定桶的跨域资源共享配置。
        /// </summary>
        /// <param name="request">删除指定桶跨域资源共享配置的请求参数。</param>
        /// <returns>删除指定桶跨域资源共享配置的响应结果。</returns>
        public DeleteBucketCorsResponse DeleteBucketCors(DeleteBucketCorsRequest request)
        {
            return this.DoRequest<DeleteBucketCorsRequest, DeleteBucketCorsResponse>(request);
        }



        /// <summary>
        /// 获取桶的生命周期配置。
        /// </summary>
        /// <param name="request">获取桶生命周期配置的请求参数。</param>
        /// <returns>获取桶生命周期配置的响应结果。</returns>
        public GetBucketLifecycleResponse GetBucketLifecycle(GetBucketLifecycleRequest request)
        {
            return this.DoRequest<GetBucketLifecycleRequest, GetBucketLifecycleResponse>(request);
        }



        /// <summary>
        /// 设置桶的生命周期配置。
        /// </summary>
        /// <param name="request">设置桶生命周期配置的请求参数。</param> 
        /// <returns>设置桶生命周期配置的响应结果。</returns>
        public SetBucketLifecycleResponse SetBucketLifecycle(SetBucketLifecycleRequest request)
        {
            return this.DoRequest<SetBucketLifecycleRequest, SetBucketLifecycleResponse>(request);
        }



        /// <summary>
        /// 删除桶的生命周期配置。
        /// </summary>
        /// <param name="request">删除桶生命周期配置的请求参数。</param>
        /// <returns>删除桶生命周期配置的响应结果。</returns>
        public DeleteBucketLifecycleResponse DeleteBucketLifecycle(DeleteBucketLifecycleRequest request)
        {
            return this.DoRequest<DeleteBucketLifecycleRequest, DeleteBucketLifecycleResponse>(request);
        }


        /// <summary>
        /// 获取桶的Website（托管）配置。
        /// </summary>
        /// <param name="request">获取桶的Website（托管）配置的请求参数。</param>
        /// <returns>获取桶的Website（托管）配置响应结果。</returns>
        public GetBucketWebsiteResponse GetBucketWebsite(GetBucketWebsiteRequest request)
        {
            return this.DoRequest<GetBucketWebsiteRequest, GetBucketWebsiteResponse>(request);
        }


        /// <summary>
        /// 设置桶的Website（托管）配置。
        /// </summary>
        /// <param name="request">设置桶Website（托管）配置的请求参数。</param>
        /// <returns>设置桶Website（托管）配置的响应结果。</returns>
        public SetBucketWebsiteResponse SetBucketWebsiteConfiguration(SetBucketWebsiteRequest request)
        {
            return this.DoRequest<SetBucketWebsiteRequest, SetBucketWebsiteResponse>(request);
        }



        /// <summary>
        /// 删除桶的Website（托管）配置。
        /// </summary>
        /// <param name="request">删除桶Website（托管）配置的请求参数。</param>
        /// <returns>删除桶Website（托管）配置的响应结果。</returns>
        public DeleteBucketWebsiteResponse DeleteBucketWebsite(DeleteBucketWebsiteRequest request)
        {
            return this.DoRequest<DeleteBucketWebsiteRequest, DeleteBucketWebsiteResponse>(request);
        }

        /// <summary>
        /// 设置桶的多版本配置。
        /// </summary>
        /// <param name="request">设置桶多版本配置的请求参数。</param>
        /// <returns>设置桶多版本配置的响应结果。</returns>
        public SetBucketVersioningResponse SetBucketVersioning(SetBucketVersioningRequest request)
        {
            return this.DoRequest<SetBucketVersioningRequest, SetBucketVersioningResponse>(request);
        }



        /// <summary>
        /// 获取桶的多版本配置。
        /// </summary>
        /// <param name="request">获取桶多版本配置的请求参数。</param>
        /// <returns>获取桶多版本配置的响应结果。</returns>
        public GetBucketVersioningResponse GetBucketVersioning(GetBucketVersioningRequest request)
        {
            return this.DoRequest<GetBucketVersioningRequest, GetBucketVersioningResponse>(request);
        }

        /// <summary>
        /// 设置桶标签。
        /// </summary>
        /// <param name="request">设置桶标签的请求参数。</param>
        /// <returns>设置桶标签的响应结果。</returns>
        public SetBucketTaggingResponse SetBucketTagging(SetBucketTaggingRequest request)
        {
            return this.DoRequest<SetBucketTaggingRequest, SetBucketTaggingResponse>(request);
        }

        /// <summary>
        /// 获取桶的标签配置。
        /// </summary>
        /// <param name="request">获取桶标签的请求参数。</param>
        /// <returns>获取桶标签的响应结果。</returns>
        public GetBucketTaggingResponse GetBucketTagging(GetBucketTaggingRequest request)
        {
            return this.DoRequest<GetBucketTaggingRequest, GetBucketTaggingResponse>(request);
        }



        /// <summary>
        /// 删除桶的标签。
        /// </summary>
        /// <param name="request">删除桶标签的请求参数。</param>
        /// <returns>删除桶标签的响应结果。</returns>
        public DeleteBucketTaggingResponse DeleteBucketTagging(DeleteBucketTaggingRequest request)
        {
            return this.DoRequest<DeleteBucketTaggingRequest, DeleteBucketTaggingResponse>(request);
        }


        /// <summary>
        /// 设置桶的跨区域复制配置。
        /// </summary>
        /// <param name="request">设置桶跨区域复制配置的请求参数。</param>
        /// <returns>设置桶跨区域复制配置的响应结果。</returns>
        public SetBucketReplicationResponse SetBucketReplication(SetBucketReplicationRequest request)
        {
            return this.DoRequest<SetBucketReplicationRequest, SetBucketReplicationResponse>(request);
        }

        /// <summary>
        /// 获取桶的跨区域复制配置。
        /// </summary>
        /// <param name="request">获取桶跨区域复制配置的请求参数。</param>
        /// <returns>获取桶跨区域复制配置的响应结果。</returns>
        public GetBucketReplicationResponse GetBucketReplication(GetBucketReplicationRequest request)
        {
            return this.DoRequest<GetBucketReplicationRequest, GetBucketReplicationResponse>(request);
        }



        /// <summary>
        /// 删除桶的跨区域复制配置。
        /// </summary>
        /// <param name="request">删除桶跨区域复制配置的请求参数。</param>
        /// <returns>删除桶跨区域复制配置的响应结果。</returns>
        public DeleteBucketReplicationResponse DeleteBucketReplication(DeleteBucketReplicationRequest request)
        {
            return this.DoRequest<DeleteBucketReplicationRequest, DeleteBucketReplicationResponse>(request);
        }


        /// <summary>
        /// 设置桶的消息通知配置。
        /// </summary>
        /// <param name="request">设置桶消息通知配置的请求参数。</param>
        /// <returns>设置桶消息通知配置的响应结果。</returns>
        public SetBucketNotificationResponse SetBucketNotification(SetBucketNotificationRequest request)
        {
            return this.DoRequest<SetBucketNotificationRequest, SetBucketNotificationResponse>(request);
        }

        /// <summary>
        /// 获取桶的消息通知配置。
        /// </summary>
        /// <param name="request">获取桶消息通知配置的请求参数。</param>
        /// <returns>获取桶消息通知配置的响应结果。</returns>
        public GetBucketNotificationReponse GetBucketNotification(GetBucketNotificationRequest request)
        {
            return this.DoRequest<GetBucketNotificationRequest, GetBucketNotificationReponse>(request);
        }

        /// <summary>
        /// 设置桶存储类型。
        /// </summary>
        /// <param name="request">设置桶存储类型的请求参数。</param>
        /// <returns>设置桶存储类型的响应结果。</returns>
        public SetBucketStoragePolicyResponse SetBucketStoragePolicy(SetBucketStoragePolicyRequest request)
        {
            return DoRequest<SetBucketStoragePolicyRequest, SetBucketStoragePolicyResponse>(request);
        }

        /// <summary>
        /// 获取桶的存储策略。
        /// </summary>
        /// <param name="request">获取桶的存储策略的请求参数。</param>
        /// <returns>获取桶的存储策略响应结果。</returns>
        public GetBucketStoragePolicyResponse GetBucketStoragePolicy(GetBucketStoragePolicyRequest request)
        {
            return DoRequest<GetBucketStoragePolicyRequest, GetBucketStoragePolicyResponse>(request);
        }






    }
}

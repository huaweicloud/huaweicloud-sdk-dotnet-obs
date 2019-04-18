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
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 创建桶请求参数。
    /// </summary>
    public class CreateBucketRequest : ObsBucketWebServiceRequest
    {

        private IDictionary<ExtensionBucketPermissionEnum, IList<string>> extensionPermissionMap;

        /// <summary>
        /// 为用户授予OBS桶扩展权限。
        /// </summary>
        /// <param name="domainId">用户的domainId。</param>
        /// <param name="extensionPermissionEnum">OBS扩展权限。</param>
        public void GrantExtensionPermission(string domainId, ExtensionBucketPermissionEnum extensionPermissionEnum)
        {
            if(string.IsNullOrEmpty(domainId))
            {
                return;
            }

            IList<string> domainIds;

            ExtensionPermissionMap.TryGetValue(extensionPermissionEnum, out domainIds);

            if(domainIds == null)
            {
                domainIds = new List<string>();
                ExtensionPermissionMap.Add(extensionPermissionEnum, domainIds);
            }
            domainId = domainId.Trim();
            if (!domainIds.Contains(domainId))
            {
                domainIds.Add(domainId);
            }

        }

        /// <summary>
        /// 撤回用户的OBS桶扩展权限。
        /// </summary>
        /// <param name="domainId">用户的domainId。</param>
        /// <param name="extensionPermissionEnum">OBS扩展权限。</param>
        public void WithDrawExtensionPermission(string domainId, ExtensionBucketPermissionEnum extensionPermissionEnum)
        {
            if (string.IsNullOrEmpty(domainId))
            {
                return;
            }

            IList<string> domainIds;
            ExtensionPermissionMap.TryGetValue(extensionPermissionEnum, out domainIds);
            domainId = domainId.Trim();
            if (domainIds != null && domainIds.Contains(domainId))
            {
                domainIds.Remove(domainId);
            }
        }

        internal IDictionary<ExtensionBucketPermissionEnum, IList<string>> ExtensionPermissionMap
        {
            get
            {
                return extensionPermissionMap ?? (extensionPermissionMap = new Dictionary<ExtensionBucketPermissionEnum, IList<string>>());
            }
        }

        /// <summary>
        /// 创桶时可指定的桶的存储类型。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public StorageClassEnum? StorageClass
        {
            get;
            set;
        }


        /// <summary>
        /// 创桶时可指定的预定义访问策略。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public CannedAclEnum? CannedAcl
        {
            get;
            set;
        }


        /// <summary>
        /// 创桶时可指定的集群类型。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public AvailableZoneEnum? AvailableZone
        {
            get;
            set;
        }

        /// <summary>
        /// 桶名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// 桶命名规则如下：
        /// 1. 3～63个字符，数字或字母开头，支持小写字母、数字、“-”、“.”。
        /// 2. 禁止使用IP地址。
        /// 3.禁止以“-”或“.”开头及结尾。
        /// 4.禁止两个“.”相邻（如：“my..bucket”）。
        /// 5.禁止“.”和“-”相邻（如：“my-.bucket”和“my.-bucket”）。
        /// </para>
        /// </remarks>
        public override string BucketName
        {
            get;
            set;
        }


        /// <summary>
        /// 桶所在的区域。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// 创建桶的区域， 如果使用的终端节点归属于默认区域，可以不携带此参数；如果使用的终端节点归属于其他区域，则必须携带此参数
        /// </para>
        /// </remarks>
        public string Location
        {
            get;
            set;
        }

        internal override string GetAction()
        {
            return "CreateBucket";
        }

    }
}
    

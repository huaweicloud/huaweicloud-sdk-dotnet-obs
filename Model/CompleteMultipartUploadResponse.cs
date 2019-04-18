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

namespace OBS.Model
{
    /// <summary>
    /// 合并段的响应结果。
    /// </summary>
    public class CompleteMultipartUploadResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 合并段后得到的对象的url。
        /// </summary>
        public string Location
        {
            get;
            internal set;
        }

        /// <summary>
        /// 合并段所在的桶。
        /// </summary>
        public string BucketName
        {
            get;
            internal set;
        }


        /// <summary>
        /// 合并段后得到的对象名。
        /// </summary>
        public string ObjectKey
        {
            get;
            internal set;
        }

        /// <summary>
        /// 合并段后根据各个段的ETag值计算出的结果。
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }

        /// <summary>
        /// 合并段后得到的对象版本号。
        /// </summary>
        public string VersionId
        {
            get;
            internal set;
        }

        /// <summary>
        /// 合并段后得到的对象的全路径。
        /// </summary>
        public string ObjectUrl
        {
            get;
            internal set;
        }
    }
}
    

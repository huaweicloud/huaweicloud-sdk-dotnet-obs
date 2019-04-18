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
    /// 列举分段上传任务的请求参数。
    /// </summary>
    public class ListMultipartUploadsRequest : ObsBucketWebServiceRequest
    {


        internal override string GetAction()
        {
            return "ListMultipartUploads";
        }

        /// <summary>
        /// 对象名进行分组的字符。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// 对于对象名中包含Delimiter的任务，其对象名（如果请求中指定了Prefix，则此处的对象名需要去掉Prefix）
        /// 中从首字符至第一个Delimiter之间的字符串将作为一个分组并作为CommonPrefix返回。
        /// </para>
        /// </remarks>
        public string Delimiter
        {
            get;
            set;
        }



        /// <summary>
        /// 列举分段上传任务的起始位置（按对象名排序）。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string KeyMarker
        {
            get;
            set;
        }



        /// <summary>
        /// 列举分段上传任务的最大数目。  
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// 取值范围为1~1000，当超出范围时，按照默认的1000进行处理。
        /// </para>
        /// </remarks>
        public int? MaxUploads
        {
            get;
            set;
        }



        /// <summary>
        /// 列举分段上传任务的对象名前缀。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Prefix
        {
            get;
            set;
        }



        /// <summary>
        /// 列举分段上传任务的起始位置（按分段上传任务的ID号排序）。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，只有与KeyMarker参数一起使用时才有意义，用于指定返回结果的起始位置。
        /// </para>
        /// </remarks>
        public string UploadIdMarker
        {
            get;
            set;
        }

    }
}
    

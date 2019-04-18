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
    /// 多版本对象信息。
    /// </summary>
    public class ObsObjectVersion : ObsObject
    {

        /// <summary>
        /// 是否是最新版本。
        /// </summary>
        public bool IsLatest
        {
            get;
            internal set;
        }

        /// <summary>
        /// 版本号。
        /// </summary>
        public string VersionId
        {
            get;
            internal set;
        }

        /// <summary>
        /// 是否设置对象删除标记。
        /// </summary>
        public bool IsDeleteMarker
        {
            get;
            internal set;
        }
    }
}

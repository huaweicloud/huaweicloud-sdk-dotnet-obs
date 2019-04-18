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
    /// 下载或复制对象的范围
    /// </summary>
    public class ByteRange
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public ByteRange()
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="start">起始位置。</param>
        /// <param name="end">结束位置。</param>
        public ByteRange(long start, long end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// 起始位置，单位字节。
        /// </summary>
        public long Start
        {
            get;
            set;
        }

        /// <summary>
        /// 结束位置，单位字节。
        /// </summary>
        public long End
        {
            get;
            set;
        }

    }
}

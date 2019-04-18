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
    /// 桶标签。
    /// </summary>
    public class Tag
    {
        

        /// <summary>
        /// 标签键。 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// 最大36个字符。可以包含：A-Z，a-z，0-9，’-’，’_’以及Unicode(\u4E00-\u9FFF)。同一个桶，Tag的Key不能重复。
        /// </para>
        /// </remarks>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// 标签值。 
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// 最大值为43个字符。可以包含：A-Z，a-z，0-9，’-’，’_’，’.’以及Unicode(\u4E00-\u9FFF)。
        /// </para>
        /// </remarks>
        public string Value
        {
            get;
            set;
        }

    }
}

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
using System.Collections.Generic;


namespace OBS.Model
{
    /// <summary>
    /// 访问权限。
    /// </summary>
    public class AccessControlList : AbstractAccessControlList
    {

        /// <summary>
        /// 所有者。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public Owner Owner { get; set; }


        /// <summary>
        /// 对象的访问权限传递标识，只对对象权限有效。
        /// </summary>
        public bool Delivered
        {
            get;
            set;
        }
    }
}


using System;
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// POST表单鉴权响应结果。
    /// </summary>
    public class CreatePostSignatureResponse
    {

        /// <summary>
        /// 签名串，用于填充表单。
        /// </summary>
        public string Signature
        {
            get;
            internal set;
        }

    }
}
    

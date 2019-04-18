
using System;
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// POST表单鉴权响应结果。
    /// </summary>
    public class CreateV4PostSignatureResponse : CreatePostSignatureResponse
    {
        /// <summary>
        /// 签名算法，用于填充表单。
        /// </summary>
        public string Algorithm
        {
            get;
            internal set;
        }

        /// <summary>
        /// Credential信息，用于填充表单。
        /// </summary>
        public string Credential
        {
            get;
            internal set;
        }

        /// <summary>
        /// ISO 8601格式日期，用于填充表单。
        /// </summary>
        public string Date
        {
            get;
            internal set;
        }

    }
}
    

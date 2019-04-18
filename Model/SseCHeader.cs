using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Model
{
    /// <summary>
    /// SSE-C加解密方式头域信息
    /// </summary>
    public class SseCHeader : SseHeader
    {
        /// <summary>
        /// SSE-C加解密方式下的算法。
        /// </summary>
        public SseCAlgorithmEnum Algorithm
        {
            get;
            set;
        }

        /// <summary>
        /// SSE-C加解密方式下使用的密钥，用于加解密对象，该值是密钥进行base64encode后的值。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，不可与Key一起使用。
        /// </para>
        /// </remarks>
        public string KeyBase64
        {
            get;
            set;
        }

        /// <summary>
        /// SSE-C加解密方式下使用的密钥，用于加解密对象，该值是密钥未经过base64encode后的值
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选，不可与KeyBase64一起使用。
        /// </para>
        /// </remarks>
        public byte[] Key
        {
            get;
            set;
        }
    }
}

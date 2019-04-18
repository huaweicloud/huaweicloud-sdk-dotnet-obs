using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Model
{
    /// <summary>
    /// SSE-KMS加密方式头域信息。
    /// </summary>
    public class SseKmsHeader : SseHeader
    {
        /// <summary>
        /// SSE-KMS加密方式下的算法。
        /// </summary>
        public SseKmsAlgorithmEnum Algorithm
        {
            get;
            set;
        }

        /// <summary>
        /// SSE-KMS加密方式下使用的主密钥。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string Key
        {
            get;
            set;
        }
    }
}

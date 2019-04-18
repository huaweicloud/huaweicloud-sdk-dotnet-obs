
using System;
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 复制段的请求参数。
    /// </summary>
    public class CopyPartRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "CopyPart";
        }

        /// <summary>
        /// 源桶名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string SourceBucketName
        {
            get;
            set;
        }


        /// <summary>
        /// 源对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string SourceObjectKey
        {
            get;
            set;
        }


        /// <summary>
        /// 源对象的版本号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string SourceVersionId
        {
            get;
            set;
        }

      

        /// <summary>
        /// 目标对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }

        /// <summary>
        /// 分段上传任务的ID号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string UploadId
        {
            get;
            set;
        }


        /// <summary>
        /// 目标段的分段号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public int PartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 复制源对象的范围。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public ByteRange ByteRange
        {
            get;
            set;
        }


        /// <summary>
        /// 源对象SSE-C解密头域信息。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public SseCHeader SourceSseCHeader
        {
            get;
            set;
        }

        /// <summary>
        /// 段内容SSE-C加密头域信息。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public SseCHeader DestinationSseCHeader
        {
            get;
            set;
        }

    }
}
    

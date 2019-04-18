
using System.Collections.Generic;


namespace OBS.Model
{
    /// <summary>
    /// 列举已上传的段的响应结果。
    /// </summary>
    public class ListPartsResponse : ObsWebServiceResponse
    {

        private IList<PartDetail> parts;

        /// <summary>
        /// 桶名。
        /// </summary>
        public string BucketName
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象名。
        /// </summary>
        public string ObjectKey
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务的ID。
        /// </summary>
        public string UploadId
        {
            get;
            internal set;
        }

        /// <summary>
        /// 待列举段的起始位置。
        /// </summary>
        public int? PartNumberMarker
        {
            get;
            internal set;
        }


        /// <summary>
        /// 下次请求的起始位置。
        /// </summary>
        public int? NextPartNumberMarker
        {
            get;
            internal set;
        }

        /// <summary>
        /// 列举已上传段的最大条目数。 
        /// </summary>
        public int? MaxParts
        {
            get;
            internal set;
        }

        /// <summary>
        /// 判断列举结果是否被截断。
        ///  true表示截断，本次没有返回全部结果；false表示未截断，本次已经返回了全部结果。
        /// </summary>
        public bool IsTruncated
        {
            get;
            internal set;
        }

        /// <summary>
        /// 已上传的段列表。
        /// </summary>
        public IList<PartDetail> Parts
        {
            get {
                
                return this.parts ?? (this.parts = new List<PartDetail>()); }
            internal set { this.parts = value; }
        }

        /// <summary>
        /// 分段上传任务的创建者。
        /// </summary>
        public Initiator Initiator
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务的所有者。
        /// </summary>
        public Owner Owner
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段上传任务最终生成对象的存储类型。
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }

    }
}
    

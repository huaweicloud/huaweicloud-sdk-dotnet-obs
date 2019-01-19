


namespace OBS.Model
{
    /// <summary>
    /// 列举已上传段的请求参数。
    /// </summary>
    public class ListPartsRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "ListParts";
        }

        /// <summary>
        /// 对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        ///  </para> 
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }

        /// <summary>
        /// 列举已上传的段返回结果最大段数目。  
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        ///  </para> 
        /// </remarks>
        public int? MaxParts
        {
            get;
            set;
        }

        /// <summary>
        /// 待列出段的起始位置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        ///  </para> 
        /// </remarks>
        public int? PartNumberMarker
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
        ///  </para> 
        /// </remarks>
        public string UploadId
        {
            get;
            set;
        }

    }
}
    

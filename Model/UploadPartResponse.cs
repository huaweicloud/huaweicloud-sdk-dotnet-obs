

namespace OBS.Model
{
    /// <summary>
    /// 上传段的响应结果。
    /// </summary>
    public class UploadPartResponse : ObsWebServiceResponse
    {


        /// <summary>
        /// 分段的ETag校验值。
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }

        /// <summary>
        /// 分段号。
        /// </summary>
        public int PartNumber
        {
            get;
            internal set;
        }


    }
}
    

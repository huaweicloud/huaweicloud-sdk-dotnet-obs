


namespace OBS.Model
{
    /// <summary>
    /// 获取桶区域位置的响应结果。
    /// </summary>
    public class GetBucketLocationResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 桶的区域位置。
        /// </summary>
        public string Location
        {
            get;
            internal set;
        }
    }
}
    

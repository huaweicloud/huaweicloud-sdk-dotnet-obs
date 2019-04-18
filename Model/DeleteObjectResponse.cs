

namespace OBS.Model
{
    /// <summary>
    /// 删除对象的响应结果。
    /// </summary>
    public class DeleteObjectResponse : ObsWebServiceResponse
    {

        /// <summary>
        ///标识删除的对象是否是删除标记。
        /// </summary>
        public bool DeleteMarker
        {
            get;
            internal set;
        }

        /// <summary>
        /// 待删除对象的版本号。
        /// </summary>
        public string VersionId
        {
            get;
            internal set;
        }

    }
}
    

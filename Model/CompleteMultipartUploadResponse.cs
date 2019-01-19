
namespace OBS.Model
{
    /// <summary>
    /// 合并段的响应结果。
    /// </summary>
    public class CompleteMultipartUploadResponse : ObsWebServiceResponse
    {

        /// <summary>
        /// 合并段后得到的对象的url。
        /// </summary>
        public string Location
        {
            get;
            internal set;
        }

        /// <summary>
        /// 合并段所在的桶。
        /// </summary>
        public string BucketName
        {
            get;
            internal set;
        }


        /// <summary>
        /// 合并段后得到的对象名。
        /// </summary>
        public string ObjectKey
        {
            get;
            internal set;
        }

        /// <summary>
        /// 合并段后根据各个段的ETag值计算出的结果。
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }

        /// <summary>
        /// 合并段后得到的对象版本号。
        /// </summary>
        public string VersionId
        {
            get;
            internal set;
        }

        /// <summary>
        /// 合并段后得到的对象的全路径。
        /// </summary>
        public string ObjectUrl
        {
            get;
            internal set;
        }
    }
}
    

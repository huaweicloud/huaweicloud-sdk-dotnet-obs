

namespace OBS.Model
{
    /// <summary>
    /// 上传对象的响应结果。
    /// </summary>
    public class PutObjectResponse : ObsWebServiceResponse
    {
       

        /// <summary>
        /// 对象的ETag校验值。 
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象版本号。
        /// </summary>
        public string VersionId
        {
            get;
            internal set;
        }


        /// <summary>
        /// 对象存储类型。
        /// </summary>
        public StorageClassEnum? StorageClass
        {
            get;
            internal set;
        }

        /// <summary>
        /// 对象的全路径。
        /// </summary>
        public string ObjectUrl
        {
            get;
            internal set;
        }

       
    }
}
    

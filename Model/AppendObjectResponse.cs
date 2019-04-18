

namespace OBS.Model
{
    /// <summary>
    /// 追加上传对象的响应结果。
    /// </summary>
    public class AppendObjectResponse : ObsWebServiceResponse
    {

        private long _nextPosition = -1;

        /// <summary>
        /// 本次追加内容的etag校验值。 
        /// </summary>
        public string ETag
        {
            get;
            internal set;
        }

        /// <summary>
        /// 下次追加上传的位置。
        /// </summary>
        public long NextPosition
        {
            get
            {
                return _nextPosition;
            }
            internal set
            {
                this._nextPosition = value;
            }
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
    

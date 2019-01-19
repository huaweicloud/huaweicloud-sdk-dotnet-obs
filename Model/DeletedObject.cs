
namespace OBS.Model
{
    /// <summary>
    /// 批量删除成功的对象。
    /// </summary>
    public class DeletedObject
    {
        

        /// <summary>
        /// 标识对象是否标记删除。
        /// </summary>
        public bool DeleteMarker
        {
            get;
            internal set;
        }

        /// <summary>
        /// 删除标记的版本号。
        /// </summary>
        public string DeleteMarkerVersionId
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
        /// 对象版本号。
        /// </summary>
        public string VersionId
        {
            get;
            internal set;
        }

    }
}

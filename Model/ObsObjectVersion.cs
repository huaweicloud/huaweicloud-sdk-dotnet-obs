
namespace OBS.Model
{
    /// <summary>
    /// 多版本对象信息。
    /// </summary>
    public class ObsObjectVersion : ObsObject
    {

        /// <summary>
        /// 是否是最新版本。
        /// </summary>
        public bool IsLatest
        {
            get;
            internal set;
        }

        /// <summary>
        /// 版本号。
        /// </summary>
        public string VersionId
        {
            get;
            internal set;
        }

        /// <summary>
        /// 是否设置对象删除标记。
        /// </summary>
        public bool IsDeleteMarker
        {
            get;
            internal set;
        }
    }
}

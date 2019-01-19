
namespace OBS.Model
{
    /// <summary>
    /// 批量删除失败的结果。
    /// </summary>
    public class DeleteError
    {
        

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

        /// <summary>
        /// 删除失败的错误码。
        /// </summary>
        public string Code
        {
            get;
            internal set;
        }

        /// <summary>
        ///  删除失败的错误信息。
        /// </summary>
        public string Message
        {
            get;
            internal set;
        }
    }
}

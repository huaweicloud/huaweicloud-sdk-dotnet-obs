
namespace OBS.Model
{
    /// <summary>
    /// 待删除的对象信息。
    /// </summary>
    public class KeyVersion
    {
        

        /// <summary>
        /// 对象名。
        /// </summary>
        public string Key
        {
            get;
            set;
        }



        /// <summary>
        /// 对象版本号。
        /// </summary>
        public string VersionId
        {
            get;
            set;
        }


    }
}

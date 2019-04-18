
namespace OBS.Model
{
    /// <summary>
    /// 取回归档存储对象的请求参数。
    /// </summary>
    public class RestoreObjectRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "RestoreObject";
        }

        /// <summary>
        /// 对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }

        /// <summary>
        /// 取回对象的保存时间。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public int Days
        {
            get;
            set;
        }

        /// <summary>
        /// 对象版本号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public string VersionId
        {
            get;
            set;
        }


        /// <summary>
        /// 取回选项。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public RestoreTierEnum? Tier
        {
            get;
            set;
        }

    }
}    

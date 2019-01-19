
using System.Collections.Generic;


namespace OBS.Model
{
    /// <summary>
    /// 桶的访问日志配置。
    /// </summary>
    public class LoggingConfiguration : AbstractAccessControlList
    {
        

        /// <summary>
        /// 生成日志的目标桶。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string TargetBucketName { get; set; }

        /// <summary>
        /// 在目标桶中生成日志对象的对象名前缀。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string TargetPrefix { get; set; }

        /// <summary>
        /// 委托名字
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public string Agency
        {
            get;
            set;
        }

    }
}


using System.Collections.Generic;
using System.IO;

namespace OBS.Model
{
    /// <summary>
    /// 追加上传对象的请求参数。
    /// </summary>
    public class AppendObjectRequest : PutObjectRequest
    {

        internal override string GetAction()
        {
            return "AppendObject";
        }

        /// <summary>
        /// 追加上传的位置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public long Position
        {
            get;
            set;
        }

    }
}
    

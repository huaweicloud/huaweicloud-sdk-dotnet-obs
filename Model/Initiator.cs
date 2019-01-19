
using System;

namespace OBS.Model
{
    /// <summary>
    /// 分段上传任务的创建者。
    /// </summary>
    public class Initiator
    {


        /// <summary>
        /// 用户名。
        /// </summary>
        [Obsolete]
        public string DisplayName
        {
            get;
            set;
        }

        /// <summary>
        /// 用户的DomainId。
        /// </summary>
        public string Id
        {
            get;
            set;
        }

    }
}

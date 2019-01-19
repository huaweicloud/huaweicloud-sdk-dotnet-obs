

using System;

namespace OBS.Model
{
    /// <summary>
    /// 桶或对象的所有者信息。
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// 所有者的名称。
        /// </summary>
        [Obsolete]
        public string DisplayName { set; get; }

        /// <summary>
        /// 所有者的DomainId。
        /// </summary>
        public string Id { get; set; }
    }
}

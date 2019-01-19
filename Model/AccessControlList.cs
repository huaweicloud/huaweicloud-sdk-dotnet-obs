
using System.Collections.Generic;


namespace OBS.Model
{
    /// <summary>
    /// 访问权限。
    /// </summary>
    public class AccessControlList : AbstractAccessControlList
    {

        /// <summary>
        /// 所有者。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public Owner Owner { get; set; }


        /// <summary>
        /// 对象的访问权限传递标识，只对对象权限有效。
        /// </summary>
        public bool Delivered
        {
            get;
            set;
        }
    }
}



namespace OBS.Model
{
    /// <summary>
    /// 被授权的用户/用户组及其对应的权限信息。
    /// </summary>
    public class Grant
    {
        

        /// <summary>
        /// 被授权的用户/用户组。
        /// </summary>
        public Grantee Grantee
        {
            get;
            set;
        }

        /// <summary>
        /// 权限信息。
        /// </summary>
        public PermissionEnum? Permission
        {
            get;
            set;
        }

        /// <summary>
        /// 桶的访问权限传递标识，只对桶权限有效。
        /// </summary>
        public bool Delivered
        {
            set;
            get;
        }

    }
}

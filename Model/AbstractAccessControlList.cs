using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Model
{
    public abstract class AbstractAccessControlList
    {
        private IList<Grant> grants;

        /// <summary>
        /// 用户/用户组的权限列表。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        /// </para>
        /// </remarks>
        public IList<Grant> Grants
        {
            get
            {

                return this.grants ?? (this.grants = new List<Grant>());
            }
            set { this.grants = value; }
        }



        /// <summary>
        /// 为用户/用户组指定权限。
        /// </summary>
        /// <param name="grantee">被授权的用户/用户组</param>
        /// <param name="permission">权限信息</param>
        public void AddGrant(Grantee grantee, PermissionEnum permission)
        {
            Grant grant = new Grant { };
            grant.Grantee = grantee;
            grant.Permission = permission;
            Grants.Add(grant);
        }

        /// <summary>
        /// 移除用户/用户组的指定权限。
        /// </summary>
        /// <param name="grantee">被授权的用户/用户组</param>
        /// <param name="permission">权限信息</param>
        public void RemoveGrant(Grantee grantee, PermissionEnum permission)
        {
            foreach (Grant grant in Grants)
            {
                if (grant.Grantee.Equals(grantee) && grant.Permission == permission)
                {
                    Grants.Remove(grant);
                    break;
                }
            }
        }

        /// <summary>
        /// 移除用户/用户组的所有权限。
        /// </summary>
        /// <param name="grantee">被授权的用户</param>
        public void RemoveGrant(Grantee grantee)
        {
            IList<Grant> removeList = new List<Grant>();
            foreach (Grant grant in Grants)
            {
                if (grant.Grantee.Equals(grantee))
                {
                    removeList.Add(grant);
                }
            }
            foreach (Grant grant in removeList)
            {
                this.Grants.Remove(grant);
            }
        }
    }
}

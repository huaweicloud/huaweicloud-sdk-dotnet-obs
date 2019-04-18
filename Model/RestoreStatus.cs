
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace OBS.Model
{
    /// <summary>
    /// 对象的取回状态。
    /// </summary>
    public class RestoreStatus
    {

        /// <summary>
        /// 取回后的失效时间。
        /// </summary>
        public DateTime? ExpiryDate
        {
            get;
            set;
        }

        /// <summary>
        /// 标识对象的取回状态。
        /// </summary>
        public bool Restored
        {
            get;
            set;
        }
    }
}

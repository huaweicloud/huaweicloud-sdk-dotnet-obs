
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace OBS.Model
{
    /// <summary>
    /// 对象的详细过期信息。
    /// </summary>
    public class ExpirationDetail
    {

        /// <summary>
        /// 过期时间。
        /// </summary>
        public DateTime? ExpiryDate
        {
            get;
            set;
        }

        /// <summary>
        /// ID号。
        /// </summary>
        public string RuleId
        {
            get;
            set;
        }
    }
}

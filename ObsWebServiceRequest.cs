
using OBS.Internal;
using System.Collections.Generic;

namespace OBS
{
    /// <summary>
    /// 服务请求参数的基类。 
    /// </summary>
    public abstract class ObsWebServiceRequest
    {

        internal virtual string GetAction()
        {
            return "ObsWebServiceRequest";
        }

        internal object Sender
        {
            get;
            set;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        protected ObsWebServiceRequest()
        {
        }

    }
}

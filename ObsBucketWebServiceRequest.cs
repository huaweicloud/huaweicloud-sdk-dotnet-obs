using System;
using System.Collections.Generic;
using System.Text;

namespace OBS
{
    /// <summary>
    /// 服务请求参数的基类（带桶名）。 
    /// </summary>
    public abstract class ObsBucketWebServiceRequest : ObsWebServiceRequest
    {
        /// <summary>
        /// 桶名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        /// </para>
        /// </remarks>
        public virtual string BucketName
        {
            get;
            set;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Internal.Negotiation
{
    internal class GetApiVersionRequest : ObsWebServiceRequest
    {
        internal override string GetAction()
        {
            return "GetApiVersion";
        }

        public string BucketName
        {
            get;
            set;
        }
    }
}

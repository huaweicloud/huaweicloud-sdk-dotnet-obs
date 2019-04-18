using OBS.Internal.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBS.Internal
{
    internal class HttpContext
    {

        private readonly IList<HttpResponseHandler> _handlers = new List<HttpResponseHandler>();
        public HttpContext(SecurityProvider sp, ObsConfig obsConfig)
        {
            this.SecurityProvider = sp;
            this.ObsConfig = obsConfig;
        }

        public string RedirectLocation
        {
            get;
            set;
        }

        public ObsConfig ObsConfig
        {
            get;
            set;
        }

        public SecurityProvider SecurityProvider
        {
            get;
            set;
        }

        public bool SkipAuth
        {
            get;
            set;
        }

        public AuthTypeEnum? AuthType
        {
            get;
            set;
        }

        public IList<HttpResponseHandler> Handlers
        {
            get { return _handlers; }
        }

        public AuthTypeEnum ChooseAuthType
        {
            get { return this.AuthType.HasValue ? this.AuthType.Value : this.ObsConfig.AuthType; }
        }

    }
}

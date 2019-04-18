

using System;
using System.Collections.Generic;
using System.Globalization;

namespace OBS.Internal.Auth
{
    internal abstract class Signer
    {

        internal void DoAuth(HttpRequest request, HttpContext context, IHeaders iheaders)
        {
            if (request.Headers.ContainsKey(Constants.CommonHeaders.Authorization))
            {
                request.Headers.Remove(Constants.CommonHeaders.Authorization);
            }

            if (request.Headers.ContainsKey(Constants.CommonHeaders.Date))
            {
                request.Headers.Remove(Constants.CommonHeaders.Date);
            }

            //date
            if (!request.Headers.ContainsKey(iheaders.DateHeader()))
            {
                request.Headers.Add(Constants.CommonHeaders.Date, DateTime.UtcNow.ToString(Constants.RFC822DateFormat, Constants.CultureInfo));
            }

            //host
            string endpoint = string.IsNullOrEmpty(context.RedirectLocation) ? request.Endpoint : context.RedirectLocation;
            request.Headers[Constants.CommonHeaders.Host] = request.GetHost(endpoint);

            // anonymous user
            if (string.IsNullOrEmpty(context.SecurityProvider.Ak) || string.IsNullOrEmpty(context.SecurityProvider.Sk))
            {
                return;
            }

            if (!string.IsNullOrEmpty(context.SecurityProvider.Token) && !request.Headers.ContainsKey(iheaders.SecurityTokenHeader()))
            {
                request.Headers.Add(iheaders.SecurityTokenHeader(), context.SecurityProvider.Token.Trim());
            }
            this._DoAuth(request, context, iheaders);
        }

        internal abstract IDictionary<string,string> GetSignature(HttpRequest request, HttpContext context, IHeaders iheaders);

        protected abstract void _DoAuth(HttpRequest request, HttpContext context, IHeaders iheaders);
    }
}

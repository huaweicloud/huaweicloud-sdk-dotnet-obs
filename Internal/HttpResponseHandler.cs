
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace OBS.Internal
{
    internal interface HttpResponseHandler
    {
        void Handle(HttpResponse response);
    }

    internal class MergeResponseHeaderHandler : HttpResponseHandler
    {

        private IHeaders iheaders;

        public MergeResponseHeaderHandler(IHeaders iheaders)
        {
            this.iheaders = iheaders;
        }

        public void Handle(HttpResponse response)
        {
            if(response != null && response.HttpWebResponse != null)
            {
                WebHeaderCollection headers = response.HttpWebResponse.Headers;
                IDictionary<string, string> result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                int cnt = headers.Count;
                for (int i = 0; i < cnt; i++)
                {
                    string key = headers.Keys[i];
                    string value = headers.Get(key);
                    if(string.IsNullOrEmpty(key) || value == null)
                    {
                        continue;
                    }

                    if (key.StartsWith(this.iheaders.HeaderMetaPrefix(), StringComparison.OrdinalIgnoreCase))
                    {
                        key = CommonUtil.UrlDecode(key);
                    }

                    value = CommonUtil.UrlDecode(value);

                    if (result.ContainsKey(key))
                    {
                        string _value = result[key] + "," + value;
                        result[key] = _value;
                    }else
                    {
                        result.Add(key, value);
                    }
                }
                response.Headers = result;
            }
        }
    }
}

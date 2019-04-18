using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace OBS.Internal
{
    internal static class CommonParser
    {

        public static void ParseObsWebServiceResponse(HttpResponse httpResponse, ObsWebServiceResponse response, IHeaders iheaders)
        {
            response.StatusCode = httpResponse.StatusCode;
            if (httpResponse.Headers.ContainsKey(iheaders.RequestIdHeader()))
            {
                response.RequestId = httpResponse.Headers[iheaders.RequestIdHeader()];
            }
            if (httpResponse.Headers.ContainsKey(Constants.CommonHeaders.ContentLength))
            {
                response.ContentLength = Convert.ToInt64(httpResponse.Headers[Constants.CommonHeaders.ContentLength]);
            }

            foreach (KeyValuePair<string, string> header in httpResponse.Headers)
            {
                string key = header.Key;
                if (key.StartsWith(iheaders.HeaderMetaPrefix()))
                {
                    key = key.Substring(iheaders.HeaderMetaPrefix().Length);
                }
                else if (key.StartsWith(iheaders.HeaderPrefix()))
                {
                    key = key.Substring(iheaders.HeaderPrefix().Length);
                }else if (key.StartsWith(Constants.ObsHeaderMetaPrefix))
                {
                    key = key.Substring(Constants.ObsHeaderMetaPrefix.Length);
                }else if (key.StartsWith(Constants.ObsHeaderPrefix))
                {
                    key = key.Substring(Constants.ObsHeaderPrefix.Length);
                }
                response.Headers.Add(key, header.Value); 
            }            

        }

        public static void ParseErrorResponse(Stream stream, ObsException exception)
        {
            if (stream != null)
            {
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    while (reader.Read())
                    {
                        if ("Code".Equals(reader.Name))
                        {
                            exception.ErrorCode = reader.ReadString();
                        }
                        else if ("Message".Equals(reader.Name))
                        {
                            exception.ErrorMessage = reader.ReadString();
                        }
                        else if ("RequestId".Equals(reader.Name))
                        {
                            exception.RequestId = reader.ReadString();
                        }
                        else if ("HostId".Equals(reader.Name))
                        {
                            exception.HostId = reader.ReadString();
                        }
                    }
                }
            }
        }
    }
}

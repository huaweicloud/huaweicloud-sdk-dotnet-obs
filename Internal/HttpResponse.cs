using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace OBS.Internal
{
    internal class HttpResponse : IDisposable
    {

        private IDictionary<string, string> _headers;

        private HttpWebResponse _response;
        private HttpWebRequest _request;

        private bool _disposed;

        public HttpResponse(HttpWebResponse httpWebResponse)
        {
            this._response = httpWebResponse;
        }

        public HttpResponse(WebException failure, HttpWebRequest httpWebRequest)
        {
            HttpWebResponse httpWebResponse = failure.Response as HttpWebResponse;
            this.Failure = failure;
            this._response = httpWebResponse;
            this._request = httpWebRequest;
        }

        public HttpWebResponse HttpWebResponse
        {
            get
            {
                return this._response;
            }
        }

        public void Abort()
        {
            if(this._request != null)
            {
                this._request.Abort();
            }
        }

        public IDictionary<string, string> Headers
        {
            get { return _headers ?? (_headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)); }
            internal set
            {
                this._headers = value;
            }
        }

        public Stream Content
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(GetType().Name);
                }
                return (this._response != null) ? this._response.GetResponseStream() : null;
            }
        }

        public HttpStatusCode StatusCode {
            get
            {
                return this._response.StatusCode;
            }
        }

        public Exception Failure { get; set; }

        internal string RequestUrl
        {
            get;
            set;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }


            if (disposing)
            {
                if (_response != null)
                {
                    _response.Close();
                    _response = null;
                }
                if(_request != null)
                {
                    _request = null;
                }
                _disposed = true;
            }
        }
    }
}

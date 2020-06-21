using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Infrastructure.Requests
{
    public abstract class HttpRequest
    {
        protected HttpRequest(string url, List<KeyValuePair<string, string>> headers)
        {
            Headers = headers;
            Url = url;
        }

        public HttpMethod Method { get; set; }
        public string ContentType { get; set; }
        public string Url { get; set; }
        public List<KeyValuePair<string, string>> Headers { get; set; }
    }
}

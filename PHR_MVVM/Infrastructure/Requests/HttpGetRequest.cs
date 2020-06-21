using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Infrastructure.Requests
{
    public class HttpGetRequest : HttpRequest
    {
        public HttpGetRequest(string url, object queryParameters, List<KeyValuePair<string, string>> headers)
            : base(url, headers)
        {
            Method = HttpMethod.Get;
            QueryString = Serialization.ObjectToKeyValueString(queryParameters);

        }

        public string QueryString { get; set; }
    }
}

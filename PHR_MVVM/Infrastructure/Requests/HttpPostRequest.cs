using Infrastructure.Extensions;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Infrastructure.Requests
{
    public class HttpPostRequest : HttpRequest
    {
        public HttpPostRequest(string url, object body, List<KeyValuePair<string, string>> headers)
            : base(url, headers)
        {
            Method = HttpMethod.Post;


            ContentType = Enums.ContentType.Json.ToDescriptionString();
            Body = Serialization.ObjectToJsonString(body);
        }

        public string Body { get; set; }

    }
}

using Infrastructure.Enums;
using Infrastructure.Extensions;
using Infrastructure.Models;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Infrastructure.Requests
{
    public class HttpPostFileRequest : HttpRequest
    {
        public HttpPostFileRequest(string url, string contentName, object content, UploadFile[] files, List<KeyValuePair<string, string>> headers)
            : base(url, headers)
        {
            Method = HttpMethod.Post;
            ContentType = Enums.ContentType.Multipart.ToDescriptionString();
            Content = new StringContent(Serialization.ObjectToJsonString(content, CaseStrategy.CamelCase), Encoding.UTF8, Enums.ContentType.Json.ToDescriptionString());

            Files = files;
        }

        public UploadFile[] Files { get; set; }

        public StringContent Content { get; set; }
        public string ContentName { get; set; }
    }
}

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
        public HttpPostFileRequest(string url, object queryParameters, UploadFile file, List<KeyValuePair<string, string>> headers)
    : base(url, headers)
        {
            Method = HttpMethod.Post;
            ContentType = Enums.ContentType.Multipart.ToDescriptionString();
            QueryString = Serialization.ObjectToKeyValueString(queryParameters);

            File = file;

        }

        public UploadFile File { get; set; }

        public string QueryString { get; set; }

    }
}

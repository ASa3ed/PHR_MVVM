using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Infrastructure.Responses
{
    public class BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }
    }
}

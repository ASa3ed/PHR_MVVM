using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Infrastructure.Responses
{
    public class BaseResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Result { get; set; }
    }
}

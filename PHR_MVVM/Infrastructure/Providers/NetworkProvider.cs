using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using Infrastructure.Requests;
using Infrastructure.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Providers
{
    public class NetworkProvider : INetworkProvider
    {
        private int httpclientPoolSize = 10;
        private SemaphoreSlim semaphore;

        public NetworkProvider()
        {
            this.semaphore = new SemaphoreSlim(httpclientPoolSize);
        }
        public async Task<T> Get<T>(HttpGetRequest request)
        {
            var client = await GetHttpClient(request.Headers);
            //Add Control Fields To Request Headers

            var httpRequestMessage = new HttpRequestMessage(request.Method, $"{request.Url}" + (string.IsNullOrEmpty(request.QueryString) ? "" : $"?{request.QueryString}"));

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);


            var result = await ResolveHttpResponse<T>(httpResponseMessage, null);

            return result.Result;
        }

        private async Task<BaseResponse<T>> ResolveHttpResponse<T>(HttpResponseMessage httpResponseMessage, object p)
        {
            if (httpResponseMessage != null)
            {
                var dataAsString = await httpResponseMessage.Content.ReadAsStringAsync();
                if (httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
                {
                    return new BaseResponse<T> { StatusCode = HttpStatusCode.InternalServerError };
                }
                else if (httpResponseMessage.StatusCode != HttpStatusCode.ServiceUnavailable)
                {

                    return JsonConvert.DeserializeObject<BaseResponse<T>>(dataAsString);
                }
            }
            return new BaseResponse<T> { StatusCode = HttpStatusCode.BadRequest };

        }

        public async Task<T> Post<T>(HttpPostRequest request)
        {
            var client = await GetHttpClient(request.Headers);
            //Add Control Fields To Request Headers

            var httpRequestMessage = new HttpRequestMessage(request.Method, request.Url)
            {

                Content = new StringContent(request.Body)
            };
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);


            var result = await ResolveHttpResponse<T>(httpResponseMessage, null);
            return result.Result;
        }

        public async Task<T> Put<T>(HttpPutRequest request)
        {

            var client = await GetHttpClient(request.Headers);

            var httpRequestMessage = new HttpRequestMessage(request.Method, request.Url)
            {

                Content = new StringContent(request.Body)
            };
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);


            var result = await ResolveHttpResponse<T>(httpResponseMessage, null);
            return result.Result;
        }

        public async Task<T> Delete<T>(HttpDeleteRequest request)
        {
            var client = await GetHttpClient(request.Headers);
            //Add Control Fields To Request Headers
            request.Headers.ForEach(kv =>
            {
                client.DefaultRequestHeaders.Remove(kv.Key); // keep headers updated
                client.DefaultRequestHeaders.Add(kv.Key, kv.Value);
            });

            var httpRequestMessage = new HttpRequestMessage(request.Method, request.Url)
            {

                Content = new StringContent(request.Body)
            };
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);


            var result = await ResolveHttpResponse<T>(httpResponseMessage, null);
            return result.Result;
        }

        public async Task<T> PostMultimedia<T>(HttpPostFileRequest request)
        {
            var client = await GetHttpClient(request.Headers);


            var multipartForm = new MultipartFormDataContent();

            foreach (var file in request.Files)
                multipartForm.Add(file.Content, file.Name, file.FilePath);


            multipartForm.Add(request.Content, request.ContentName);
            var httpRequestMessage = new HttpRequestMessage(request.Method, $"{request.Url}")
            {

                Content = multipartForm
            };

            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);

            var result = await ResolveHttpResponse<T>(httpResponseMessage, null);

            return result.Result;
        }

        private async Task<HttpClient> GetHttpClient(List<KeyValuePair<string, string>> headers)
        {
            await this.semaphore.WaitAsync();

            var client = new HttpClient();

            if (headers != null)
                foreach (var header in headers)
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);

            return client;
        }

    }
}

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
        public async Task<T> Get<T>(HttpGetRequest request) where T : BaseResponse
        {
            var client = await GetHttpClient(request.Headers);
            //Add Control Fields To Request Headers
            request.Headers.ForEach(kv =>
            {
                client.DefaultRequestHeaders.Remove(kv.Key); // keep headers updated
                client.DefaultRequestHeaders.Add(kv.Key, kv.Value);
            });


            var httpRequestMessage = new HttpRequestMessage(request.Method, $"{request.Url}" + (string.IsNullOrEmpty(request.QueryString) ? "" : $"?{request.QueryString}"));

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);


            var result = await ResolveHttpResponse<T>(httpResponseMessage, null);

            return result;
        }

        private async Task<T> ResolveHttpResponse<T>(HttpResponseMessage httpResponseMessage, object p) where T : BaseResponse
        {
            if (httpResponseMessage != null)
            {
                var dataAsString = await httpResponseMessage.Content.ReadAsStringAsync();
                if (httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
                {
                    return (T)new BaseResponse { StatusCode = HttpStatusCode.InternalServerError };
                }
                else if (httpResponseMessage.StatusCode != HttpStatusCode.ServiceUnavailable)
                {

                    return JsonConvert.DeserializeObject<T>(dataAsString);
                }
            }
            return (T)new BaseResponse { StatusCode = HttpStatusCode.BadRequest };

        }

        public Task<T> Put<T>(HttpRequest request) where T : BaseResponse
        {
            throw new NotImplementedException();
        }


        public async Task<T> Post<T>(HttpPostRequest request) where T : BaseResponse
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
            return result;
        }

        public async Task<T> Put<T>(HttpPutRequest request) where T : BaseResponse
        {

            var client = await GetHttpClient(request.Headers);

            var httpRequestMessage = new HttpRequestMessage(request.Method, request.Url)
            {

                Content = new StringContent(request.Body)
            };
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);


            var result = await ResolveHttpResponse<T>(httpResponseMessage, null);
            return result;
        }

        public async Task<T> Delete<T>(HttpDeleteRequest request) where T : BaseResponse
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
            return result;
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

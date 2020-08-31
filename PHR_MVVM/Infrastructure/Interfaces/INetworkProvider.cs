using Infrastructure.Abstracts;
using Infrastructure.Requests;
using Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface INetworkProvider
    {
        /// <summary>
        /// Perform GET operation
        /// </summary>
        /// <typeparam name="T">Response object</typeparam>
        /// <typeparam name="L">Business object</typeparam>
        Task<T> Get<T>(HttpGetRequest request) where T : BaseResponse;
        /// <summary>
        /// Perform POST operation
        /// </summary>
        /// <typeparam name="T">Response object</typeparam>
        /// <typeparam name="L">Business object</typeparam>
        Task<T> Post<T>(HttpPostRequest request) where T : BaseResponse;
        /// <summary>
        /// Post binary files
        /// </summary>
        /// <typeparam name="T">Response object</typeparam>
        /// <param name="request">Buisness object</param>
        /// <returns></returns>
        Task<T> PostMultimedia<T>(HttpPostFileRequest request) where T : BaseResponse;
        /// <summary>
        /// Perform PUT operation
        /// </summary>
        /// <typeparam name="T">Response object</typeparam>
        /// <typeparam name="L">Business object</typeparam>
        Task<T> Put<T>(HttpPutRequest request) where T : BaseResponse;
        /// <summary>
        /// Perform DELETE operation
        /// </summary>
        /// <typeparam name="T">Response object</typeparam>
        /// <typeparam name="L">Business object</typeparam>
        Task<T> Delete<T>(HttpDeleteRequest request) where T : BaseResponse;

    }
}

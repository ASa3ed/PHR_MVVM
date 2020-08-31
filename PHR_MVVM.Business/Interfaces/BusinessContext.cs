using AutoMapper;
using CustomActions.Common.Config;
using Infrastructure.Interfaces;
using Infrastructure.Requests;
using Newtonsoft.Json;
using PHR_MVVM.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHR_MVVM.Business.Interfaces
{
    public abstract class BusinessContext
    {
        protected INetworkProvider NetworkProvider;
        protected IMapper Mapper;
        protected IStorageProvider StorageProvider;
        protected DomainURLModel BaseUrl { get; set; }
        protected BusinessContext(INetworkProvider networkProvider, IStorageProvider storageProvider, IMapper mapper)
        {
            NetworkProvider = networkProvider;
            Mapper = mapper;
            StorageProvider = storageProvider;
        }

        //ToDo: Move to sync page 
        private async Task<DomainURLModel> GetDomainsURL()
        {
            var response = await this.NetworkProvider.Get<DomainURLModel>(new HttpGetRequest(URI.GetDomainsURL, null, new List<KeyValuePair<string, string>>()));

            if (response != null)
            {
                await this.StorageProvider.SetItemAsync<DomainURLModel>(response);
            }
            return response;
        }

        protected async Task CheckDomainsURl()
        {
            var domainsurl = await this.StorageProvider.GetItemAsync<DomainURLModel>((x) => true);

            if (domainsurl == null)
            {
                domainsurl = await GetDomainsURL();
            }

            BaseUrl = domainsurl;
        }
    }
}

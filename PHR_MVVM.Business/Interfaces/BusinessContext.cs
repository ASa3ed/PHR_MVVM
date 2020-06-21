using AutoMapper;
using CustomActions.Common.Config;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHR_MVVM.Business.Interfaces
{
    public abstract class BusinessContext
    {
        protected INetworkProvider NetworkProvider;
        protected IMapper Mapper;
        protected IStorageProvider StorageProvider; 
        protected readonly string BaseUrl = URI.BaseURL;
        protected BusinessContext(INetworkProvider networkProvider, IStorageProvider storageProvider, IMapper mapper)
        {
            NetworkProvider = networkProvider;
            Mapper = mapper;
            StorageProvider = storageProvider;
        }
    }
}

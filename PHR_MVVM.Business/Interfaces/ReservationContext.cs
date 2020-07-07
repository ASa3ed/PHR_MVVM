using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHR_MVVM.Business.Interfaces
{
    public class ReservationContext : BusinessContext
    {
       
        public ReservationContext(INetworkProvider networkProvider, 
            IStorageProvider storageProvider, IMapper mapper) : 
            base(networkProvider, storageProvider, mapper)
        {
        }

        public object MyGetRequest(string parameter)
        {
            NetworkProvider.PostMultimedia()


        }

        
    }
}

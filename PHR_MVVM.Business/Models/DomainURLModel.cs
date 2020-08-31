using Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHR_MVVM.Business.Models
{
    public class DomainURLModel : OfflineDataModel
    {
        public string OnlineBookingBaseURL { get; set; }
        public string OpdBaseURL { get; set; }
        public string PaymentURL { get; set; }
        public string OnlineBookingUIDomain { get; set; }
    }
}

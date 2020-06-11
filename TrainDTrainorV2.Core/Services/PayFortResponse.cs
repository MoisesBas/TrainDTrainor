﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Services
{
    public class PayFortResponse
    {
        public string Command { get; set; }
        public string AccessCode { get; set; }
        public string MerchantIdentifier { get; set; }
        public string Merchant_reference { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string FortId { get; set; }
        public string Signature { get; set; }
        public string OrderDescription { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }
        public int Status { get; set; }
    }
}

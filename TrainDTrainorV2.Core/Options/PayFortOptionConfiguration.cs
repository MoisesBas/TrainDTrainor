using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Options
{
    public class PayFortOptionConfiguration
    {
        public int RESPONSE_GET_TOKEN { get; set; }
        public int RESPONSE_PURCHASE { get; set; }
        public int RESPONSE_PURCHASE_CANCEL { get; set; }
        public int RESPONSE_PURCHASE_SUCCESS { get; set; }
        public int RESPONSE_PURCHASE_FAILURE { get; set; }
        public string KEY_MERCHANT_IDENTIFIER { get; set; }
        public string KEY_SERVICE_COMMAND { get; set; }
        public string KEY_DEVICE_ID { get; set; }
        public string KEY_LANGUAGE { get; set; }
        public string KEY_ACCESS_CODE { get; set; }
        public string KEY_SIGNATURE { get; set; }
        public string AUTHORIZATION { get; set; }
        public string PURCHASE { get; set; }
        public string TEST_TOKEN_URL { get; set; }
        public string LIVE_TOKEN_URL { get; set; }
        public string SHA_TYPE { get; set; }
        public string CURRENCY_TYPE { get; set; }
        public string LANGUAGE_TYPE { get; set; }

    }
} 

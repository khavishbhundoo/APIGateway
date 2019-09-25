namespace APIGateway.Contracts
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BankResponseData
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("request")]
        public Request Request { get; set; }
    }

    public partial class Request
    {
        [JsonProperty("cardNo")]
        public string CardNo { get; set; }

        [JsonProperty("expiry")]
        public string Expiry { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("cvv")]
        public int Cvv { get; set; }
    }
}

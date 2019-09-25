namespace APIGateway.Contracts
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BankResponse
    {
        [JsonProperty("args")]
        public Args Args { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("files")]
        public Args Files { get; set; }

        [JsonProperty("form")]
        public Args Form { get; set; }

        [JsonProperty("headers")]
        public Headers Headers { get; set; }

        [JsonProperty("json")]
        public object Json { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Args
    {
    }

    public partial class Headers
    {
        [JsonProperty("Accept")]
        public string Accept { get; set; }

        [JsonProperty("Accept-Encoding")]
        public string AcceptEncoding { get; set; }

        [JsonProperty("Accept-Language")]
        public string AcceptLanguage { get; set; }

        [JsonProperty("Content-Length")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long ContentLength { get; set; }

        [JsonProperty("Dnt")]
       // [JsonConverter(typeof(ParseStringConverter))]
        public long Dnt { get; set; }

        [JsonProperty("Host")]
        public string Host { get; set; }

        [JsonProperty("Origin")]
        public Uri Origin { get; set; }

        [JsonProperty("Referer")]
        public Uri Referer { get; set; }

        [JsonProperty("Sec-Fetch-Mode")]
        public string SecFetchMode { get; set; }

        [JsonProperty("Sec-Fetch-Site")]
        public string SecFetchSite { get; set; }

        [JsonProperty("User-Agent")]
        public string UserAgent { get; set; }
    }
}

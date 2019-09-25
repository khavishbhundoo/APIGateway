using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace APIGateway.Utils
{
    public class ApiClient : IApiClient
    {

        static SocketsHttpHandler handler = new SocketsHttpHandler
        {
            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
            /*
             * Time to wait when trying to connect to a host similar to CURLOPT_CONNECTTIMEOUT in curl
             */
            ConnectTimeout = TimeSpan.FromSeconds(5)
        };
        static readonly HttpClient client = new HttpClient(handler)
        {
            /* 
             * This timeout is for the whole transfer
             */
            Timeout = TimeSpan.FromSeconds(30)
        };

        private async Task<string> GetURI(Uri url)
        {
            return await client.GetStringAsync(url);
        }

        private async Task<string> PostURI(Uri url, HttpContent content)
        {
            string result = null;

            HttpResponseMessage response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
           
            return result;
        }
        /// <summary>
        ///  Helper method to make Get requests and return output as string
        /// </summary>
        /// <exception cref="AggregateException">Thrown when exception(s) have occured in async request</exception>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url)
        {
            var t = Task.Run(() => GetURI(new Uri(url)));
            t.Wait();

            return  t.Result;
        }

        /// <summary>
        /// Helper method to make Get requests and return output as string
        /// </summary>
        /// <exception cref="AggregateException">Thrown when exception(s) have occured in async request</exception>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="content_type"></param>
        /// <returns></returns>
        public string Post(string url, string content, string content_type)
        {
            var t = Task.Run(() => PostURI(new Uri(url), new StringContent(content, Encoding.UTF8, content_type)));
            t.Wait();

            return t.Result;
        }

    }
}

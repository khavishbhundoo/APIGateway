using APIGateway.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APIGatewayTest
{
    class MockAPIClient : IApiClient
    {
        public string Get(string url)
        {
            
            return null;
        }

        public string Post(string url, string content, string content_type)
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "\\fileName.txt");
            string jsonData = File.ReadAllText(Directory.GetCurrentDirectory() + @"\bank_response.json");
            return jsonData;
        }

    }
}

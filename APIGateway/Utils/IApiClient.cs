using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Utils
{
    public interface IApiClient
    {
        string Get(string url);

        string Post(string url, string content, string content_type);

    }
}

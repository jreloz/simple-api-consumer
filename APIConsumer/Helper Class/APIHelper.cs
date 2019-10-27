using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace APIConsumer.Helper_Class
{
    class APIHelper
    {
        public APIHelper()
        {

        }

        public static HttpClient ApiClient { get; set; } = new HttpClient();

        public static void InitializedClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new Uri("http://xkcd.com/"); -> If one base address
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using APIConsumer.Model;
using APIConsumer.Helper_Class;
using Newtonsoft.Json;

namespace APIConsumer.Helper_Class
{
    public class APIProcessor
    {
        public int MaxComicNumber { get; set; }

        public static async Task<APIModel> LoadData(int DataNumber = 0)
        {
            string url = "";

            if (DataNumber > 0)
	        {
                url = $"https://xkcd.com/{DataNumber}/info.0.json";
            }
            else
            {
                url = $"https://xkcd.com/info.0.json";
            }

            using (HttpResponseMessage response  = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    APIModel comic = await response.Content.ReadAsAsync<APIModel>();
                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            
        }
    }
}

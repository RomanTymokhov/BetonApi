using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BetonApi.Extentions;

namespace BetonApi
{
    public class BetonClient
    {
        private readonly string baseUrl = "https://www.betonsuccess.ru";
        private readonly string urlSegment = "/capper/api/csv_post/";
        private readonly Dictionary<string, string> reqParams;

        private readonly HttpClient httpClient;


        public BetonClient(short sid, string key)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };

            reqParams = new Dictionary<string, string>
            {
                ["sid"] = sid.ToString(),
                ["key"] = key
            };
        }

        public async Task<string> SendPick(string content, byte email = 0, byte publish = 0)
        {
            reqParams.Add("email", email.ToString());
            reqParams.Add("publish", publish.ToString());

            var response = await httpClient.PostAsync(urlSegment.Build(reqParams),
                new StringContent(content, Encoding.ASCII, "application/x-www-form-urlencoded")).ConfigureAwait(false);

           return await Task.Factory.StartNew(() => response.Content.ReadAsStringAsync().Result);
        }
    }
}

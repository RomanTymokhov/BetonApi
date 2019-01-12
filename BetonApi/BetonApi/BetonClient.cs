using System;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using BetonApi.Extentions;

namespace BetonApi
{
    public class BetonClient
    {
        private readonly string apiMethod = "/capper/api/csv_post/";
        private readonly Dictionary<string, string> query;

        private readonly HttpClient httpClient;

        public BetonClient(uint sid, string key)
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://www.betonsuccess.ru") };

            query = new Dictionary<string, string>
            {
                ["sid"] = sid.ToString(),
                ["key"] = key
            };
        }

        public async Task<string> SendPick(string content, byte email = 1, byte publish = 1)
        {
            query["email"] = email.ToString();
            query["publish"] = publish.ToString();

            var response = await httpClient.PostAsync(apiMethod.Build(query),
                new StringContent(content, Encoding.GetEncoding("windows-1251"), "application/x-www-form-urlencoded")).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await Task.Run(() => response.Content.ReadAsStringAsync().Result);
        }
    }
}

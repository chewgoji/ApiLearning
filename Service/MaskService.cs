using ApiLearning.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiLearning.Service
{
    public class MaskService
    {
        public HttpClient Client { get; }

        public MaskService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://quality.data.gov.tw/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "QueryMask Sample");
            Client = client;
        }

        public async Task<IEnumerable<MaskInfo>> GetMaskInfo()
        {
            var response = await Client.GetAsync("dq_download_json.php?nid=116285&md5_url=53a72b2dcfdd9ecae43afda4b86089be");
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<MaskInfo>>(responseStream);
            return result;
        }
    }
}

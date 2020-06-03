using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Astor.JsonHttp
{
    public static class JsonHttpExtensions
    {
        public static Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string uri, object obj)
        {
            var body = new StringContent(JsonConvert.SerializeObject(obj));
            body.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            return client.PostAsync(uri, body);
        }
    }
}
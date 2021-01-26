using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VaccineInventory.Models;

namespace VaccineInventory.Handlers
{
    public class RequestHandler : IRequestHandler
    {
        private HttpClient Client { get; set; }
        public void Execute(string uri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            Client = client;  
        }

        public HttpResponseMessage GetAsync(string api)
        {
            return Client.GetAsync(api).Result;
        }

        public HttpResponseMessage InsertAsync<T>(string api, T model) where T : class
        {
            var json = JsonConvert.SerializeObject(model);
            return Client.PostAsync(api, new StringContent(json, Encoding.UTF8, "application/json")).Result;
        }

        public HttpResponseMessage DeleteAsync(string api)
        {
            return Client.DeleteAsync(api).Result;
        }

        public HttpResponseMessage UpdateAsync<T>(string api, T model) where T : class
        {
            var json = JsonConvert.SerializeObject(model);
            return Client.PutAsync(api, new StringContent(json, Encoding.UTF8, "application/json")).Result;
        }

    }
}

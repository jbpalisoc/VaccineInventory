using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VaccineInventory.Models;

namespace VaccineInventory.Handlers
{
    public interface IRequestHandler
    {
        void Execute(string uri);
        HttpResponseMessage GetAsync(string api);
        HttpResponseMessage InsertAsync<T>(string api, T model) where T : class;
        HttpResponseMessage DeleteAsync(string api);
        HttpResponseMessage UpdateAsync<T>(string api, T model) where T : class;
    }
}

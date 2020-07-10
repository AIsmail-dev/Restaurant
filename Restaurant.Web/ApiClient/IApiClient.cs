using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Web
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string path);
        Task<List<T>> GetListAsync<T>(string path);
        Task<T> PostAsync<T>(string path, object model);
   }
}

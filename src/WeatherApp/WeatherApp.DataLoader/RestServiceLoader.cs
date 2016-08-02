using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.DataLoader
{
    public interface IRestServiceLoader<T>
    {
        Task<T> GetAsync(string uri, string endPoint);
    }

    public class RestServiceLoader<T> : IRestServiceLoader<T>
    {
        public async Task<T> GetAsync(string uri, string endPoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(endPoint);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }

                return default(T);
            }
        }
    }
}
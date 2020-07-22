using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{

    public class Api
    {
        public Api()
        {
            this.httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:44308/api/")
            };
            Console.WriteLine("Iniciando API...");
        }
        private HttpClient httpClient;

        public void SetToken(string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        public async Task<string> GetData(string endpoint)
        {
            System.Net.Http.HttpResponseMessage response = await httpClient.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostData(string data, string endpoint)
        {
            var stringContent = new StringContent(data, UnicodeEncoding.UTF8, "application/json");

            System.Net.Http.HttpResponseMessage response =
                    await httpClient.PostAsync(endpoint, stringContent);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}

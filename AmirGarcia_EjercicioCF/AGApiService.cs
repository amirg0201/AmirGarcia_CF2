using AmirGarcia_EjercicioCF.Models;
using System.Net.Http.Json;

namespace AmirGarcia_EjercicioCF
{
    public class AGApiService
    {
        private readonly HttpClient _httpClient;
        public AGApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Burger>> GetBurgersAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7241/api/Burgers");
            response.EnsureSuccessStatusCode();
            var burgers = await response.Content.ReadFromJsonAsync<List<Burger>>();
            return burgers;
        }
    }

}

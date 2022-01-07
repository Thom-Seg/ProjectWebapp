using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.Services
{
    public class SteamStoreService : ISteamStoreService
    {

        private readonly HttpClient _httpClient;

        public SteamStoreService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<GameDetails> GetGameDetails(string Identifier)
        {
            _httpClient.DefaultRequestHeaders.Range = new RangeHeaderValue(0, 1000);
            var Response = await _httpClient.GetAsync($"appdetails?appids={Identifier}");

            /*using (var stream = await Response.Content.ReadAsStreamAsync())
            {
                var bytes = new byte[1000];
                var bytesread = stream.Read(bytes, 0, bytes.Length);
                stream.Close();
            }*/
            Response.EnsureSuccessStatusCode();

            
            using var responseStream = await Response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetGameDetailsResult>(responseStream);

            GameDetails gameDetails;
            gameDetails = new GameDetails()
            {
                Name = responseObject.Response.data.name,
                ImageUrl = responseObject.Response.data.header_image,
                Rating = responseObject.Response.data.metacritic,
                Genres = responseObject.Response.data.genres,
                Developer = responseObject.Response.data.developers,
                Publisher = responseObject.Response.data.publishers,
                ReleaseDate = responseObject.Response.data.release_date,
                Description = responseObject.Response.data.short_description,
            };
            return gameDetails;
            

        }
    }
}

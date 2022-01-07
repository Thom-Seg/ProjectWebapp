using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Project.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Project.Services
{
    public class SteamService :ISteamService
    {
        private readonly HttpClient _httpClient;

        public SteamService(HttpClient httpclient) 
        {
            _httpClient = httpclient;
        }

        public async Task<IEnumerable<GameCard>> GetGames(string Identifier, string Key)
        {
            

            var Response = await _httpClient.GetAsync($"IPlayerService/GetOwnedGames/v1/?key={Key}&steamid={Identifier}&include_appinfo=true");

            Response.EnsureSuccessStatusCode();

            using var responseStream = await Response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetGamesResult>(responseStream);

            return responseObject?.response?.games.Select(i => new GameCard
            {
                Name = i.name,
                ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/" + i.appid + "/header.jpg?",
                appID = i.appid
            }) ;
        }
    }
}

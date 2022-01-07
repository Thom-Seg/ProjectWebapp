using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services
{
    public interface ISteamService
    {
        Task<IEnumerable<GameCard>> GetGames(string Identifier, string Key);
        
    }
}

using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services
{
    public interface ISteamStoreService
    {
        Task<GameDetails> GetGameDetails(string Identifier);
    }
}

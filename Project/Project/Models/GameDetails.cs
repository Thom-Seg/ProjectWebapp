using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class GameDetails
    {

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public Release_Date ReleaseDate { get; set; }

        public Genre[] Genres { get; set; }

        public string[] Developer { get; set; }

        public string[] Publisher { get; set; }

        public string Description { get; set; }

        public Metacritic Rating { get; set; }



    }
}

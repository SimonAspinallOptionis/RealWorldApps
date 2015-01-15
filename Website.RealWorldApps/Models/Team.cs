using System.Collections.Generic;

namespace Website.RealWorldApps.Models
{
    public class Team
    {
        public List<Game> Results { get; set; }
        public List<Fixture> Schedule { get; set; }
        public List<Coach> Coaches { get; set; }
        public List<Player> Players { get; set; }
        public string Name { get; set; }
    }
}
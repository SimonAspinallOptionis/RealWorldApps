using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.RealWorldApps.Models
{
    public class LeagueTableRow
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string LeagueName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int PointsFor { get; set; }
        public int PointsAgainst { get; set; }
        public int PointsDifference { get; set; }
        public int TeamPoints { get; set; }
    }
}
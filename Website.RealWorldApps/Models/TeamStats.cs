using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.RealWorldApps.Models
{
    public class TeamStats
    {
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int PointsFor { get; set; }
        public int PointsAgainst { get; set; }
        public int PointsDifference
        {
            get
            {
                return PointsFor - PointsAgainst;
            }
        }
        public int Points
        {
            get
            {
                return Wins * 3 + Losses;
            }
        }
    }
}
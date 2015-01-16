using System;

namespace Website.RealWorldApps.Models
{
    public class Fixture
    {
        private string _teamLogoUrl;

        public int Id { get; set; }
        public string OpponentName { get; set; }
        public string Organisation { get; set; }
        public DateTime TipOff { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string TownCity { get; set; }
        public string Postcode { get; set; }
        public string TeamName { get; set; }
        public string LeagueName { get; set; }
        public string TeamLogoUrl
        {
            get
            {
                if(string.IsNullOrEmpty(_teamLogoUrl))
                {
                    return "England_Basketball.jpg";
                }
                return "TeamLogos/" + _teamLogoUrl;
            }
            set
            {
                _teamLogoUrl = value;
            }
        }
    }
}
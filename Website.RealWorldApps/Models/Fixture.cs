using System;

namespace Website.RealWorldApps.Models
{
    public class Fixture
    {
        private string _teamLogoUrl;

        public string OpponentName { get; set; }
        public string Location { get; set; }
        public DateTime TipOff { get; set; }
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
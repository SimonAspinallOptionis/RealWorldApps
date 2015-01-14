using System;
namespace Website.RealWorldApps.Models
{
    public class Game
    {
        private string _imgName;
        private string _shotChartUrl;

        public string OpponentName { get; set; }
        public string Organisation { get; set; }
        public DateTime TipOff { get; set; }
        public string Location { get; set; }
        public int CheshireScore { get; set; }
        public int OpponentScore { get; set; }
        public bool WonGame { get; set; }
        public string GameStory { get; set; }
        public string BoxScoreHtml { get; set; }
        public string ShotChartUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_shotChartUrl))
                {
                    return "England_Basketball.jpg";
                }
                return "/ShotCharts/ShotChart_" + _shotChartUrl;
            }
            set
            {
                _shotChartUrl = value;
            }
        }
        public string ImgName
        {
            get
            {
                if (string.IsNullOrEmpty(_imgName))
                {
                    return "TeamLogos/" + Organisation + "_Basketball.jpg";
                }
                return "TeamLogos/" + _imgName;
            }
            set
            {
                _imgName = value;
            }
        }
    }
}
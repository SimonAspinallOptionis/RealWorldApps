using System;
namespace Website.RealWorldApps.Models
{
    public class Game
    {
        private string _imgName;
        private string _shotChartUrl;

        public string OpponentName { get; set; }
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
                    _shotChartUrl = "CheshireWire.jpg";
                }
                return _shotChartUrl;
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
                    _imgName = "CheshireWire.jpg";
                }
                return _imgName;
            }
            set
            {
                _imgName = value;
            }
        }
    }
}
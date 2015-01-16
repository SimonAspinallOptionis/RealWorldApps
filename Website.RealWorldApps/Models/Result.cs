using System;
namespace Website.RealWorldApps.Models
{
    public class Result
    {
        private string _imgName;

        public int Id { get; set; }
        public int CheshireScore { get; set; }
        public int OpponentScore { get; set; }
        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
        public string ImgName
        {
            get
            {
                if (string.IsNullOrEmpty(_imgName))
                {
                    return "England_Basketball.jpg";
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
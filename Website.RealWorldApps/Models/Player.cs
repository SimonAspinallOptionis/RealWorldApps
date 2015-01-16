namespace Website.RealWorldApps.Models
{
    public class Player
    {
        private string _imgName;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; }
        public string LeagueName { get; set; }
        public string ImgName
        {
            get
            {
                if(string.IsNullOrEmpty(_imgName))
                {
                    return "England_Basketball.jpg";
                }
                return "Players/" + _imgName;
            }
            set
            {
                _imgName = value;
            }
        }
    }
}
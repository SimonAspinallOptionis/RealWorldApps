namespace Website.RealWorldApps.Models
{
    public class Player
    {
        private string _imgName;

        public string Name { get; set; }
        public int JerseyNumber { get; set; }
        public string Position { get; set; }
        public string ImgName
        {
            get
            {
                if(string.IsNullOrEmpty(_imgName))
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
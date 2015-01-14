namespace Website.RealWorldApps.Models
{
    public class Coach
    {
        private string _imgName;

        public string Name { get; set; }
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
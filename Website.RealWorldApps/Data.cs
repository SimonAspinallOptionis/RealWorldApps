using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.RealWorldApps.Models;

namespace Website.RealWorldApps
{
    public class Data
    {
        public List<Player> Players { get; set; }
        public List<Coach> Coaches { get; set; }

        public Data()
        {
            Players = new List<Player>();
            Coaches = new List<Coach>();
            AddPlayers();
            AddCoaches();
        }

        private void AddPlayers()
        {
            Players.Add(new Player { Name = "Elliot Cochrane", JerseyNumber = 4, Position = "Guard", ImgName="CheshireWire.jpg" });
            Players.Add(new Player { Name = "Harvey Roberts", JerseyNumber = 5, Position = "Guard", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Finlay Williams", JerseyNumber = 6, Position = "Guard", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Alex Hawkins", JerseyNumber = 7, Position = "Forward", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Zak Williams", JerseyNumber = 8, Position = "Guard", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Lloyd Hollins", JerseyNumber = 9, Position = "Forward", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Adam Chedd", JerseyNumber = 10, Position = "Forward", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Rowan Ladd", JerseyNumber = 11, Position = "Forward", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Jacob Dobbins", JerseyNumber = 12, Position = "Guard", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Sean Mottram", JerseyNumber = 13, Position = "Forward", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Josh McGarven", JerseyNumber = 14, Position = "Forward", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Callum Settle", JerseyNumber = 15, Position = "Center", ImgName = "CheshireWire.jpg" });
            Players.Add(new Player { Name = "Nathan Dobbins", JerseyNumber = 23, Position = "Guard", ImgName = "CheshireWire.jpg" });
        }

        private void AddCoaches()
        {
            Coaches.Add(new Coach { Name = "Mike Halpin", Position = "Head Coach", ImgName = "CheshireWire.jpg" });
            Coaches.Add(new Coach { Name = "Kelly Hope", Position = "Assistant Coach", ImgName = "CheshireWire.jpg" });
            Coaches.Add(new Coach { Name = "Simon Aspinall", Position = "Assistant Coach", ImgName = "CheshireWire.jpg" });
        }
    }
}
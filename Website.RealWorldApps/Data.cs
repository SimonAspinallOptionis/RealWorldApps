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
        public List<Game> Games { get; set; }

        public Data()
        {
            Players = new List<Player>();
            Coaches = new List<Coach>();
            Games = new List<Game>();
            AddPlayers();
            AddCoaches();
            AddGames();
        }

        private void AddPlayers()
        {
            Players.Add(new Player { Name = "Elliot Cochrane", JerseyNumber = 4, Position = "Guard" });
            Players.Add(new Player { Name = "Harvey Roberts", JerseyNumber = 5, Position = "Guard" });
            Players.Add(new Player { Name = "Finlay Williams", JerseyNumber = 6, Position = "Guard" });
            Players.Add(new Player { Name = "Alex Hawkins", JerseyNumber = 7, Position = "Forward" });
            Players.Add(new Player { Name = "Zak Williams", JerseyNumber = 8, Position = "Guard" });
            Players.Add(new Player { Name = "Lloyd Hollins", JerseyNumber = 9, Position = "Forward" });
            Players.Add(new Player { Name = "Adam Chedd", JerseyNumber = 10, Position = "Forward" });
            Players.Add(new Player { Name = "Rowan Ladd", JerseyNumber = 11, Position = "Forward" });
            Players.Add(new Player { Name = "Jacob Dobbins", JerseyNumber = 12, Position = "Guard" });
            Players.Add(new Player { Name = "Sean Mottram", JerseyNumber = 13, Position = "Forward" });
            Players.Add(new Player { Name = "Josh McGarven", JerseyNumber = 14, Position = "Forward" });
            Players.Add(new Player { Name = "Callum Settle", JerseyNumber = 15, Position = "Center" });
            Players.Add(new Player { Name = "Nathan Dobbins", JerseyNumber = 23, Position = "Guard" });
        }

        private void AddCoaches()
        {
            Coaches.Add(new Coach { Name = "Mike Halpin", Position = "Head Coach" });
            Coaches.Add(new Coach { Name = "Kelly Hope", Position = "Assistant Coach" });
            Coaches.Add(new Coach { Name = "Simon Aspinall", Position = "Assistant Coach" });
        }

        private void AddGames()
        {
            Games.Add(new Game { OpponentName = "Childwall Academy", Location = "Priestley College, Warrington", TipOff = new DateTime(2015, 01, 10, 12, 00, 00), CheshireScore = 44, OpponentScore = 56, WonGame = false });
            Games.Add(new Game { OpponentName = "Manchester Magic I", Location = "Amaechi Centre, Manchester", TipOff = new DateTime(2014, 12, 21, 13, 00, 00), CheshireScore = 37, OpponentScore = 103, WonGame = false });
            Games.Add(new Game { OpponentName = "Manchester Magic II", Location = "Priestley College, Warrington", TipOff = new DateTime(2014, 12, 13, 14, 00, 00), CheshireScore = 64, OpponentScore = 51, WonGame = true, GameStory = "<div><div>Cheshire Wire White hosted Manchester Magic II. Having lost to Magic in their previous meeting by just three points, Wire were fired up and immediately put the pressure on the opposing side forcing multiple turnovers. Wire won the quarter 15-10.</div><br/><div>The next quarter saw Magic start to make a come back with some physical play causing Wire to give away unnecessary fouls. The quarter still showed promise for Wire and they didn't let their opponents too far out of their sight during the quarter. Wire lost the quarter 18-15.</div><br/><div>With Wire up at half time by just two points, Wire were determined not to let this one slip away from them and some terrific plays opened up their lead going into the final quarter. Wire won the quarter 18-10.</div><br/><div>Wire kept the pressure on during the final quarter not allowing any easy baskets and playing smart basketball. A few final turnovers by Magic would see Wire clinch the game for their third win of the season. Final score 64-51 to Wire.&nbsp;</div><br/><div>An outstanding individual performance by Elliot Cochrane who led the team in scoring with 21 points. Elliot also made 13 steals making this his second consecutive game with 10 or more steals, he also grabbed 8 rebounds during the contest. Finlay Williams did a tremendous job of controlling the offense and the pace of the game. Finlay helped out his team mates by dishing out 5 assists. Alex Hawkins' unselfish play to help out his team mates and tough defense didn't go unnoticed, setting some hard screens freeing up his team mates and boxing out taller players to prevent them from getting rebounds.</div></div>" });
            Games.Add(new Game { OpponentName = "Sheffield Junior Saints", Location = "All Saints High School, Sheffield", TipOff = new DateTime(2014, 12, 06, 12, 00, 00), CheshireScore = 48, OpponentScore = 75, WonGame = false });
            Games.Add(new Game { OpponentName = "Cheshire Wire Green", Location = "Ball Hall, Warrington", TipOff = new DateTime(2014, 11, 22, 14, 40, 00), CheshireScore = 60, OpponentScore = 31, WonGame = true, ShotChartUrl="CheshireWireGreen_1.jpg", BoxScoreHtml = "<tr><td >Elliot Cochrane</td><td  align='center'>5-16</td><td  align='center'>5-16</td><td  align='center'>0-0</td><td  align='center'>2-6</td><td  align='center'>3</td><td  align='center'>6</td><td  align='center'>9</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>6</td><td  align='center'>12</td></tr><tr><td >Harvey Roberts</td><td  align='center'>5-17</td><td  align='center'>5-17</td><td  align='center'>0-0</td><td  align='center'>1-2</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>-2</td><td  align='center'>11</td></tr><tr><td >Finley Williams</td><td  align='center'>0-6</td><td  align='center'>0-6</td><td  align='center'>0-0</td><td  align='center'>0-4</td><td  align='center'>3</td><td  align='center'>3</td><td  align='center'>6</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>-5</td><td  align='center'>0</td></tr><tr><td >Alex Hawkins</td><td  align='center'>0-2</td><td  align='center'>0-2</td><td  align='center'>0-0</td><td  align='center'>0-0</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>2</td><td  align='center'>0</td><td  align='center'>-2</td><td  align='center'>0</td></tr><tr><td >Nathan Dobbin</td><td  align='center'>1-3</td><td  align='center'>1-3</td><td  align='center'>0-0</td><td  align='center'>1-2</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>3</td></tr><tr><td >Lloyd Horne</td><td  align='center'>0-1</td><td  align='center'>0-1</td><td  align='center'>0-0</td><td  align='center'>1-2</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>2</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>-3</td><td  align='center'>1</td></tr><tr><td >Adam Chedd</td><td  align='center'>0-2</td><td  align='center'>0-2</td><td  align='center'>0-0</td><td  align='center'>0-0</td><td  align='center'>1</td><td  align='center'>1</td><td  align='center'>2</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>2</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td></tr><tr><td >Rowan Ladd</td><td  align='center'>3-7</td><td  align='center'>3-7</td><td  align='center'>0-0</td><td  align='center'>1-2</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>3</td><td  align='center'>7</td></tr><tr><td >Jacob Dobbin</td><td  align='center'>5-10</td><td  align='center'>5-10</td><td  align='center'>0-0</td><td  align='center'>0-4</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>2</td><td  align='center'>10</td></tr><tr><td >Sean Mottram</td><td  align='center'>0-5</td><td  align='center'>0-5</td><td  align='center'>0-0</td><td  align='center'>0-0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>-5</td><td  align='center'>0</td></tr><tr><td >Josh McGarven</td><td  align='center'>2-4</td><td  align='center'>2-4</td><td  align='center'>0-0</td><td  align='center'>0-0</td><td  align='center'>3</td><td  align='center'>3</td><td  align='center'>6</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>1</td><td  align='center'>0</td><td  align='center'>8</td><td  align='center'>4</td></tr><tr><td >Callum Settle</td><td  align='center'>5-13</td><td  align='center'>5-13</td><td  align='center'>0-0</td><td  align='center'>2-3</td><td  align='center'>5</td><td  align='center'>4</td><td  align='center'>9</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>5</td><td  align='center'>0</td><td  align='center'>2</td><td  align='center'>0</td><td  align='center'>7</td><td  align='center'>12</td></tr><tr><td >Totals</td><td  align='center'>26-86</td><td  align='center'>26-86</td><td  align='center'>0-0</td><td  align='center'>8-25</td><td  align='center'>17</td><td  align='center'>21</td><td  align='center'>38</td><td  align='center'>0</td><td  align='center'>0</td><td  align='center'>11</td><td  align='center'>0</td><td  align='center'>10</td><td  align='center'>0</td><td  align='center'>10</td><td  align='center'>60</td></tr><tr><td >&nbsp;</td><td  align='center'>30.2%</td><td  align='center'>30.2%</td><td  align='center'>0%</td><td  align='center'>32%</td><td>&nbsp;</td></tr>"});

        }
    }
}
using System.Web.Mvc;
using System.Collections.Generic;
using Website.RealWorldApps.Models;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;

namespace Website.RealWorldApps.Controllers
{
    public class TeamController : Controller
    {
        private List<Player> Roster { get; set; }
        private List<Coach> CoachingStaff { get; set; }

        public ActionResult Players()
        {
            Roster = new List<Player>();

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CheshireWireConnection"].ConnectionString);
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            var ds = GetRosterDataSet(cmd);

            MapOutRoster(ds);

            FillPlayers();

            return View();
        }

        public ActionResult Coaches()
        {
            CoachingStaff = new List<Coach>();

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CheshireWireConnection"].ConnectionString);
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            var ds = GetCoachingStaffDataSet(cmd);

            MapOutCoachingStaff(ds);

            FillCoaches();

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddPlayer()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddCoach()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPlayer(string league, string playerName, int playerNumber, string position, string imgUrl)
        {
            //Data = HomeController.Data;
            //Data.Leagues.Where(l => l.Name == league).ToList()[0].Teams[0].Players.Add(new Player { Name = playerName, Number = playerNumber, Position = position, ImgName = imgUrl });
            return RedirectToAction("Players");
        }

        [HttpPost]
        public ActionResult AddCoach(string league, string coachName, string position, string imgUrl)
        {
            //Data = HomeController.Data;
            //Data.Leagues.Where(l => l.Name == league).ToList()[0].Teams[0].Coaches.Add(new Coach { Name = coachName, Position = position, ImgName = imgUrl });
            return RedirectToAction("Coaches");
        }

        #region Get DataSets

        private DataSet GetCoachingStaffDataSet(SqlCommand cmd)
        {
            var ds = new DataSet();

            try
            {
                cmd.CommandText = "usp_GetAllCoaches";
                cmd.Connection.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            return ds;
        }

        private DataSet GetRosterDataSet(SqlCommand cmd)
        {
            var ds = new DataSet();
            try
            {
                cmd.CommandText = "usp_GetAllPlayers";
                cmd.Connection.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            return ds;
        }

        #endregion

        #region Mapping

        private void MapOutCoachingStaff(DataSet ds)
        {
            CoachingStaff.AddRange(ds.Tables[0].AsEnumerable()
                .Select(r => new Coach
                {
                    Id = r.Field<int>("Id"),
                    Name = r.Field<string>("Name"),
                    Position = r.Field<string>("Position"),
                    TeamName = r.Field<string>("TeamName"),
                    LeagueName = r.Field<string>("LeagueName"),
                    ImgName = r.Field<string>("ImgName")
                }).ToList());
        }

        private void MapOutRoster(DataSet ds)
        {
            Roster.AddRange(ds.Tables[0].AsEnumerable()
                .Select(r => new Player
                {
                    Id = r.Field<int>("Id"),
                    Name = r.Field<string>("Name"),
                    Number = r.Field<int>("Number"),
                    Position = r.Field<string>("Position"),
                    TeamName = r.Field<string>("TeamName"),
                    LeagueName = r.Field<string>("LeagueName"),
                    ImgName = r.Field<string>("ImgName")
                }).ToList());
        }

        #endregion

        #region Fill ViewBag

        private void FillCoaches()
        {
            ViewBag.Under13WhiteCoaches = CoachingStaff.Where(c => c.TeamName == "White" && c.LeagueName == "Under 13");
            ViewBag.Under13GreenCoaches = CoachingStaff.Where(c => c.TeamName == "Green" && c.LeagueName == "Under 13");
            ViewBag.Under14Coaches = CoachingStaff.Where(c => c.LeagueName == "Under 14");
            ViewBag.Under15Coaches = CoachingStaff.Where(c => c.LeagueName == "Under 15");
            ViewBag.Under16CCoaches = CoachingStaff.Where(c => c.TeamName == "Conference" && c.LeagueName == "Under 16");
            ViewBag.Under16PCoaches = CoachingStaff.Where(c => c.TeamName == "Premier" && c.LeagueName == "Under 16");
            ViewBag.Under18CCoaches = CoachingStaff.Where(c => c.TeamName == "Conference" && c.LeagueName == "Under 18");
            ViewBag.Under18PCoaches = CoachingStaff.Where(c => c.TeamName == "Premier" && c.LeagueName == "Under 18");

        }

        private void FillPlayers()
        {
            ViewBag.Under13WhiteRoster = Roster.Where(p => p.TeamName == "White" && p.LeagueName == "Under 13").OrderBy(p => p.Number);
            ViewBag.Under13GreenRoster = Roster.Where(p => p.TeamName == "Green" && p.LeagueName == "Under 13").OrderBy(p => p.Number);
            ViewBag.Under14Roster = Roster.Where(p => p.LeagueName == "Under 14").OrderBy(p => p.Number);
            ViewBag.Under15Roster = Roster.Where(p => p.LeagueName == "Under 15").OrderBy(p => p.Number);
            ViewBag.Under16CRoster = Roster.Where(p => p.TeamName == "Conference" && p.LeagueName == "Under 16").OrderBy(p => p.Number);
            ViewBag.Under16PRoster = Roster.Where(p => p.TeamName == "Premier" && p.LeagueName == "Under 16").OrderBy(p => p.Number);
            ViewBag.Under18CRoster = Roster.Where(p => p.TeamName == "Conference" && p.LeagueName == "Under 18").OrderBy(p => p.Number);
            ViewBag.Under18PRoster = Roster.Where(p => p.TeamName == "Premier" && p.LeagueName == "Under 18").OrderBy(p => p.Number);
        }

        #endregion
    }
}

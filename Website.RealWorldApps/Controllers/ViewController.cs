using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.RealWorldApps.Models;

namespace Website.RealWorldApps.Controllers
{
    public class ViewController : Controller
    {
        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View();
        }

        public ActionResult LeagueTable()
        {
            FillLeagueTables();
            return View();
        }

        private List<LeagueTableRow> UploadLeagueTableCsv(string filePath)
        {
            var lines = System.IO.File.ReadAllLines(filePath);
            var leagueTable = new List<LeagueTableRow>();
            leagueTable.AddRange(lines.Select(l => new LeagueTableRow
            {
                TeamName = l.Split(',')[0],
                Wins = int.Parse(l.Split(',')[1]),
                Losses = int.Parse(l.Split(',')[2]),
                PointsFor = int.Parse(l.Split(',')[5]),
                PointsAgainst = int.Parse(l.Split(',')[6]),
                PointsDifference = int.Parse(l.Split(',')[7]),
                TeamPoints = int.Parse(l.Split(',')[8])
            }));
            return leagueTable;
        }

        #region Fill

        private void FillLeagueTables()
        {
            ViewBag.Under13LeagueTable = UploadLeagueTableCsv(Server.MapPath("~/Content/LeagueTables/LeagueTable_Under 13.csv")).OrderByDescending(r => r.TeamPoints).ThenByDescending(r => r.PointsDifference).ThenByDescending(r => r.PointsFor).ToList();
            ViewBag.Under14LeagueTable = UploadLeagueTableCsv(Server.MapPath("~/Content/LeagueTables/LeagueTable_Under 14.csv")).OrderByDescending(r => r.TeamPoints).ThenByDescending(r => r.PointsDifference).ThenByDescending(r => r.PointsFor).ToList();
            ViewBag.Under15LeagueTable = UploadLeagueTableCsv(Server.MapPath("~/Content/LeagueTables/LeagueTable_Under 15.csv")).OrderByDescending(r => r.TeamPoints).ThenByDescending(r => r.PointsDifference).ThenByDescending(r => r.PointsFor).ToList();
            ViewBag.Under16CLeagueTable = UploadLeagueTableCsv(Server.MapPath("~/Content/LeagueTables/LeagueTable_Under 16C.csv")).OrderByDescending(r => r.TeamPoints).ThenByDescending(r => r.PointsDifference).ThenByDescending(r => r.PointsFor).ToList();
            ViewBag.Under16PLeagueTable = UploadLeagueTableCsv(Server.MapPath("~/Content/LeagueTables/LeagueTable_Under 16P.csv")).OrderByDescending(r => r.TeamPoints).ThenByDescending(r => r.PointsDifference).ThenByDescending(r => r.PointsFor).ToList();
            ViewBag.Under18CLeagueTable = UploadLeagueTableCsv(Server.MapPath("~/Content/LeagueTables/LeagueTable_Under 18C.csv")).OrderByDescending(r => r.TeamPoints).ThenByDescending(r => r.PointsDifference).ThenByDescending(r => r.PointsFor).ToList();
            ViewBag.Under18PLeagueTable = UploadLeagueTableCsv(Server.MapPath("~/Content/LeagueTables/LeagueTable_Under 18P.csv")).OrderByDescending(r => r.TeamPoints).ThenByDescending(r => r.PointsDifference).ThenByDescending(r => r.PointsFor).ToList();
        }

        #endregion
    }
}

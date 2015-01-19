using System.Web.Mvc;
using System.Collections.Generic;
using Website.RealWorldApps.Models;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Website.RealWorldApps.Controllers
{
    public class HomeController : Controller
    {
        private List<Fixture> NextFixtures { get; set; }
        private List<Result> PreviousResults { get; set; }
        private List<Story> News { get; set; }

        public ActionResult Home()
        {

            NextFixtures = new List<Fixture>();
            PreviousResults = new List<Result>();
            News = new List<Story>();

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CheshireWireConnection"].ConnectionString);
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            GetFixtures(cmd);

            GetResults(cmd);

            GetNews(cmd);

            return View();
        }

        private void GetResults(SqlCommand cmd)
        {
            var ds = GetResultsDataSet(cmd);

            MapOutResults(ds);

            FillResults();
        }

        private void GetNews(SqlCommand cmd)
        {
            var ds = GetNewsDataSet(cmd);

            MapOutNews(ds);

            FillNews();
        }

        private void GetFixtures(SqlCommand cmd)
        {
            var ds = GetFixtureDataSet(cmd);

            MapOutFixtures(ds);

            FillFixtures();
        }

        #region GetDataSets

        private DataSet GetResultsDataSet(SqlCommand cmd)
        {
            var ds = new DataSet();
            try
            {
                cmd.CommandText = GetSprocName("Results");
                cmd.Connection.Open();
                var da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if(cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }

            return ds;
        }

        private DataSet GetNewsDataSet(SqlCommand cmd)
        {
            var ds = new DataSet();
            try
            {
                cmd.CommandText = "usp_GetNews";
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

        private DataSet GetFixtureDataSet(SqlCommand cmd)
        {
            var ds = new DataSet();
            try
            {
                cmd.CommandText = GetSprocName("Fixtures");
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

        private void MapOutNews(DataSet ds)
        {
            News.AddRange(ds.Tables[0].AsEnumerable()
                .Select(r => new Story
                {
                    Id = r.Field<int>("Id"),
                    Headline = r.Field<string>("Headline"),
                    Body = r.Field<string>("Body")
                }).ToList());
        }

        private void MapOutResults(DataSet ds)
        {
            PreviousResults.AddRange(ds.Tables[0].AsEnumerable()
                .Select(r => new Result
                {
                    Id = r.Field<int>("Id"),
                    CheshireScore = r.Field<int>("CheshireScore"),
                    OpponentScore = r.Field<int>("OpponentScore"),
                    Fixture = GetFixtureById(r.Field<int>("FixtureId"))
                }).ToList());
        }

        private Fixture GetFixtureById(int fixtureId)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CheshireWireConnection"].ConnectionString);
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            var ds = new DataSet();

            try
            {
                cmd.CommandText = "usp_GetFixtureById";
                cmd.Parameters.Add(new SqlParameter("@id", fixtureId));
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

            var fixture = ds.Tables[0].AsEnumerable()
                .Select(r => new Fixture
                {
                    Id = r.Field<int>("Id"),
                    OpponentName = r.Field<string>("OpponentName"),
                    Organisation = r.Field<string>("Organisation"),
                    TipOff = r.Field<DateTime>("TipOff"),
                    AddressLine1 = r.Field<string>("AddressLine1"),
                    AddressLine2 = r.Field<string>("AddressLine2"),
                    TownCity = r.Field<string>("TownCity"),
                    Postcode = r.Field<string>("Postcode"),
                    TeamName = r.Field<string>("TeamName"),
                    LeagueName = r.Field<string>("LeagueName"),
                    TeamLogoUrl = r.Field<string>("ImgName")
                }).ToList()[0];

            return fixture;
        }


        private void MapOutFixtures(DataSet ds)
        {
            NextFixtures.AddRange(ds.Tables[0].AsEnumerable()
                .OrderBy(r => r.Field<DateTime>("TipOff"))
                .Select(r => new Fixture
                {
                    Id = r.Field<int>("Id"),
                    OpponentName = r.Field<string>("OpponentName"),
                    Organisation = r.Field<string>("Organisation"),
                    TipOff = r.Field<DateTime>("TipOff"),
                    AddressLine1 = r.Field<string>("AddressLine1"),
                    AddressLine2 = r.Field<string>("AddressLine2"),
                    TownCity = r.Field<string>("TownCity"),
                    Postcode = r.Field<string>("Postcode"),
                    TeamName = r.Field<string>("TeamName"),
                    LeagueName = r.Field<string>("LeagueName")
                }).ToList());
        }

        #endregion

        #region Fill ViewBag

        private void FillResults()
        {
            ViewBag.Under13WhiteResult = PreviousResults.First(r => r.Fixture.LeagueName == "Under 13" && r.Fixture.TeamName == "White");
            ViewBag.Under13GreenResult = PreviousResults.First(r => r.Fixture.LeagueName == "Under 13" && r.Fixture.TeamName == "Green");
            ViewBag.Under14Result = PreviousResults.First(r => r.Fixture.LeagueName == "Under 14");
            ViewBag.Under15Result = PreviousResults.First(r => r.Fixture.LeagueName == "Under 15");
            ViewBag.Under16CResult = PreviousResults.First(r => r.Fixture.LeagueName == "Under 16" && r.Fixture.TeamName == "Conference");
            ViewBag.Under16PResult = PreviousResults.First(r => r.Fixture.LeagueName == "Under 16" && r.Fixture.TeamName == "Premier");
            ViewBag.Under18CResult = PreviousResults.First(r => r.Fixture.LeagueName == "Under 18" && r.Fixture.TeamName == "Conference");
            ViewBag.Under18PResult = PreviousResults.First(r => r.Fixture.LeagueName == "Under 18" && r.Fixture.TeamName == "Premier");

        }

        private void FillFixtures()
        {
            ViewBag.Under13WhiteFixture = NextFixtures.First(f => f.LeagueName == "Under 13" && f.TeamName == "White");
            ViewBag.Under13GreenFixture = NextFixtures.First(f => f.LeagueName == "Under 13" && f.TeamName == "Green");
            ViewBag.Under14Fixture = NextFixtures.First(f => f.LeagueName == "Under 14");
            ViewBag.Under15Fixture = NextFixtures.First(f => f.LeagueName == "Under 15");
            ViewBag.Under16CFixture = NextFixtures.First(f => f.LeagueName == "Under 16" && f.TeamName == "Conference");
            ViewBag.Under16PFixture = NextFixtures.First(f => f.LeagueName == "Under 16" && f.TeamName == "Premier");
            ViewBag.Under18CFixture = NextFixtures.First(f => f.LeagueName == "Under 18" && f.TeamName == "Conference");
            ViewBag.Under18PFixture = NextFixtures.First(f => f.LeagueName == "Under 18" && f.TeamName == "Premier");
        }

        private void FillNews()
        {
            ViewBag.NewsCollection = News;
        }

        #endregion


        private string GetSprocName(string type)
        {
            switch (type)
            {
                case "Fixtures":
                    return "usp_GetFixtures";
                case "Results":
                    return "usp_GetResults";
                default:
                    return string.Empty;
            }
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}

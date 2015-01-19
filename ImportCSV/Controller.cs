using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.RealWorldApps.Models;

namespace ImportCSV
{
    public class Controller
    {
        private List<Fixture> Fixtures { get; set; }
        private List<Result> Results { get; set; }
        private string Path { get; set; }

        public void UploadFixtureCsv()
        {
            Fixtures = new List<Fixture>();
            Path = string.Format(@"C:\Temp\dev\simon\github\realworldapps\realworldapps\website.realworldapps\content\fixtures\fixtures_{0}.csv", Console.ReadLine());
            var reader = new StreamReader(Path);

            while (!reader.EndOfStream)
            {
                var fixture = new Fixture();
                var line = reader.ReadLine();
                var values = line.Split(',');

                fixture.TipOff = DateTime.Parse(values[0]);
                fixture.AddressLine1 = values[3];

                if (values[1].Contains("Cheshire Wire"))
                {
                    fixture.Organisation = values[2].Split(' ')[0].Trim(); ;
                    if (values[2].Split(' ').Length > 1)
                        fixture.OpponentName = values[2].Substring(values[2].IndexOf(' ')).Trim();
                }
                else
                {
                    fixture.Organisation = values[1].Split(' ')[0].Trim();
                    if (values[1].Split(' ').Length > 1)
                        fixture.OpponentName = values[1].Substring(values[1].IndexOf(' ')).Trim();
                }

                if (!string.IsNullOrEmpty(fixture.OpponentName))
                    if (fixture.OpponentName.Contains("White"))
                    {
                        fixture.Organisation = "Cheshire Wire";
                        fixture.OpponentName = "White";
                    }

                fixture.AddressLine1 = values[3];

                if (fixture.AddressLine1.Contains("Warrington") || fixture.AddressLine1.Contains("Culcheth") || fixture.AddressLine1.Contains("Priestley"))
                {
                    fixture.TownCity = "Warrington";
                }
                else
                {
                    fixture.TownCity = fixture.Organisation;
                }

                if(Path.Contains("under14"))
                {
                    fixture.TeamName = "";
                    fixture.LeagueName = "Under 14";
                }
                if(Path.Contains("under15"))
                {
                    fixture.TeamName = "";
                    fixture.LeagueName = "Under 15";
                }
                if(Path.Contains("under16C"))
                {
                    fixture.TeamName = "Conference";
                    fixture.LeagueName = "Under 16";
                }
                if(Path.Contains("under16P"))
                {
                    fixture.TeamName = "Premier";
                    fixture.LeagueName = "Under 16";
                }
                if(Path.Contains("under18C"))
                {
                    fixture.TeamName = "Conference";
                    fixture.LeagueName = "Under 18";
                }
                if(Path.Contains("under18P"))
                {
                    fixture.TeamName = "Premier";
                    fixture.LeagueName = "Under 18";
                }

                Fixtures.Add(fixture);
            }
        }

        public void WriteFixturesToDb()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CheshireWireConnection"].ConnectionString);
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.CommandText = "usp_AddFixture";

            foreach (var fixture in Fixtures)
            {
                if (string.IsNullOrEmpty(fixture.OpponentName))
                    fixture.OpponentName = "";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@opponentName", fixture.OpponentName);
                cmd.Parameters.AddWithValue("@organisation", fixture.Organisation);
                cmd.Parameters.AddWithValue("@tipOff", fixture.TipOff);
                cmd.Parameters.AddWithValue("@AddressLine1", fixture.AddressLine1);
                cmd.Parameters.AddWithValue("@TownCity", fixture.TownCity);
                cmd.Parameters.AddWithValue("@teamName", fixture.TeamName);
                cmd.Parameters.AddWithValue("@leagueName", fixture.LeagueName);
                cmd.Parameters.AddWithValue("@imgName", fixture.Organisation.Replace(" ", string.Empty) + "_Basketball.jpg");

                var ds = new DataSet();
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
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
            }

        }

        public void UploadResultsCsv()
        {
            Results = new List<Result>();
            Path = string.Format(@"C:\Temp\dev\simon\github\realworldapps\realworldapps\website.realworldapps\content\results\results_{0}.csv", Console.ReadLine());
            var reader = new StreamReader(Path);

            while (!reader.EndOfStream)
            {
                var result = new Result();
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values[1].Contains("Cheshire Wire"))
                {
                    result.Fixture = GetFixtureByTipoffAndOpponent(DateTime.Parse(values[0]), values[4].Substring(values[4].IndexOf(' ')).Trim());
                    result.CheshireScore = int.Parse(values[2]);
                    result.OpponentScore = int.Parse(values[3]);
                }
                else
                {
                    result.Fixture = GetFixtureByTipoffAndOpponent(DateTime.Parse(values[0]), values[1].Substring(values[1].IndexOf(' ')).Trim());
                    result.CheshireScore = int.Parse(values[3]);
                    result.OpponentScore = int.Parse(values[2]);
                }

                Results.Add(result);
            }
        }

        public void WriteResultsToDb()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CheshireWireConnection"].ConnectionString);
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.CommandText = "usp_AddResult";

            foreach (var result in Results)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cheshireScore", result.CheshireScore);
                cmd.Parameters.AddWithValue("@opponentScore", result.OpponentScore);
                cmd.Parameters.AddWithValue("@opponentName", result.Fixture.OpponentName);
                cmd.Parameters.AddWithValue("@tipOff", result.Fixture.TipOff);
                cmd.Parameters.AddWithValue("@leagueName", "Under 13");

                var ds = new DataSet();
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
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
            }
        }

        public Fixture GetFixtureByTipoffAndOpponent(DateTime tipOff, string opponent)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CheshireWireConnection"].ConnectionString);
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            if (opponent.Contains("Wire White"))
            {
                opponent = "White";
            }

            cmd.CommandText = "usp_GetFixtureByTipOffAndOpponent";
            cmd.Parameters.AddWithValue("@tipOff", tipOff);
            cmd.Parameters.AddWithValue("@opponent", opponent);

            var ds = new DataSet();
            try
            {
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
    }
}

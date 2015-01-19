using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller();

            while (Console.ReadLine().ToLower() != "end")
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "fixtures":
                        controller.UploadFixtureCsv();
                        controller.WriteFixturesToDb();
                        break;
                    case "results":
                        controller.UploadResultsCsv();
                        controller.WriteResultsToDb();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized...");
            
            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("No lines returned");
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("Only 1 line returned");
            }
            
            logger.LogInfo($"Lines: {lines[0]}");
            
            var parser = new TacoParser();
            
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tacoBellOne = null;
            ITrackable tacoBellTwo = null;
            double distance = 0;
            
            
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for (int r = 0; r < locations.Length; r++)
                {
                    var locB = locations[r];
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBellOne = locA;
                        tacoBellTwo = locB;
                    }
                }
                
            }
            logger.LogInfo($"{tacoBellOne.Name} and {tacoBellTwo.Name} are the greatest distance from eachother!");
        }
    }
}

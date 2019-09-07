using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TheStarsAlign
{
    class Program
    {
        static void Main(string[] args)
        {
            //parsing data, assumes file is always in the same format and string lengths
            List<Point> points = new List<Point>();
            var dataLines = File.ReadAllText(@"DataPoints.txt").Trim().Split('\n');

            foreach (string line in dataLines)
            {
                var x = int.Parse(line.Substring(10, 6));
                var y = int.Parse(line.Substring(18, 6));
                var xv = int.Parse(line.Substring(36, 2));
                var yv = int.Parse(line.Substring(40, 2));

                points.Add(new Point()
                {
                    X_Position = x,
                    Y_Position = y,
                    X_Velocity = xv,
                    Y_Velocity = yv
                });
            }

            var mapWidth = Int32.MaxValue;
            var mapHeight = Int32.MaxValue;
            var found = false;
            var correct = "n";

            while (found == false)
            {
                foreach (var point in points)
                {
                    point.FastForward();
                }

                //calculate new map size
                int xMin = points.Min(s => s.X_Position);
                int xMax = points.Max(s => s.X_Position);
                int yMin = points.Min(s => s.Y_Position);
                int yMax = points.Max(s => s.Y_Position);

                int width = xMax - xMin;
                int height = yMax - yMin;

                //assumes points are close together for message to appear
                if (mapWidth <= 100 && mapHeight <= 50)
                {
                    //possible map so generate it and display it                 
                    Console.WriteLine("New Map");
                    StringBuilder map = new StringBuilder();
                    for (int y = yMin; y <= yMax; y++)
                    {
                        for (int x = xMin; x <= xMax; x++)
                        {
                            map.Append(points.Any(p => p.pointExists(x, y)) ? "#" : ".");
                        }

                        map.AppendLine();
                    }
                    Console.WriteLine(map);
                    Console.WriteLine("correct map? ");
                    correct = Console.ReadLine();
                    if(correct == "y")
                    {
                        found = true;
                    }
 
                }

                //set the current map size
                mapWidth = width;
                mapHeight = height;
            }
            Console.ReadLine();
        }
    }
}   
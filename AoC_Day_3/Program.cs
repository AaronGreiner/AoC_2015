using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace AoC_Day_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"../../input.txt");
            char[] array = input.ToCharArray();
            int x = 0;
            int y = 0;

            List<Point> locations = new List<Point>();
            locations.Add(new Point(x, y));
            List<Point> delivered_houses = new List<Point>();
            delivered_houses.Add(new Point(x, y));

            foreach (char i in array)
            {
                switch (i)
                {
                    case '^':
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                    case '>':
                        x++;
                        break;
                    case '<':
                        x--;
                        break;
                }

                Point p = new Point(x, y);

                locations.Add(p);

                if (!delivered_houses.Contains(p))
                {
                    delivered_houses.Add(p);
                }
            }

            Console.WriteLine("Houses with At Least One Present: " + delivered_houses.Count);

            Console.ReadLine();
        }
    }
}

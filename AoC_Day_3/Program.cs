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
            Point loc = new Point(0, 0);
            
            List<Point> delivered_houses = new List<Point>();
            delivered_houses.Add(loc);

            bool santas_turn = true;
            Point loc_santa = new Point(0, 0);
            Point loc_robo = new Point(0, 0);
            Point loc_current = new Point(0, 0);
            List<Point> delivered_houses_bonus = new List<Point>();
            delivered_houses_bonus.Add(loc_current);

            foreach (char i in array)
            {
                loc_current = santas_turn ? loc_santa : loc_robo;

                switch (i)
                {
                    case '^':
                        loc.Y++;
                        loc_current.Y++;
                        break;
                    case 'v':
                        loc.Y--;
                        loc_current.Y--;
                        break;
                    case '>':
                        loc.X++;
                        loc_current.X++;
                        break;
                    case '<':
                        loc.X--;
                        loc_current.X--;
                        break;
                }

                if (!delivered_houses.Contains(loc))
                {
                    delivered_houses.Add(loc);
                }

                if (!delivered_houses_bonus.Contains(loc_current))
                {
                    delivered_houses_bonus.Add(loc_current);
                }

                if (santas_turn)
                {
                    loc_santa = loc_current;
                } else
                {
                    loc_robo = loc_current;
                }
                santas_turn = !santas_turn;
            }

            Console.WriteLine("Houses with At Least One Present: " + delivered_houses.Count);
            Console.WriteLine("Houses with At Least One Present (Robo): " + delivered_houses_bonus.Count);

            Console.ReadLine();
        }
    }
}

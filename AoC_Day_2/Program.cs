using System;
using System.IO;
using System.Linq;

namespace AoC_Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");
            int total_square_feet_wrapping_paper = 0;
            int total_length_ribbon = 0;

            foreach (string item in input)
            {
                string[] dim = item.Split('x');

                total_square_feet_wrapping_paper += GetSqareFeetWrappingPaperNeeded(Int32.Parse(dim[0]), Int32.Parse(dim[1]), Int32.Parse(dim[2]));
                total_length_ribbon += GetLengthRibbonNeeded(Int32.Parse(dim[0]), Int32.Parse(dim[1]), Int32.Parse(dim[2]));
            }

            Console.WriteLine("Total Square Feet Wrapping Paper: " + total_square_feet_wrapping_paper);
            Console.WriteLine("Total Length Ribbon: " + total_length_ribbon);
            Console.ReadLine();
        }

        private static int GetSqareFeetWrappingPaperNeeded(int l, int w, int h)
        {
            int area_1 = l * w;
            int area_2 = w * h;
            int area_3 = h * l;

            int slack = new int[] { area_1, area_2, area_3 }.Min();

            int total = 2 * area_1 + 2 * area_2 + 2 * area_3 + slack;

            return total;
        }

        private static int GetLengthRibbonNeeded(int l, int w, int h)
        {
            int[] sides = new int[] { l, w, h };
            int remove = sides.Max();
            int remove_index = Array.IndexOf(sides, remove);
            sides = sides.Where((val, idx) => idx != remove_index).ToArray();

            int length = 2 * sides[0] + 2 * sides[1];
            int length_bow = l * w * h;

            return length + length_bow;
        }
    }
}

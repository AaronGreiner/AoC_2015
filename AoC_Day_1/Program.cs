using System;
using System.IO;

namespace AoC_Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"../../input.txt");
            char[] array = input.ToCharArray();
            int floor = 0;
            bool first_basement = false;
            int count_steps = 0;

            foreach (char i in array)
            {
                count_steps++;

                switch (i)
                {
                    case '(':
                        floor++;
                        break;
                    case ')':
                        floor--;
                        break;
                }

                if (!first_basement && floor < 0)
                {
                    first_basement = true;
                    Console.WriteLine("First Basement: " + count_steps);
                }
            }

            Console.WriteLine("End Floor: " + floor);
            Console.ReadLine();
        }
    }
}

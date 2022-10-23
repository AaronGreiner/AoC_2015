using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC_Day_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../input.txt");
            int count_nice_strings = 0;
            int count_nicer_strings = 0;

            foreach (string i in input)
            {
                if (GetVowelCount(i) >= 3 && GetDoubleCount(i) >= 1 && GetIllegalStringCount(i) == 0)
                {
                    count_nice_strings++;
                }

                if (GetLetterPairWithoutOverlappingCount(i) >= 1 && GetRepeatingWhithLetterInBetweenCount(i) >= 1)
                {
                    count_nicer_strings++;
                }
            }

            Console.WriteLine("Nice Strings: " + count_nice_strings);
            Console.WriteLine("Nicer Strings: " + count_nicer_strings);

            Console.ReadLine();
        }

        private static int GetVowelCount(string input)
        {
            char[] chars = input.ToCharArray();
            int count = 0;

            foreach (char i in chars)
            {
                if (i == 'a' || i == 'e' || i == 'i' || i == 'o' || i == 'u')
                {
                    count++;
                }
            }
            
            return count;
        }

        private static int GetDoubleCount(string input)
        {
            char[] chars = input.ToCharArray();
            int count = 0;
            char last_char = ' ';

            foreach (char i in chars)
            {
                if (i == last_char)
                {
                    count++;
                }

                last_char = i;
            }

            return count;
        }

        private static int GetIllegalStringCount(string input)
        {
            int count = 0;

            if (input.Contains("ab"))
            {
                count++;
            }

            if (input.Contains("cd"))
            {
                count++;
            }

            if (input.Contains("pq"))
            {
                count++;
            }

            if (input.Contains("xy"))
            {
                count++;
            }


            return count;
        }

        private static int GetLetterPairWithoutOverlappingCount(string input)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string temp = "";
            int count = 0;

            foreach (char i in chars)
            {
                foreach (char j in chars)
                {
                    temp = input;
                    string pair = new string(new char[] { i, j });

                    if (temp.Contains(pair))
                    {
                        temp = new Regex(pair).Replace(temp, "-", 1);

                        if (temp.Contains(pair))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private static int GetRepeatingWhithLetterInBetweenCount(string input)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int count = 0;

            foreach (char i in chars)
            {
                foreach (char j in chars)
                {
                    char[] x = { i, j, i };

                    if (input.Contains(new string(x)))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}

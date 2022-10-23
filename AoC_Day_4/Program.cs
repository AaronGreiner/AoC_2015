using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AoC_Day_4
{
    internal class Program
    {
        private static MD5 md5 = new MD5CryptoServiceProvider();

        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"../../input.txt");
            int current_number = 0;
            int five_zero_number = 0;
            int six_zero_number = 0;
            string hash = "";

            while (true)
            {
                hash = GetMD5Hash(input + current_number.ToString());

                if (five_zero_number == 0 && hash.StartsWith("00000"))
                {
                    five_zero_number = current_number;

                } else if (six_zero_number == 0 && hash.StartsWith("000000"))
                {
                    six_zero_number = current_number;
                }

                if (five_zero_number != 0 && six_zero_number != 0)
                {
                    break;
                }

                current_number++;
            }

            Console.WriteLine("Lowest possible Number (five zeros): " + five_zero_number);
            Console.WriteLine("Lowest possible Number (six zeros): " + six_zero_number);

            Console.ReadLine();
        }

        private static string GetMD5Hash(string input)
        {
            byte[] result = md5.ComputeHash(Encoding.Default.GetBytes(input));

            return BitConverter.ToString(result).Replace("-", "");
        }
    }
}

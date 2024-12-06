
using System;
using System.Text.RegularExpressions;

namespace Day3
{
    public static class Part1
    {
        public static int CalculateSumOfMultiplications(string input)
        {
            int sum = 0;
            string pattern = @"mul\((\d+),(\d+)\)";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                sum += x * y;
            }

            return sum;
        }
    }
}
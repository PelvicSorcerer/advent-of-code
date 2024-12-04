using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day2
{
    public class Part1
    {
        public void Run()
        {
            // Read input from file
            var lines = File.ReadAllLines(@"Resources\input.txt");

            int safeReportsCount = 0;

            foreach (var line in lines)
            {
                var levels = line.Split(' ').Select(int.Parse).ToList();
                bool isSafe = IsSafe(levels);
                Console.WriteLine($"Report: {string.Join(" ", levels)} - Safe: {isSafe}");
                if (isSafe)
                {
                    safeReportsCount++;
                }
            }

            // Output the number of safe reports
            Console.WriteLine($"Number of safe reports: {safeReportsCount}");
        }

        private bool IsSafe(List<int> levels)
        {
            bool increasing = true;
            bool decreasing = true;

            for (int i = 1; i < levels.Count; i++)
            {
                int diff = Math.Abs(levels[i] - levels[i - 1]);
                Console.WriteLine($"Comparing {levels[i - 1]} and {levels[i]}, diff: {diff}");
                if (diff < 1 || diff > 3)
                {
                    Console.WriteLine("Difference out of range, returning false.");
                    return false;
                }
                if (levels[i] > levels[i - 1])
                {
                    decreasing = false;
                }
                if (levels[i] < levels[i - 1])
                {
                    increasing = false;
                }
            }

            Console.WriteLine($"Increasing: {increasing}, Decreasing: {decreasing}");
            return increasing || decreasing;
        }
    }
}
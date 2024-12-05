using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Part2
    {
        public void Run()
        {
            List<int[]> reports;
            try
            {
                reports = ReadReportsFromFile("Resources/input.txt"); // Updated file path
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return;
            }

            int safeReports = 0;
            foreach (var report in reports)
            {
                if (IsSafe(report))
                {
                    safeReports++;
                    Console.WriteLine($"Report is safe: {string.Join(" ", report)}");
                }
                else if (CanBeMadeSafe(report))
                {
                    safeReports++;
                    Console.WriteLine($"Report can be made safe: {string.Join(" ", report)}");
                }
                else
                {
                    Console.WriteLine($"Report is neither safe nor can be made safe: {string.Join(" ", report)}");
                }
            }
            Console.WriteLine($"Number of safe reports: {safeReports}");
        }

        List<int[]> ReadReportsFromFile(string filePath)
        {
            var reports = new List<int[]>();
            foreach (var line in File.ReadLines(filePath))
            {
                var report = line.Split(' ').Select(int.Parse).ToArray();
                reports.Add(report);
            }
            return reports;
        }

        static bool IsSafe(int[] report)
        {
            bool increasing = true;
            bool decreasing = true;

            for (int i = 1; i < report.Length; i++)
            {
                int diff = Math.Abs(report[i] - report[i - 1]);
                if (diff < 1 || diff > 3)
                {
                    return false;
                }
                if (report[i] > report[i - 1])
                {
                    decreasing = false;
                }
                if (report[i] < report[i - 1])
                {
                    increasing = false;
                }
            }

            return increasing || decreasing;
        }

        static bool CanBeMadeSafe(int[] report)
        {
            for (int i = 0; i < report.Length; i++)
            {
                var modifiedReport = report.Where((_, index) => index != i).ToArray();
                if (IsSafe(modifiedReport))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
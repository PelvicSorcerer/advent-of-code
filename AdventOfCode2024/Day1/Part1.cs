
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day1
{
    public class Part1
    {
        public void Run()
        {
            // Read input from file
            var lines = File.ReadAllLines(@"Resources\Input.txt");

            // Initialize lists for left and right numbers
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            // Parse the input into two lists
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                {
                    leftList.Add(int.Parse(parts[0]));
                    rightList.Add(int.Parse(parts[1]));
                }
            }

            // Sort both lists
            leftList.Sort();
            rightList.Sort();

            // Compute the total distance
            int totalDistance = 0;
            for (int i = 0; i < leftList.Count; i++)
            {
                totalDistance += Math.Abs(leftList[i] - rightList[i]);
            }

            // Output the total distance
            Console.WriteLine($"Total distance: {totalDistance}");
        }
    }
}
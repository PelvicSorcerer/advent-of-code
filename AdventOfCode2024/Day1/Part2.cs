
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day1
{
    public class Part2
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

            // Compute the similarity score
            int similarityScore = 0;
            foreach (var left in leftList)
            {
                int countInRight = rightList.Count(x => x == left);
                similarityScore += left * countInRight;
            }

            // Output the similarity score
            Console.WriteLine($"Similarity score: {similarityScore}");
        }
    }
}
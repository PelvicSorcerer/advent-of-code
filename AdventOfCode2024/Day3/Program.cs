using System;
using System.Text.RegularExpressions;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = Path.Combine("Resources", "input.txt");
            string input = File.ReadAllText(inputFilePath);
            int result = Part1.CalculateSumOfMultiplications(input);
            Console.WriteLine($"The sum of all valid multiplications is: {result}");
        }
    }
}
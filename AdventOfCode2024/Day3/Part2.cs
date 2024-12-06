using System;
using System.Text.RegularExpressions;

public class Part2
{
    public static int CalculateSum(string input)
    {
        var mulEnabled = true;
        var sum = 0;
        var regex = new Regex(@"(mul\((\d+),(\d+)\)|do\(\)|don't\(\))");

        foreach (Match match in regex.Matches(input))
        {
            if (match.Value.StartsWith("mul"))
            {
                if (mulEnabled)
                {
                    var groups = match.Groups;
                    var a = int.Parse(groups[2].Value);
                    var b = int.Parse(groups[3].Value);
                    sum += a * b;
                }
            }
            else if (match.Value == "do()")
            {
                mulEnabled = true;
            }
            else if (match.Value == "don't()")
            {
                mulEnabled = false;
            }
        }

        return sum;
    }
}
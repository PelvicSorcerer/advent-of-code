// See https://aka.ms/new-console-template for more information
using Day1;
using System.Text.RegularExpressions;

var partOneAnswer = new Regex(@"((?<nums>\d+)(\n|$))+").Matches(Day1.Properties.Resources.input).Select(match => match.Groups["nums"].Captures.Select(num => int.Parse(num.Value)).ToList().Sum()).ToList().OrderByDescending(sum => sum).First();

var partTwoAnswer = new Regex(@"((?<nums>\d+)(\n|$))+").Matches(Day1.Properties.Resources.input).Select(match => match.Groups["nums"].Captures.Select(num => int.Parse(num.Value)).ToList().Sum()).ToList().OrderByDescending(sum => sum).ToList().GetRange(0, 3).Sum();

#region Unfinished Stuff

var elves = new List<Elf>();
new Regex(@"((\d+\n)|(\d+$))+").Matches(Day1.Properties.Resources.input).ToList().ForEach(match => elves.Add(new Elf(match.Groups[1].Captures.Select(consumable => int.Parse(consumable.ToString().Trim())).ToList())));
var leaderBoard = elves.OrderByDescending(elf => elf.GetTotalCalories());

#endregion

Console.WriteLine("beep");
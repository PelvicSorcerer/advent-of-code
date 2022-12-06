using Day2;
using System.Text.RegularExpressions;

var pattern = new Regex(@"([A-Z]) ([A-Z])");
var matches = pattern.Matches(Day2.Properties.Resources.input);

#region Part 1

var part1Rounds = ReadGuideAsPlays();

var part1Results = ScoreRounds(part1Rounds);

#endregion

#region Part 2

var part2Rounds = ReadGuideAsPlayAndOutcome();

var part2Results = ScoreRounds(part2Rounds);

#endregion

Console.WriteLine("breakpoint");

#region Support Methods
List<Round> ReadGuideAsPlays()
{
    var rounds = new List<Round>();

    foreach (Match match in matches)
    {
        var round = new Round(Play.GetPlay(match.Groups[1].Value), Play.GetPlay(match.Groups[2].Value));
        rounds.Add(round);
    }

    return rounds;
}

List<Round> ReadGuideAsPlayAndOutcome()
{
    var rounds = new List<Round>();

    foreach (Match match in matches)
    {
        var round = new Round(Play.GetPlay(match.Groups[1].Value), (Round.OutcomeType)match.Groups[2].Value[0]);
        rounds.Add(round);
    }

    return rounds;
}

(int player1Score, int player2Score) ScoreRounds(List<Round> rounds)
{
    int player1Score = 0;
    int player2Score = 0;

    foreach (var round in rounds)
    {
        player1Score += round.Player1Score;
        player2Score += round.Player2Score;
    }

    return (player1Score, player2Score);
}

#endregion
using Day2;
using System.Text.RegularExpressions;

var pattern = new Regex(@"([A-Z]) ([A-Z])");
var matches = pattern.Matches(Day2.Properties.Resources.input);

#region Part 1

var rounds = ReadGuideAsPlays();

var results = ScoreRounds(rounds);

#endregion

#region Part 2



#endregion

Console.WriteLine("breakpoint");

#region Support Methods
List<(Play, Play)> ReadGuideAsPlays()
{
    var rounds = new List<(Play, Play)>();

    foreach (Match match in matches)
    {
        var round = (new Play(match.Groups[1].Value), new Play(match.Groups[2].Value));
        rounds.Add(round);
    }

    return rounds;
}

(int player1Score, int player2Score) ScoreRounds(List<(Play play1, Play play2)> rounds)
{
    int player1Score = 0;
    int player2Score = 0;

    foreach (var round in rounds)
    {
        var score = ScoreRound(round);

        player1Score += score.player1Score;
        player2Score += score.player2Score;
    }

    return (player1Score, player2Score);
}

(int player1Score, int player2Score) ScoreRound((Play play1, Play play2) round)
{
    int player1Score = round.play1.PointValue;
    int player2Score = round.play2.PointValue;

    if (round.play1 == round.play2)
    {
        player1Score += 3;
        player2Score += 3;
    }
    else if (round.play1 > round.play2)
    {
        player1Score += 6;
    }
    else
    {
        player2Score += 6;
    }

    return (player1Score, player2Score);
}

#endregion
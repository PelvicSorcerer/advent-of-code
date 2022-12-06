using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Round
    {
        #region Enums

        public enum OutcomeType
        {
            Player1 = 'X',
            Draw = 'Y',
            Player2 = 'Z'
        }

        #endregion

        #region Fields

        private OutcomeType _outcome;

        #endregion

        #region Constructors

        public Round(Play play1, Play play2)
        {
            Play1 = play1;
            Play2 = play2;
            _outcome = DetermineOutcome();
            var scores = DetermineScore();
            Player1Score = scores.player1Score;
            Player2Score = scores.player2Score;
        }

        public Round(Play play1, OutcomeType outcome)
        {
            Play1 = play1;
            _outcome = outcome;
            Play2 = DeterminePlay2();
            var scores = DetermineScore();
            Player1Score = scores.player1Score;
            Player2Score = scores.player2Score;
        }

        #endregion

        #region Properties

        public Play Play1 { get; }

        public Play Play2 { get; }

        public int Player1Score { get; }

        public int Player2Score { get; }

        public OutcomeType Outcome => _outcome;

        #endregion

        #region Private Methods

        private OutcomeType DetermineOutcome()
        {
            OutcomeType outcome;

            if (Play1.Beats() == Play2.GetType())
            {
                outcome = OutcomeType.Player1;
            }
            else if (Play2.Beats() == Play1.GetType())
            {
                outcome = OutcomeType.Player2;
            }
            else
            {
                outcome = OutcomeType.Draw;
            }

            return outcome;
        }

        private Play DeterminePlay2()
        {
            Play play2;

            if (Outcome == OutcomeType.Draw)
                play2 = (Play)Activator.CreateInstance(Play1.GetType());
            else if (Outcome == OutcomeType.Player1)
                play2 = (Play)Activator.CreateInstance(Play1.Beats());
            else
                play2 = (Play)Activator.CreateInstance(Play1.BeatenBy());

            return play2;
        }

        private (int player1Score, int player2Score) DetermineScore()
        {
            int player1Score = Play1.PointValue;
            int player2Score = Play2.PointValue;

            if (Outcome == Round.OutcomeType.Draw)
            {
                player1Score += 3;
                player2Score += 3;
            }
            else if (Outcome == Round.OutcomeType.Player1)
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
    }
}

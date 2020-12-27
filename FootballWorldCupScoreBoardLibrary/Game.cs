using System;

namespace FootballWorldCupScoreBoard
{
    internal class Game
    {
        public string HomeTeam { get; }
        public string AwayTeam { get; }
        public string GameId => HomeTeam + "-" + AwayTeam;
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }

        public Game(string homeTeam, string awayTeam)
        {
            if (string.IsNullOrEmpty(homeTeam))
                throw new ArgumentNullException(nameof(homeTeam));

            if (string.IsNullOrEmpty(awayTeam))
                throw new ArgumentNullException(nameof(awayTeam));

            if (homeTeam.ToUpper() == awayTeam.ToUpper())
                throw new ArgumentException($"The {nameof(homeTeam)} cannot be the same as the {nameof(awayTeam)}");

            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        internal bool UpdateScore(int homeScore, int awayScore)
        {
            if (homeScore < 0 || awayScore < 0)
                return false;

            HomeScore = homeScore;
            AwayScore = awayScore;

            return true;
        }
    }
}
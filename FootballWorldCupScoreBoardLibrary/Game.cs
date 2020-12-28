using System;

namespace FootballWorldCupScoreBoard
{
    /// <summary>
    /// Represents a game.
    /// </summary>
    public class Game
    {
        public string HomeTeam { get; }
        public string AwayTeam { get; }
        public string GameId => HomeTeam + "-" + AwayTeam;
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }

        /// <summary>
        /// Initialize a new instance of the Game class.
        /// </summary>
        /// <param name="homeTeam">A name of the home team.</param>
        /// <param name="awayTeam">A name of the away team.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when homeTeam is null. -or- awayTeam is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the specified homeTeam is same as the specified awayTeam. </exception> 
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

        /// <summary>
        /// Updates the score of the game.
        /// </summary>
        /// <param name="homeScore">The value of the home team's score to update. The value must be bigger or equal to zero.</param>
        /// <param name="awayScore">The value of the away team's score to update. The value must be bigger or equal to zero.</param>
        /// <returns>true if the score successfully updated; otherwise, false.</returns>
        public bool UpdateScore(int homeScore, int awayScore)
        {
            // homeScore and awayScore cannot be less then zero
            if (homeScore < 0 || awayScore < 0)
                return false;

            HomeScore = homeScore;
            AwayScore = awayScore;

            return true;
        }
    }
}
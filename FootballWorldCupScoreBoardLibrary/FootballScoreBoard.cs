using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballWorldCupScoreBoard
{
    /// <summary>
    /// Represents a football scoreboard.
    /// </summary>
    public class FootballScoreBoard : IFootballScoreBoard
    {
        private readonly Dictionary<string, Game> games;

        /// <summary>
        /// Initialize a new instance of the FootballScoreBoard class
        /// </summary>
        public FootballScoreBoard()
        {
            games = new Dictionary<string, Game>();
        }

        public string StartGame(string homeTeam, string awayTeam)
        {
            if (games.Values.Any(g => g.HomeTeam.ToUpper() == homeTeam.ToUpper() || g.AwayTeam.ToUpper() == homeTeam.ToUpper()))
                throw new ArgumentException("The homeTeam has already been playing");

            if (games.Values.Any(g => g.HomeTeam.ToUpper() == awayTeam.ToUpper() || g.AwayTeam.ToUpper() == awayTeam.ToUpper()))
                throw new ArgumentException("The awayTeam has already been playing");

            var game = new Game(homeTeam, awayTeam);

            games.Add(game.GameId, game);

            return game.GameId;
        }

        public bool FinishGame(string gameId)
        {
            if (string.IsNullOrEmpty(gameId))
                throw new ArgumentNullException("gameId");

            return games.Remove(gameId);
        }

        public bool UpdateScore(string gameId, int homeScore, int awayScore)
        {
            if (string.IsNullOrEmpty(gameId))
                throw new ArgumentNullException("gameId");

            if (games.Keys.Contains(gameId) == false)
                throw new ArgumentException("gameId does not exist");

            return games[gameId].UpdateScore(homeScore, awayScore);
        }

        public IEnumerable<Game> GetSummary(IComparer<Game> customComparer = null)
        {
            var values = games.Values.ToList();

            if (customComparer != null)
            {
                values.Sort(customComparer);
            }
            else
            {
                values.Sort(DefaultComparerByTotalScore);
            }

            return values;
        }

        /// <summary>
        /// Returns comparison of two games by total score.
        /// </summary>
        /// <param name="game1">The first game instance for compare.</param>
        /// <param name="game2">The second game instance for compare.</param>
        /// <returns>A signed number indicating the total score of the first game less or 
        ///     bigger the total score of the second game. Value less than zero means that 
        ///     a total score of the first game greater or equal to a total score of the second game. 
        ///     Otherwise value is bigger than zero.</returns>
        private int DefaultComparerByTotalScore(Game game1, Game game2)
        {
            return game2.HomeScore + game2.AwayScore > game1.HomeScore + game1.AwayScore ? 1 : -1;
        }
    }
}
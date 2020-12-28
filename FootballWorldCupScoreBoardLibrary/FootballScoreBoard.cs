using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballWorldCupScoreBoard
{
    public class FootballScoreBoard
    {
        private readonly Dictionary<string, Game> games;

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

        public IEnumerable<Game> GetSummary()
        {
            var values = games.Values.ToList();

            values.Sort((game1, game2) => 
                game2.HomeScore + game2.AwayScore > game1.HomeScore + game1.AwayScore ? 1 : -1);

            return values;
        }
    }
}
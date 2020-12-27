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

        public void StartGame(string homeTeam, string awayTeam)
        {
            if (string.IsNullOrEmpty(homeTeam))
                throw new ArgumentNullException(nameof(homeTeam));

            if (string.IsNullOrEmpty(awayTeam))
                throw new ArgumentNullException(nameof(awayTeam));
            
            if (homeTeam.ToUpper() == awayTeam.ToUpper())
                throw new ArgumentException($"The {nameof(homeTeam)} cannot be the same as the {nameof(awayTeam)}");

            if (games.Values.Any(g => g.HomeTeam.ToUpper() == homeTeam.ToUpper() || g.AwayTeam.ToUpper() == homeTeam.ToUpper()))
                throw new ArgumentException("The homeTeam has already been playing");

            if (games.Values.Any(g => g.HomeTeam.ToUpper() == awayTeam.ToUpper() || g.AwayTeam.ToUpper() == awayTeam.ToUpper()))
                throw new ArgumentException("The awayTeam has already been playing");

            var game = new Game(homeTeam, awayTeam);

            games.Add(game.GameId, game);
        }
    }
}
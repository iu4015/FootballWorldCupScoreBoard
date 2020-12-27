using System;

namespace FootballWorldCupScoreBoard
{
    public class FootballScoreBoard
    {
        public FootballScoreBoard()
        {
        }

        public void StartGame(string homeTeam, string awayTeam)
        {
            if (string.IsNullOrEmpty(homeTeam))
                throw new ArgumentNullException(nameof(homeTeam));
        }
    }
}
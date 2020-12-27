namespace FootballWorldCupScoreBoard
{
    internal class Game
    {
        public Game(string homeTeam, string awayTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        public string HomeTeam { get; }
        public string AwayTeam { get; }
        public string GameId => HomeTeam + "-" + AwayTeam;
    }
}
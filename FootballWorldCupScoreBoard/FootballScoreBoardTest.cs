using NUnit.Framework;
using System;

namespace FootballWorldCupScoreBoard
{
    [TestFixture]
    class FootballScoreBoardTest
    {
        [Test]
        public void StartGame_HomeTeamNameNullOrEmpty_ThrowsArgumentNullException()
        {
            string homeTeam = "", awayTeam = "Ukraine";
            var scoreBoard = new FootballScoreBoard();

            Assert.Throws<ArgumentNullException>(() => scoreBoard.StartGame(homeTeam, awayTeam));
        }
    }
}

using NUnit.Framework;
using System;

namespace FootballWorldCupScoreBoard
{
    [TestFixture]
    class FootballScoreBoardTest
    {
        [Test]
        [Category("StartGameExceptions")]
        [TestCase("", "Ukraine")]
        [TestCase(null, "Ukraine")]
        public void StartGame_HomeTeamNameNullOrEmpty_ThrowsArgumentNullException(string homeTeam, string awayTeam)
        {
            var scoreBoard = new FootballScoreBoard();

            Assert.Throws<ArgumentNullException>(() => scoreBoard.StartGame(homeTeam, awayTeam));
        }

        [Test]
        [Category("StartGameExceptions")]
        [TestCase("England", "")]
        [TestCase("England", null)]
        public void StartGame_AwayTeamNameNullOrEmpty_ThrowsArgumentNullException(string homeTeam, string awayTeam)
        {
            var scoreBoard = new FootballScoreBoard();

            Assert.Throws<ArgumentNullException>(() => scoreBoard.StartGame(homeTeam, awayTeam));
        }
    }
}

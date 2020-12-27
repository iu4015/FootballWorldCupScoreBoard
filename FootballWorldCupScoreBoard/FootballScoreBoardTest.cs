using NUnit.Framework;
using System;

namespace FootballWorldCupScoreBoard
{
    [TestFixture]
    class FootballScoreBoardTest
    {
        private FootballScoreBoard scoreBoard;

        [SetUp]
        public void Init()
        {
            scoreBoard = new FootballScoreBoard();
        }

        [Test]
        [Category("StartGameExceptions")]
        [TestCase("", "Ukraine")]
        [TestCase(null, "Ukraine")]
        public void StartGame_HomeTeamNameNullOrEmpty_ThrowsArgumentNullException(string homeTeam, string awayTeam)
        {
            Assert.Throws<ArgumentNullException>(() => scoreBoard.StartGame(homeTeam, awayTeam));
        }

        [Test]
        [Category("StartGameExceptions")]
        [TestCase("England", "")]
        [TestCase("England", null)]
        public void StartGame_AwayTeamNameNullOrEmpty_ThrowsArgumentNullException(string homeTeam, string awayTeam)
        {
            Assert.Throws<ArgumentNullException>(() => scoreBoard.StartGame(homeTeam, awayTeam));
        }

        [Test]
        [Category("StartGameExceptions")]
        [TestCase("England", "England")]
        [TestCase("England", "ENGLAND")]
        [TestCase("England", "england")]
        public void StartGame_HomeTeamSameAsAwayTeam_ThrowsArgumentException(string homeTeam, string awayTeam)
        {
            Assert.That(() => scoreBoard.StartGame(homeTeam, awayTeam), Throws
                .TypeOf<ArgumentException>()
                .With
                .Message
                .EqualTo("The homeTeam cannot be the same as the awayTeam"));
        }
    }
}

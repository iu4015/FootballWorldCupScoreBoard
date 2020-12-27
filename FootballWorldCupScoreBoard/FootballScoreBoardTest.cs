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

        [Test]
        [Category("StartGameExceptions")]
        [TestCase("Ukraine", "Canada")]
        [TestCase("UKRAINE", "GERMANY")]
        [TestCase("ukraine", "Italy")]
        [TestCase("France", "Mexico")]
        [TestCase("FRANCE", "JAPAN")]
        [TestCase("france", "belgium")]
        public void StartGame_ExistingHomeTeam_ThrowsArgumentException(string homeTeam, string awayTeam)
        {
            string homeTeam1 = "England", awayTeam1 = "Ukraine", homeTeam2 = "France", awayTeam2 = "Argentina";

            scoreBoard.StartGame(homeTeam1, awayTeam1);
            scoreBoard.StartGame(homeTeam2, awayTeam2);

            Assert.That(() => scoreBoard.StartGame(homeTeam, awayTeam), Throws
                .TypeOf<ArgumentException>()
                .With
                .Message
                .EqualTo("The homeTeam has already been playing"));
        }

        [Test]
        [Category("StartGameExceptions")]
        [TestCase("Italy", "England")]
        [TestCase("GERMANY", "ENGLAND")]
        [TestCase("Canada", "england")]
        [TestCase("Mexico", "Argentina")]
        [TestCase("JAPAN", "ARGENTINA")]
        [TestCase("belgium", "argentina")]
        public void StartGame_ExistingAwayTeam_ThrowsArgumentException(string homeTeam, string awayTeam)
        {
            string homeTeam1 = "England", awayTeam1 = "Ukraine", homeTeam2 = "France", awayTeam2 = "Argentina";

            scoreBoard.StartGame(homeTeam1, awayTeam1);
            scoreBoard.StartGame(homeTeam2, awayTeam2);

            Assert.That(() => scoreBoard.StartGame(homeTeam, awayTeam), Throws
                .TypeOf<ArgumentException>()
                .With
                .Message
                .EqualTo("The awayTeam has already been playing"));
        }

        [Test]
        [Category("StartGameNoExceptions")]
        public void StartGame_CorrectParameters_ReturnGameId()
        {
            string homeTeam = "England", awayTeam = "Ukraine";
            string expected = "England-Ukraine";

            string result = scoreBoard.StartGame(homeTeam, awayTeam);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [Category("FinishGameExceptions")]
        [TestCase("")]
        [TestCase(null)]
        public void FinishGame_GameIdNullOrEmpty_ThrowsArgumentNullException(string gameId)
        {
            string homeTeam = "England", awayTeam = "Ukraine";

            scoreBoard.StartGame(homeTeam, awayTeam);

            Assert.Throws<ArgumentNullException>(() => scoreBoard.FinishGame(gameId));
        }

        [Test]
        [Category("FinishGameNoExceptions")]
        public void FinishGame_NotExistingGameId_ReturnFalse()
        {
            string homeTeam = "England", awayTeam = "Ukraine", gameId = "NotExistingGameId";

            scoreBoard.StartGame(homeTeam, awayTeam);

            Assert.IsFalse(scoreBoard.FinishGame(gameId));
        }

        [Test]
        [Category("FinishGameNoExceptions")]
        public void FinishGame_ExistingGameId_ReturnTrue()
        {
            string homeTeam = "England", awayTeam = "Ukraine", gameId = "England-Ukraine";

            scoreBoard.StartGame(homeTeam, awayTeam);

            Assert.IsTrue(scoreBoard.FinishGame(gameId));
        }

        [Test]
        [Category("UpdateScoreExceptions")]
        [TestCase("")]
        [TestCase(null)]
        public void UpdateScore_GameIdNullOrEmpty_ThrowsArgumentNullException(string gameId)
        {
            string homeTeam = "England", awayTeam = "Ukraine";

            scoreBoard.StartGame(homeTeam, awayTeam);

            Assert.Throws<ArgumentNullException>(() => scoreBoard.UpdateScore(gameId, 1, 0));
        }

        [Test]
        [Category("UpdateScoreExceptions")]
        public void UpdateScore_NotExistingGameId_ThrowsArgumentException()
        {
            string homeTeam = "England", awayTeam = "Ukraine", gameId = "NonExistingGameId";

            scoreBoard.StartGame(homeTeam, awayTeam);

            Assert.Throws<ArgumentException>(() => scoreBoard.UpdateScore(gameId, 1, 0));
        }

        [Test]
        [Category("UpdateScoreNoExceptions")]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        public void UpdateScore_CorrectParameters_ReturnTrue(int homeScore, int awayScore)
        {
            string homeTeam = "England", awayTeam = "Ukraine", gameId = "England-Ukraine";

            scoreBoard.StartGame(homeTeam, awayTeam);

            Assert.IsTrue(scoreBoard.UpdateScore(gameId, homeScore, awayScore));
        }

        [Test]
        [Category("UpdateScoreNoExceptions")]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void UpdateScore_WrongScoreValue_ReturnFalse(int homeScore, int awayScore)
        {
            string homeTeam = "England", awayTeam = "Ukraine", gameId = "England-Ukraine";

            scoreBoard.StartGame(homeTeam, awayTeam);

            Assert.IsFalse(scoreBoard.UpdateScore(gameId, homeScore, awayScore));
        }
    }
}

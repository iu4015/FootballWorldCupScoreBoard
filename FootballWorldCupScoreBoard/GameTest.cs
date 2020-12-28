using NUnit.Framework;
using System;

namespace FootballWorldCupScoreBoard
{
    [TestFixture]
    class GameTest
    {
        [Test]
        [Category("GameExceptions")]
        [TestCase("", "Ukraine")]
        [TestCase(null, "Ukraine")]
        public void CreateGame_HomeTeamNameNullOrEmpty_ThrowsArgumentNullException(string homeTeam, string awayTeam)
        {
            Assert.Throws<ArgumentNullException>(() => new Game(homeTeam, awayTeam));
        }

        [Test]
        [Category("GameExceptions")]
        [TestCase("England", "")]
        [TestCase("England", null)]
        public void CreateGame_AwayTeamNameNullOrEmpty_ThrowsArgumentNullException(string homeTeam, string awayTeam)
        {
            Assert.Throws<ArgumentNullException>(() => new Game(homeTeam, awayTeam));
        }

        [Test]
        [Category("GameExceptions")]
        [TestCase("England", "England")]
        [TestCase("England", "ENGLAND")]
        [TestCase("England", "england")]
        public void CreateGame_HomeTeamSameAsAwayTeam_ThrowsArgumentException(string homeTeam, string awayTeam)
        {
            Assert.That(() => new Game(homeTeam, awayTeam), Throws
                .TypeOf<ArgumentException>()
                .With
                .Message
                .EqualTo("The homeTeam cannot be the same as the awayTeam"));
        }

        [Test]
        [Category("GameNoExceptions")]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        public void UpdateScore_CorrectParameters_ReturnTrue(int homeScore, int awayScore)
        {
            string homeTeam = "England", awayTeam = "Ukraine";

            Game game = new Game(homeTeam, awayTeam);

            Assert.IsTrue(game.UpdateScore(homeScore, awayScore));
        }

        [Test]
        [Category("GameNoExceptions")]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void UpdateScore_WrongScoreValue_ReturnFalse(int homeScore, int awayScore)
        {
            string homeTeam = "England", awayTeam = "Ukraine";

            Game game = new Game(homeTeam, awayTeam);

            Assert.IsFalse(game.UpdateScore(homeScore, awayScore));
        }

        [Test]
        [Category("GameNoExceptions")]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(0, 0)]
        public void UpdateScore_HomeScoreUpdatedSuccessfully(int homeScore, int awayScore)
        {
            string homeTeam = "England", awayTeam = "Ukraine";

            Game game = new Game(homeTeam, awayTeam);

            game.UpdateScore(homeScore, awayScore);

            Assert.AreEqual(game.HomeScore, homeScore);
        }

        [Test]
        [Category("GameNoExceptions")]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 2)]
        public void UpdateScore_AwayScoreUpdatedSuccessfully(int homeScore, int awayScore)
        {
            string homeTeam = "England", awayTeam = "Ukraine";

            Game game = new Game(homeTeam, awayTeam);

            game.UpdateScore(homeScore, awayScore);

            Assert.AreEqual(game.AwayScore, awayScore);
        }

        [Test]
        [Category("GameNoExceptions")]
        [TestCase(-1, 0)]
        [TestCase(-2, -1)]
        public void UpdateScore_HomeScoreNotUpdated(int homeScore, int awayScore)
        {
            string homeTeam = "England", awayTeam = "Ukraine";

            Game game = new Game(homeTeam, awayTeam);

            game.UpdateScore(homeScore, awayScore);

            Assert.AreNotEqual(game.HomeScore, homeScore);
        }

        [Test]
        [Category("GameNoExceptions")]
        [TestCase(0, -1)]
        [TestCase(-1, -2)]
        public void UpdateScore_AwayScoreNotUpdated(int homeScore, int awayScore)
        {
            string homeTeam = "England", awayTeam = "Ukraine";

            Game game = new Game(homeTeam, awayTeam);

            game.UpdateScore(homeScore, awayScore);

            Assert.AreNotEqual(game.AwayScore, awayScore);
        }
    }
}

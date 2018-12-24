using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class TennisGameTests
    {
        private TennisGame game;

        [SetUp]
        public void SetUp()
        {
            game = new TennisGame();
            Assert.NotNull(game);
        }

        [Test]
        public void CanScores()
        {
            AssertScores("Love All");
        }

        private void AssertScores(string expected)
        {
            string result = game.Scores();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CanGetPoints()
        {
            game.GetPoints(1);
            AssertScores("Fifteen Love");
        }

        [TestCase(new int[] { 1, 1 }, ExpectedResult = "Thirty Love")]
        [TestCase(new int[] { 1, 1, 1 }, ExpectedResult = "Forty Love")]
        public string GetPoints_AllPlayer1Get_CheckScores(int[] getPointsPlayer)
        {
            return ProgressGameAndGetSocres(getPointsPlayer);
        }

        private string ProgressGameAndGetSocres(int[] getPointsPlayer)
        {
            ProgressGame(getPointsPlayer);
            return game.Scores();
        }

        private void ProgressGame(int[] getPointsPlayer)
        {
            foreach (int player in getPointsPlayer)
            {
                game.GetPoints(player);
            }
        }

        [TestCase(new int[] { 1, 2 }, ExpectedResult = "Fifteen All")]
        [TestCase(new int[] { 1, 1, 2 }, ExpectedResult = "Thirty Fifteen")]
        [TestCase(new int[] { 1, 1, 2, 2 }, ExpectedResult = "Thirty All")]
        [TestCase(new int[] { 1, 1, 1 }, ExpectedResult = "Forty Love")]
        [TestCase(new int[] { 1, 1, 1, 2 }, ExpectedResult = "Forty Fifteen")]
        [TestCase(new int[] { 1, 1, 1, 2, 2 }, ExpectedResult = "Forty Thirty")]
        [TestCase(new int[] { 1, 1, 2, 2, 2 }, ExpectedResult = "Forty Thirty")]
        public string GetPoints_GivenGetPointsSituation_CheckScores(int[] getPointsPlayer)
        {
            return ProgressGameAndGetSocres(getPointsPlayer);
        }

        [Test]
        public void GetPoints_GivenDeuce_CheckScores()
        {
            ProgressGame(new int[] { 1, 1, 1, 2, 2, 2 });
            AssertScores("Deuce");
        }

        [TestCase(new int[] { 1 }, ExpectedResult = "Player1 Adv")]
        [TestCase(new int[] { 2 }, ExpectedResult = "Player2 Adv")]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = "Deuce")]
        public string GetPoints_GivenDeuceAdvantage_CheckScores(int[] getPointsPlayer)
        {
            ProgressGame(new int[] { 1, 1, 1, 2, 2, 2 });
            return ProgressGameAndGetSocres(getPointsPlayer);
        }

        [Test]
        public void GetPoints_Player1Winner_CheckScoring()
        {
            ProgressGame(new int[] { 1, 1, 1, 1, 2, 2 });
            AssertScores("Winner : Player1");
        }
    }
}
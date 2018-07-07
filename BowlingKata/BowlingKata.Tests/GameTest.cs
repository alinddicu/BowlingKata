namespace BowlingKata.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class GameTest
	{
		[TestMethod]
		public void TestGameWith9sOnly()
		{
			Check.That(new Game("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-").GetScore()).IsEqualTo(90);
		}

		[TestMethod]
		public void TestGameWithStrikesOnly()
		{
			Check.That(new Game("X X X X X X X X X X X X").GetScore()).IsEqualTo(300);
		}
		
		[TestMethod]
		public void TestGameWithAllSparePlusFinal5()
		{
			Check.That(new Game("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5").GetScore()).IsEqualTo(150);
		}

		[TestMethod]
		public void TestGameWithSpareAndStrikeInLastFrame()
		{
			Check.That(new Game("9- 9- 9- 9- 9- 9- 9- 9- 9- 9/X").GetScore()).IsEqualTo(101);
		}

		[TestMethod]
		public void TestGameWithSparesAndStrikeInLastFrame()
		{
			Check.That(new Game("9- 9- 9- 9- 9- 9- 9- 9- 9- 9/X").GetScore()).IsEqualTo(101);
		}

		[TestMethod]
		public void TestGamesWithRandomScores()
		{
			Check.That(new Game("9- 9- 9- 9- 9- 9- 9- 9- 9/ 9-").GetScore()).IsEqualTo(100);
			Check.That(new Game("9- 9- 9/ 9- 9- 9- 9- 9- 9/ 9-").GetScore()).IsEqualTo(110);
			Check.That(new Game("9- 9- X 9- 9- 9- 9- 9- 9/ 9-").GetScore()).IsEqualTo(110);
			Check.That(new Game("9- 9- X 9/ 9- 9- 9- 9- 9/ 9-").GetScore()).IsEqualTo(121);
		}
	}
}

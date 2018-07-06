namespace BowlingKata.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class GameTest
	{
		[TestMethod]
		public void Test9sOnly()
		{
			Check.That(new Game("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-").GetScore()).IsEqualTo(90);
		}

		[TestMethod]
		public void TestStrikesOnly()
		{
			Check.That(new Game("X X X X X X X X X X X X").GetScore()).IsEqualTo(300);
		}
	}
}

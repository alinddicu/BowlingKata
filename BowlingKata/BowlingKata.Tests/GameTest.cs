namespace BowlingKata.Tests
{
	using System;
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
	}
}

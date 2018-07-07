namespace BowlingKata.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class LastFrameTests
	{
		[TestMethod]
		public void TestLastFrameComputeTotalPointsWhenNoStrikeAndNoSpare()
		{
			TestFrameTotal(new LastFrame("81"), 9);
		}

		[TestMethod]
		public void TestLastFrameComputeTotalPointsWhenMiss()
		{
			TestFrameTotal(new LastFrame("--"), 0);
			TestFrameTotal(new LastFrame("1-"), 1);
			TestFrameTotal(new LastFrame("-2"), 2);
		}

		[TestMethod]
		public void TestLastFrameComputeTotalPointsWhenSpare()
		{
			TestFrameTotal(new LastFrame("6/5"), 15);
			TestFrameTotal(new LastFrame("-/5"), 15);
		}

		private static void TestFrameTotal(Frame frame, int expectedFrameTotal)
		{
			Check.That(frame.ComputeTotalPoints()).IsEqualTo(expectedFrameTotal);
		}
	}
}

namespace BowlingKata.Tests
{
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class FrameTests
	{
		[TestMethod]
		public void TestFrameComputeTotalPointsWhenNoStrikeAndNoSpare()
		{
			TestFrameTotal(new Frame("81", Enumerable.Empty<Frame>()), 9);
		}

		[TestMethod]
		public void TestFrameComputeTotalPointsWhenMiss()
		{
			TestFrameTotal(new Frame("--", Enumerable.Empty<Frame>()), 0);
			TestFrameTotal(new Frame("1-", Enumerable.Empty<Frame>()), 1);
			TestFrameTotal(new Frame("-2", Enumerable.Empty<Frame>()), 2);
		}

		[TestMethod]
		public void TestFrameComputeTotalPointsWhenSpare()
		{
			TestFrameTotal(new Frame("6/", Enumerable.Empty<Frame>()), 10);
			TestFrameTotal(new Frame("-/", Enumerable.Empty<Frame>()), 10);
		}

		[TestMethod]
		public void TestFrameComputeTotalPointsWhenStrike()
		{
			TestFrameTotal(new Frame("X", Enumerable.Empty<Frame>()), 10);
		}

		private static void TestFrameTotal(Frame frame, int expectedFrameTotal)
		{
			Check.That(frame.ComputeTotalPoints()).IsEqualTo(expectedFrameTotal);
		}
	}
}

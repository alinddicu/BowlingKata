namespace BowlingKata.Tests
{
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class FrameTests
	{
		[TestMethod]
		public void TestNormalScore()
		{
			TestFrame(new Frame("81", Enumerable.Empty<Frame>()), false, false, 8, 1, 9);
		}

		[TestMethod]
		public void TestMiss()
		{
			TestFrame(new Frame("--", Enumerable.Empty<Frame>()), false, false, 0, 0, 0);
			TestFrame(new Frame("1-", Enumerable.Empty<Frame>()), false, false, 1, 0, 1);
			TestFrame(new Frame("-2", Enumerable.Empty<Frame>()), false, false, 0, 2, 2);
		}

		[TestMethod]
		public void TestSpare()
		{
			TestFrame(new Frame("6/", Enumerable.Empty<Frame>()), true, false, 6, 4, 10);
			TestFrame(new Frame("-/", Enumerable.Empty<Frame>()), true, false, 0, 10, 10);
		}

		[TestMethod]
		public void TestStrike()
		{
			TestFrame(new Frame("X", Enumerable.Empty<Frame>()), false, true, 10, 0, 10);
		}

		private static void TestFrame(Frame frame, bool isSpare, bool isStrike, int score1, int score2, int score)
		{
			Check.That(frame.IsSpare).IsEqualTo(isSpare);
			Check.That(frame.IsStrike).IsEqualTo(isStrike);
			Check.That(frame.Points1StThrow).IsEqualTo(score1);
			Check.That(frame.Points2NdThrow).IsEqualTo(score2);
			Check.That(frame.Score).IsEqualTo(score);
		}
	}
}

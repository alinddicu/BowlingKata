namespace BowlingKata.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class FrameTests
	{
		[TestMethod]
		public void TestScore1AndScore2()
		{
			TestFrame(new Frame("5/4"), 5,4, false, false, 9);
		}

		[TestMethod]
		public void TestMiss()
		{
			TestFrame(new Frame("-/-"), 0, 0, false, false, 0);
			TestFrame(new Frame("1/-"), 1, 0, false, false, 1);
			TestFrame(new Frame("-/2"), 0, 2, false, false, 2);
		}

		[TestMethod]
		public void TestSpare()
		{
			TestFrame(new Frame("6/4"), 6, 4, true, false, 10);
			TestFrame(new Frame("-/10"), 0, 10, true, false, 10);
		}

		[TestMethod]
		public void TestStrike()
		{
			TestFrame(new Frame("10/-"), 10, 0, false, true, 10);
		}

		private static void TestFrame(Frame frame, int score1, int score2, bool isSpare, bool isStrike, int total)
		{
			Check.That(frame.Score1).IsEqualTo(score1);
			Check.That(frame.Score2).IsEqualTo(score2);
			Check.That(frame.IsSpare).IsEqualTo(isSpare);
			Check.That(frame.IsStrike).IsEqualTo(isStrike);
			Check.That(frame.Total).IsEqualTo(total);
		}
	}
}

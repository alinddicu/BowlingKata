namespace BowlingKata.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class FrameTests
	{
		[TestMethod]
		public void TestNormalScore()
		{
			TestFrame(new Frame("81"), false, false, 9);
		}

		[TestMethod]
		public void TestMiss()
		{
			TestFrame(new Frame("--"), false, false, 0);
			TestFrame(new Frame("1-"), false, false, 1);
			TestFrame(new Frame("-2"), false, false, 2);
		}

		[TestMethod]
		public void TestSpare()
		{
			TestFrame(new Frame("6/"), true, false, 10);
			TestFrame(new Frame("-/"), true, false, 10);
		}

		[TestMethod]
		public void TestStrike()
		{
			TestFrame(new Frame("X"), false, true, 10);
		}

		private static void TestFrame(Frame frame, bool isSpare, bool isStrike, int total)
		{
			Check.That(frame.IsSpare).IsEqualTo(isSpare);
			Check.That(frame.IsStrike).IsEqualTo(isStrike);
			Check.That(frame.Score).IsEqualTo(total);
		}
	}
}

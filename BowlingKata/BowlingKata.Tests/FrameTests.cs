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
			var frame = new Frame("5/4");

			Check.That(frame.Score1).IsEqualTo(5);
			Check.That(frame.Score2).IsEqualTo(4);
			Check.That(frame.IsSpare).IsFalse();
			Check.That(frame.IsStrike).IsFalse();
		}
	}
}

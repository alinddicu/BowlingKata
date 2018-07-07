namespace BowlingKata
{
	using System.Linq;

	public class LastFrame : Frame
	{
		private readonly int _points3RdThrow;

		public LastFrame(string frameResultDisplay)
			: base(frameResultDisplay)
		{
			string[] scores;
			if (frameResultDisplay.ToCharArray().Count(c => c.ToString() == Strike) == 3)
			{
				scores = frameResultDisplay.Split(' ');
			}
			else if (frameResultDisplay.Contains(Strike) || frameResultDisplay.Contains(Spare))
			{
				var score1 = frameResultDisplay.Substring(0, 1);
				var score2 = frameResultDisplay.Substring(1, 1);
				var score3 = frameResultDisplay.Substring(2, 1);
				scores = new[] { score1, score2, score3 };
			}
			else
			{
				var score1 = frameResultDisplay.Substring(0, 1);
				var score2 = frameResultDisplay.Substring(1, 1);
				scores = new[] { score1, score2 };
			}

			Points1StThrow = GetScore(scores[0]);
			Points2NdThrow = GetScore(scores[1]);
			if (Points2NdThrow == 10 || scores[1] == Spare)
			{
				_points3RdThrow = GetScore(scores[2]);
			}

			BonusPointsForPreviousFrame.AddRange(new[] { Points1StThrow, Points2NdThrow, _points3RdThrow });
		}

		private int GetScore(string score)
		{
			switch (score)
			{
				case Miss:
					return 0;
				case Strike:
					return 10;
				case Spare:
					return 10 - Points1StThrow;
				default:
					return int.Parse(score);
			}
		}

		public override int ComputeTotalPoints()
		{
			return Points1StThrow + Points2NdThrow + _points3RdThrow;
		}

		public override string ToString()
		{
			return $"FrameResult: {FrameResultDisplay}";
		}
	}
}

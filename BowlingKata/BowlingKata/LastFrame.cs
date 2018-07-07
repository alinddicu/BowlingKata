namespace BowlingKata
{
	public class LastFrame : Frame
	{
		private readonly int _points3RdThrow;

		public LastFrame(string frameResult)
		{
			var scores = frameResult.Split(' ');
			if (scores.Length == 1)
			{
				var score1 = frameResult.Substring(0, 1);
				var score2 = frameResult.Substring(1, 1);
				scores = score2 == Miss 
					? new[] {score1, score2} 
					: new[] { score1, score2, frameResult.Substring(2, 1) };
			}

			Points1StThrow = GetScore(scores[0]);
			Points2NdThrow = GetScore(scores[1]);
			if (Points2NdThrow == 10 || scores[1] == Spare)
			{
				_points3RdThrow = GetScore(scores[2]);
			}

			BonusPointsForPreviousThrow.AddRange(new[] { Points1StThrow, Points2NdThrow, _points3RdThrow });
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

		public override int ComputeTotal()
		{
			return Points1StThrow + Points2NdThrow + _points3RdThrow;
		}
	}
}

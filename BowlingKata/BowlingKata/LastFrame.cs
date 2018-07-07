namespace BowlingKata
{
	public class LastFrame : Frame
	{
		private readonly int _score3;

		public LastFrame(string frameResult)
		{
			var scores = frameResult.Split(' ');
			var score1 = scores[0];
			Score1 = GetScore(score1);

			if (Score1 != 10)
			{
				return;
			}

			Score2 = GetScore(scores[1]);
			if (Score2 == 10)
			{
				_score3 = GetScore(scores[2]);
			}

			Points.AddRange(new[] { Score1, Score2, _score3 });
		}

		private static int GetScore(string score)
		{
			switch (score)
			{
				case Miss:
					return 0;
				case Strike:
				case Spare:
					return 10;
				default:
					return int.Parse(score);
			}
		}

		public override int ComputeTotal()
		{
			return Score1 + Score2 + _score3;
		}
	}
}

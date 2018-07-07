namespace BowlingKata
{
	public class LastFrame : Frame
	{
		private readonly int _score3;

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

			Score1 = GetScore(scores[0]);
			Score2 = GetScore(scores[1]);
			if (Score2 == 10 || scores[1] == Spare)
			{
				_score3 = GetScore(scores[2]);
			}

			Points.AddRange(new[] { Score1, Score2, _score3 });
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
					return 10 - Score1;
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

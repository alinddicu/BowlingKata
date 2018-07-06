namespace BowlingKata
{
	public class Frame
	{
		private const string Strike = "X";
		private const string Spare = "/";
		private const string Miss = "-";

		public Frame(string frameResult)
		{
			if (frameResult.Contains(Strike))
			{
				IsStrike = true;
				Score = 10;
				return;
			}

			if (frameResult.Contains(Spare))
			{
				IsSpare = true;
				Score = 10;
				return;
			}

			var score1 = frameResult.Substring(0, 1);
			var score2 = frameResult.Substring(1, 1);
			Score = GetMissScore(score1) + GetMissScore(score2);
		}

		public int Score { get; }

		public bool IsSpare { get; }

		public bool IsStrike { get; }

		private static int GetMissScore(string score)
		{
			return score == Miss ? 0 : int.Parse(score);
		}
	}
}

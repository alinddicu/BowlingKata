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
				Score1 = 10;
				Score = 10;
				return;
			}

			if (frameResult.Contains(Spare))
			{
				IsSpare = true;
				var score1 = frameResult.Substring(0, 1);
				var score2 = frameResult.Substring(1, 1);
				Score1 = score1 == Miss ? 0 : int.Parse(score1);
				Score2 = score2 == Spare ? 10 - Score1 : int.Parse(score2);
				Score = 10;
				return;
			}
			
			Score1 = GetMissScore(frameResult.Substring(0, 1));
			Score2 = GetMissScore(frameResult.Substring(1, 1));
			Score = Score1 + Score2;
		}

		public int Score { get; }

		public int Score1 { get; }

		public int Score2 { get; }

		public bool IsSpare { get; }

		public bool IsStrike { get; }
	
		private static int GetMissScore(string score)
		{
			return score == Miss ? 0 : int.Parse(score);
		}
	}
}

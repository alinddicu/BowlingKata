namespace BowlingKata
{
	public class Frame
	{
		private const string Miss = "-";

		public Frame(string frameResult)
		{
			var scores = frameResult.Split('/');
			var score1 = scores[0];
			var score2 = scores[1];

			Score1 = score1 == Miss ? 0 : int.Parse(score1);
			Score2 = score2 == Miss ? 0 : int.Parse(score2);

			IsSpare = Score1 + Score2 == 10 && Score2 > 0;
			IsStrike = Score1 == 10;
		}

		public int Score1 { get; }

		public int Score2 { get; }

		public int Total => Score1 + Score2;

		public bool IsSpare { get; }

		public bool IsStrike { get; }
	}
}

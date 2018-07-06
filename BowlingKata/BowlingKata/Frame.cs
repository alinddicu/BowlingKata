namespace BowlingKata
{
	public class Frame
	{
		public Frame(string frameResult)
		{
			var scoresStr = frameResult.Split('/');

			Score1 = int.Parse(scoresStr[0]);
			Score2 = int.Parse(scoresStr[1]);
		}

		public int Score1 { get; }

		public int Score2 { get; }

		public bool IsSpare { get; }

		public bool IsStrike { get; }
	}
}

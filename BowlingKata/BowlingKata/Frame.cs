namespace BowlingKata
{
	using System.Collections.Generic;
	using System.Linq;

	public class Frame
	{
		protected const string Strike = "X";
		protected const string Spare = "/";
		protected const string Miss = "-";

		protected readonly string FrameResultDisplay;
		private readonly IEnumerable<Frame> _next2Frames;

		protected Frame(string frameResultDisplay)
		{
			FrameResultDisplay = frameResultDisplay;
			BonusPointsForPreviousThrow = new List<int>();
		}

		public Frame(string frameResultDisplay, IEnumerable<Frame> next2Frames)
			: this(frameResultDisplay)
		{
			FrameResultDisplay = frameResultDisplay;
			_next2Frames = next2Frames;
			if (frameResultDisplay.Contains(Strike))
			{
				IsStrike = true;
				Points1StThrow = 10;
				Score = 10;
				BonusPointsForPreviousThrow.Add(10);
				return;
			}

			if (frameResultDisplay.Contains(Spare))
			{
				IsSpare = true;
				var score1 = frameResultDisplay.Substring(0, 1);
				var score2 = frameResultDisplay.Substring(1, 1);
				Points1StThrow = score1 == Miss ? 0 : int.Parse(score1);
				Points2NdThrow = score2 == Spare ? 10 - Points1StThrow : int.Parse(score2);
				Score = 10;
				BonusPointsForPreviousThrow.AddRange(new List<int> { Points1StThrow, Points2NdThrow });
				return;
			}

			Points1StThrow = GetMissScore(frameResultDisplay.Substring(0, 1));
			Points2NdThrow = GetMissScore(frameResultDisplay.Substring(1, 1));
			Score = Points1StThrow + Points2NdThrow;
			BonusPointsForPreviousThrow.AddRange(new List<int> { Points1StThrow, Points2NdThrow });
		}

		public int Score { get; }

		public int Points1StThrow { get; protected set; }

		public int Points2NdThrow { get; protected set; }

		public bool IsSpare { get; }

		public bool IsStrike { get; }

		protected List<int> BonusPointsForPreviousThrow { get; }

		public virtual int ComputeTotal()
		{
			if (IsStrike)
			{
				return Score + ComputeStrike();
			}

			if (IsSpare)
			{
				return Score + ComputeSpare();
			}

			return Score;
		}

		private int ComputeStrike()
		{
			return _next2Frames.SelectMany(f => f.BonusPointsForPreviousThrow).Take(2).Sum();
		}

		private int ComputeSpare()
		{
			return _next2Frames.SelectMany(f => f.BonusPointsForPreviousThrow).Take(1).Sum();
		}

		private static int GetMissScore(string score)
		{
			return score == Miss ? 0 : int.Parse(score);
		}

		public override string ToString()
		{
			return $"FrameResult: {FrameResultDisplay}, Next2Frames: [{string.Join(", ", _next2Frames)}]";
		}
	}
}

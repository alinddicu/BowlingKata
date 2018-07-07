namespace BowlingKata
{
	using System.Collections.Generic;
	using System.Linq;

	public class Frame
	{
		protected const string Strike = "X";
		protected const string Spare = "/";
		protected const string Miss = "-";

		protected int Points1StThrow;
		protected int Points2NdThrow;
		private readonly int _pointsWithoutBonuses;
		private readonly bool _isSpare;
		private readonly bool _isStrike;
		private readonly IEnumerable<Frame> _next2Frames;
		protected readonly string FrameResultDisplay;
		protected readonly List<int> BonusPointsForPreviousFrame;

		protected Frame(string frameResultDisplay)
		{
			FrameResultDisplay = frameResultDisplay;
			BonusPointsForPreviousFrame = new List<int>();
		}

		public Frame(string frameResultDisplay, IEnumerable<Frame> next2Frames)
			: this(frameResultDisplay)
		{
			FrameResultDisplay = frameResultDisplay;
			_next2Frames = next2Frames;
			if (frameResultDisplay.Contains(Strike))
			{
				_isStrike = true;
				Points1StThrow = 10;
				_pointsWithoutBonuses = 10;
				BonusPointsForPreviousFrame.Add(10);
				return;
			}

			if (frameResultDisplay.Contains(Spare))
			{
				_isSpare = true;
				var score1 = frameResultDisplay.Substring(0, 1);
				var score2 = frameResultDisplay.Substring(1, 1);
				Points1StThrow = score1 == Miss ? 0 : int.Parse(score1);
				Points2NdThrow = score2 == Spare ? 10 - Points1StThrow : int.Parse(score2);
				_pointsWithoutBonuses = 10;
				BonusPointsForPreviousFrame.AddRange(new List<int> { Points1StThrow, Points2NdThrow });
				return;
			}

			Points1StThrow = GetMissScore(frameResultDisplay.Substring(0, 1));
			Points2NdThrow = GetMissScore(frameResultDisplay.Substring(1, 1));
			_pointsWithoutBonuses = Points1StThrow + Points2NdThrow;
			BonusPointsForPreviousFrame.AddRange(new List<int> { Points1StThrow, Points2NdThrow });
		}

		public virtual int ComputeTotalPoints()
		{
			if (_isStrike)
			{
				return _pointsWithoutBonuses + ComputeStrike();
			}

			if (_isSpare)
			{
				return _pointsWithoutBonuses + ComputeSpare();
			}

			return _pointsWithoutBonuses;
		}

		private int ComputeStrike()
		{
			return _next2Frames.SelectMany(f => f.BonusPointsForPreviousFrame).Take(2).Sum();
		}

		private int ComputeSpare()
		{
			return _next2Frames.SelectMany(f => f.BonusPointsForPreviousFrame).Take(1).Sum();
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

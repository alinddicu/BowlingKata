namespace BowlingKata
{
	using System.Collections.Generic;
	using System.Linq;

	public class Frame
	{
		private const string Strike = "X";
		private const string Spare = "/";
		private const string Miss = "-";

		private readonly string _frameResult;
		private readonly IEnumerable<Frame> _next2Frames;
		private readonly List<int> _points = new List<int>();

		public Frame(string frameResult, IEnumerable<Frame> next2Frames)
		{
			_frameResult = frameResult;
			_next2Frames = next2Frames;
			if (frameResult.Contains(Strike))
			{
				IsStrike = true;
				Score1 = 10;
				Score = 10;
				_points.Add(10);
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
				_points.AddRange(new List<int> { Score1, Score2 });
				return;
			}

			Score1 = GetMissScore(frameResult.Substring(0, 1));
			Score2 = GetMissScore(frameResult.Substring(1, 1));
			Score = Score1 + Score2;
			_points.AddRange(new List<int> { Score1, Score2 });
		}

		public int Score { get; }

		public int Score1 { get; }

		public int Score2 { get; }

		public bool IsSpare { get; }

		public bool IsStrike { get; }

		public int ComputeTotal()
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
			return _next2Frames.SelectMany(f => f._points).Take(2).Sum();
		}

		private int ComputeSpare()
		{
			return _next2Frames.SelectMany(f => f._points).Take(1).Sum();
		}

		private static int GetMissScore(string score)
		{
			return score == Miss ? 0 : int.Parse(score);
		}

		public override string ToString()
		{
			return $"FrameResult: {_frameResult}, Next2Frames: {string.Join(", ", _next2Frames)}";
		}
	}
}

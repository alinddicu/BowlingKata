namespace BowlingKata
{
	using System.Collections.Generic;
	using System.Linq;

	public class Game : List<Frame>
	{
		public Game(string framesResultsDisplays)
		{
			var allFramesResultsDisplays = framesResultsDisplays.Split(' ');
			var first9FramesResultsDisplays = allFramesResultsDisplays.Take(9);
			var lastFrameResultDisplay = string.Join(" ", allFramesResultsDisplays.Skip(9));
			var emptyNext2FramesFrames = first9FramesResultsDisplays
				.Select(f => new FrameWithFrameScoreDisplay(new Frame(f, new Frame[0]), f))
				.Concat(new[] { new FrameWithFrameScoreDisplay(new LastFrame(lastFrameResultDisplay), lastFrameResultDisplay) })
				.ToArray();
			var ifs = emptyNext2FramesFrames.Select(i => i.Frame).ToArray();
			var completeFrames = emptyNext2FramesFrames
				.Select((emptyFrame, index) => new { EmptyFrame = emptyFrame, Index = index })
				.Take(9)
				.Select(f => new Frame(f.EmptyFrame.FrameResultDisplay, GetNext2Frames(ifs, f.Index)))
				.Concat(new[] { new LastFrame(lastFrameResultDisplay) });
			AddRange(completeFrames);
		}

		private static IEnumerable<Frame> GetNext2Frames(
			ICollection<Frame> incompleteFrames,
			int currentFrameIndex)
		{
			if (currentFrameIndex == incompleteFrames.Count - 1)
			{
				return Enumerable.Empty<Frame>();
			}

			if (currentFrameIndex == incompleteFrames.Count - 2)
			{
				return incompleteFrames.Skip(currentFrameIndex + 1).Take(1);
			}

			return incompleteFrames.Skip(currentFrameIndex + 1).Take(2);
		}

		public int GetScore()
		{
			var scores = this.Select(f => f.ComputeTotalPoints()).ToArray();
			return scores.Sum(f => f);
		}

		private class FrameWithFrameScoreDisplay
		{
			public FrameWithFrameScoreDisplay(Frame frame, string frameResultDisplay)
			{
				Frame = frame;
				FrameResultDisplay = frameResultDisplay;
			}

			public Frame Frame { get; }

			public string FrameResultDisplay { get; }
		}
	}
}

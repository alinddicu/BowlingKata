namespace BowlingKata
{
	using System.Collections.Generic;
	using System.Linq;

	public class Game : List<Frame>
	{
		public Game(string frameResultDisplay)
		{
			var frames = frameResultDisplay.Split(' ');
			var first9 = frames.Take(9);
			var lastFrame = string.Join(" ", frames.Skip(9));
			var incompleteFrames = first9
				.Select(f => new FrameWithFrameScoreDisplay(new Frame(f, new Frame[0]), f))
				.Concat(new[] { new FrameWithFrameScoreDisplay(new LastFrame(lastFrame), lastFrame) })
				.ToArray();
			var ifs = incompleteFrames.Select(i => i.Frame).ToArray();
			var completeFrames = incompleteFrames
				.Select((f, i) => new { f, i })
				.Take(9)
				.Select(f => new Frame(f.f.FrameResultDisplay, GetNext2Frames(ifs, f.i)))
				.Concat(new[] { new LastFrame(lastFrame) });
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
			var scores = this.Select(f => f.ComputeTotal()).ToArray();
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

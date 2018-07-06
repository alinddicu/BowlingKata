namespace BowlingKata
{
	using System.Collections.Generic;
	using System.Linq;

	public class Game : List<Frame>
	{
		public Game(string framesSuite)
		{
			var incompleteFrames = framesSuite.Split(' ')
				.Select(f => new { Frame = new Frame(f, new Frame[0]), f})
				.ToArray();
			var ifs = incompleteFrames.Select(i => i.Frame).ToArray();
			var frames = incompleteFrames
				.Select((f, i) => new {f, i})
				.Select(f => new Frame(f.f.f, GetNext2Frames(ifs, f.i)));
			AddRange(frames);
		}

		private static IEnumerable<Frame> GetNext2Frames(
			ICollection<Frame> incompleteFrames, 
			int currentFrameIndex)
		{
			if (currentFrameIndex == incompleteFrames.Count - 1)
			{
				return Enumerable.Empty<Frame>();
			}
			
			if(currentFrameIndex == incompleteFrames.Count - 2)
			{
				return incompleteFrames.Skip(currentFrameIndex).Take(1);
			}

			return incompleteFrames.Skip(currentFrameIndex).Take(2);
		}

		public int GetScore()
		{
			var scores = this.Select(f => f.ComputeTotal()).ToArray();
			return scores.Sum(f => f);
		}
	}
}

namespace BowlingKata
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class Game : List<Frame>
	{
		public Game(string framesSuite)
		{
			AddRange(framesSuite.Split(' ').Select(f => new Frame(f)));
		}

		public int GetScore()
		{
			return this.Sum(f => f.Score);
		}
	}
}

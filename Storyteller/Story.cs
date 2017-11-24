namespace Storyteller {
	using System.IO;
	using Mint;

	public class Story {

		public TextWriter output;
		public TextReader input;

		public Pool pool = new Pool();

		public Story(TextReader input, TextWriter output) {
			this.input = input;
			this.output = output;
		}

	}
}
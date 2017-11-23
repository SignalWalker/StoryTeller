namespace Storyteller {
	using Mint;

	public class Interpreter : StoryObject {

		uint povKey;
		Entity POV {
			get => CurrStory.pool[povKey];
			set => povKey = value?.Key ?? 0;
		}

		public Interpreter(uint povKey) {
			this.povKey = povKey;
		}

		public Interpreter(Entity pov) {
			POV = pov;
		}

		public Verb Interpret(string com) {
			string[] words = com.Split(' ');

		}

	}
}
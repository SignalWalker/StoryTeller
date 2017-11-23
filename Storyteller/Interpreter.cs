namespace Storyteller {
	using System.Xml;
	using Mint;

	public class Interpreter : StoryObject {

		uint povKey;
		Entity POV {
			get => story.pool[povKey];
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
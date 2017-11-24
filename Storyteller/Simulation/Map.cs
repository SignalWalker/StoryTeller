namespace Storyteller.Simulation {
	using Components;
	using Mint;

	public class Map : StoryObject {

		public Group rooms;

		public Map() {
			rooms = new Group(new[] {typeof(Paths)}, CurrStory.pool);
		}

	}
}
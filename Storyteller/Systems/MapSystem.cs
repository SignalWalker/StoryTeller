namespace Storyteller.Systems {
	using Components;
	using Mint;

	public class MapSystem : StoryObject {

		Group rooms;

		public MapSystem() {
			rooms = new Group(new[] {typeof(Room)}, CurrStory.pool);
		}

	}
}
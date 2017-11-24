namespace Storyteller.Components {
    using System.Collections.Generic;
    using Mint;

    public class Paths : Component {

        public Dictionary<string, uint> directions;

        public Paths(Dictionary<string, uint> directions) {
            this.directions = directions;
        }

        public Entity Get(string dir) => this.ent.Pool[directions[dir]];

    }
}
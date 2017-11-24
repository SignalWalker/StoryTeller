namespace Storyteller.Components {
    using System.Collections.Generic;
    using Mint;

    public static class ContainedMethods {
        public static bool ContainedBy(this Entity ent, uint key) {
            return ent.ContainedBy(ent.Pool[key]);
        }

        public static bool ContainedBy(this Entity ent, Entity con) => ent.Get<Contained>()?.ContainedBy(con) ?? false;
    }

    public class Contained : Component {

        public uint container;
        public uint size;

        public Contained(uint size = 0, uint container = 0) {
            this.container = container;
        }

        public bool ContainedBy(uint key) => ContainedBy(this.ent.Pool[key]);

        public bool ContainedBy(Entity ent) {
            Container er = ent.Get<Container>();
            if (er == null) { return false; }
            if (!er.Contains(this.ent)) {
                Contained ed = ent.Get<Contained>();
                return ed != null && ed.ContainedBy(ent);
            }
            return true;
        }

    }
}
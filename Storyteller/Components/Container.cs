namespace Storyteller.Components {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Mint;

	public static class ContainerMethods {
		public static bool Contains(this Entity ent, Entity con) => ent.Get<Container>()?.Contains(con) ?? false;
		public static bool Contains(this Entity ent, uint key) => ent.Contains(ent.Pool[key]);
		public static bool Hold(this Entity ent, Entity i) => ent.Get<Container>()?.Add(i) ?? false;
		public static bool Drop(this Entity ent, Entity i, bool recursive = true) => ent.Get<Container>()?.Rem(i, recursive) ?? false;
	}

	public class Container : Component {

		public List<uint> items;

		public List<Entity> Items => items.Select(e => this.ent.Pool[e]).ToList();

		public Entity this[int index] => this.ent.Pool[items[index]];

		public Container(IEnumerable<uint> items) {
			this.items = items.ToList();
		}

		public Container(IEnumerable<Entity> items) {
			this.items = items.Select(e => e.Key).ToList();
		}

		public bool Contains(Entity ent) => ent.ContainedBy(this.ent);
		public bool Contains(uint key) => Contains(this.ent.Pool[key]);

		public bool Add(Entity ent) {
			Contained con = ent.Get<Contained>();
			if (con == null) {
				con = new Contained();
				ent.Add(con);
			} else if (con.container != 0) { return false; }
			if (con.size != 0) { throw new NotImplementedException(); }
			con.container = this.ent.Key;
			items.Add(ent.Key);
			return true;
		}

		public bool Rem(Entity ent, bool recursive = true) {
			Contained con = ent.Get<Contained>();
			if (con == null || !con.ContainedBy(this.ent)) { return false; }
			if (items.Contains(ent.Key)) {
				items.Remove(ent.Key);
				con.container = 0;
				return true;
			}
			if (!recursive) { return false; }
			foreach (uint key in items) {
				Entity i = this.ent.Pool[key];
				Container er = i.Get<Container>();
				if (er == null) { continue; }
				if (er.Rem(ent)) { return true; }
			}
			return false;
		}

	}
}
namespace Storyteller.Utility {
    using System.Collections.Generic;
    using System.Linq;
    using Components;
    using Mint;

    public class IndexElement {

        public IndexElement parent;

        public IndexElement Root => parent?.Root ?? this;

        public string Path => parent == null ? "~" : parent.Path + "/" + id;

        public string id;

        public Dictionary<string, IndexElement> children = new Dictionary<string, IndexElement>();

        public IndexElement this[string path] {
            get => Get(path.Split('/').ToList());
            set => Set(path, value);
        }

        IndexElement Get(List<string> path) {
            if (path.Count == 0) { return this; }
            IndexElement next = null;
            switch (path[0]) {
                case ".":
                    next = this;
                    break;
                case "..":
                    next = parent;
                    break;
                case "~":
                    next = Root;
                    break;
                default:
                    if (!children.ContainsKey(path[0])) { return null; }
                    break;
            }
            return next.Get(path.Count == 1 ? new List<string>() : path.GetRange(1, path))
        }
    }

    public class IndexClass : IndexElement {

        Entity prototype;
        string extends;

        public IndexClass(Entity prototype) {
            this.prototype = prototype;
            extends = prototype.Get<Metadata>()?.objClass ?? "";
        }
    }

    public class IndexObject : IndexElement {

        Entity obj;

    }

    public class IndexVerb : IndexElement {

    }
}
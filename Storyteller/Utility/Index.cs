namespace Storyteller.Utility {

    public class Index {

        public IndexElement root;

        public IndexElement this[string path] {
            get => root[path];
            set => root[path] = value;
        }
    }
}
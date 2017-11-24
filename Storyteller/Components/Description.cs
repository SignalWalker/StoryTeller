namespace Storyteller.Components {
    using Mint;

    public class Description : Component {

        public string desc;

        public Description(string desc = "Nothing to see here.") {
            this.desc = desc;
        }

        public static implicit operator string(Description desc) => desc.desc;

    }
}
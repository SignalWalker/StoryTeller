namespace Storyteller {
    using System.IO;

    public class Renderer : StoryObject {

        public string command;
        public TextWriter output;

        public Renderer(TextWriter output, string command = "> ") {
            this.output = output;
            this.command = command;
        }

        public void Write(string input) {
            output.WriteLine(input);
            output.WriteLine(command);
        }
    }
}
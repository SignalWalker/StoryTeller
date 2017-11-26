namespace Storyteller.Utility.Encoders {
    using System.Xml.Linq;
    using Components;
    using Mint;
    public class ClassEncoder : Encoder<XElement, IndexClass> {

        Encoder<XElement, Entity> entEncoder;

        public ClassEncoder(Encoder<XElement, Entity> entEncoder) => this.entEncoder = entEncoder;
        public override XElement Encode(IndexClass obj) { throw new System.NotImplementedException(); }

        public override IndexClass Decode(XElement data) {
            Entity ent = entEncoder.Decode(data);
            return new IndexClass(ent);
        }
    }
}
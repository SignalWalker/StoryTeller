namespace Storyteller.Utility.Encoders {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using Mint;

    public class IndexEncoder : Encoder<XElement, Index> {

        Encoder<XElement, IndexObject> objEncoder;
        Encoder<XElement, IndexClass> classEncoder;
        Encoder<XElement, IndexVerb> verbEncoder;

        public override XElement Encode(Index obj) { throw new System.NotImplementedException(); }

        public override Index Decode(XElement data) {
            List<XElement> nodes = data.Descendants().ToList();
            nodes.Sort(CompareElements);
            Dictionary<string, IndexElement> elements = new Dictionary<string, IndexElement>();
            while (nodes.Count > 0) {
                XElement el = nodes[0];
                nodes.RemoveAt(0);
                switch (el.Name.LocalName.ToLower()) {
                    case "import":
                        XDocument doc = XDocument.Load("Resources/" + el.Attribute("file").Value);
                        nodes.AddRange(doc.Root.Descendants());
                        nodes.Sort(CompareElements);
                        break;
                    case "class":
                        IndexClass c = classEncoder.Decode(el);
                        elements.Add(c.id, c);
                        break;
                    case "verb":
                        IndexVerb v = verbEncoder.Decode(el);
                        elements.Add(v.id, v);
                        break;
                    case "obj":
                        IndexObject o = objEncoder.Decode(el);
                        elements.Add(o.id, o);
                        break;
                    default: throw new NotImplementedException();
                }
            }
        }

        static int CompareElements(XElement a, XElement b) => GetElementScore(a.Name.LocalName) - GetElementScore(b.Name.LocalName);

        enum ElementScore {
            Import = 1,
            Class = 2,
            Verb= 3,
            Obj = 4
        }

        static int GetElementScore(string name) {
            if (!Enum.TryParse(name, true, out ElementScore score)) {
                return int.MaxValue;
            }
            return (int) score;
        }

    }
}
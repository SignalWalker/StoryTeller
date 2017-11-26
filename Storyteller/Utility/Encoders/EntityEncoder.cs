namespace Storyteller.Utility.Encoders {
    using System.Collections.Generic;
    using System.Xml.Linq;
    using Mint;
    public class EntityEncoder : Encoder<XElement, Entity> {

        static Encoder<XElement, Component> descEncoder,
                                            supporterEncoder,
                                            containerEncoder,
                                            pathEncoder,
                                            metaEncoder,
                                            openEncoder,
                                            transparentEncoder,
                                            ruleEncoder;

        public static Dictionary<string, Encoder<XElement, Component>> compEncoders
            = new Dictionary<string, Encoder<XElement, Component>> {
                                                                       {"extend", metaEncoder},
                                                                       {"desc", descEncoder},
                                                                       {"lieOn", supporterEncoder},
                                                                       {"sitOn", supporterEncoder},
                                                                       {"standOn", supporterEncoder},
                                                                       {"open", openEncoder},
                                                                       {"openable", openEncoder},
                                                                       {"transparent", transparentEncoder},
                                                                       {"scenery", descEncoder},
                                                                       {"capacity", containerEncoder},
                                                                       {"rule", ruleEncoder}
                                                                   };

        Index index;

        public EntityEncoder(Index index) { this.index = index; }

        public override XElement Encode(Entity obj) { throw new System.NotImplementedException(); }

        public override Entity Decode(XElement data) {
            throw new System.NotImplementedException();
        }
    }
}
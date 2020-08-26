using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class InterfaceMemberDeclaration: CodeObject
    {
        public string Name { get; set; }
        public TypeReference Type { get; set; }
        public bool ReadOnly { get; set; }
        public bool Nullable { get; set; }

        public List<AttributeReference> Attributes { get; set; } = new List<AttributeReference>();
    }
}
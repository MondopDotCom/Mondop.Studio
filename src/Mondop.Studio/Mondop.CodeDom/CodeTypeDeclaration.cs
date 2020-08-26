using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class CodeTypeDeclaration: CodeExpression
    {
        public ScopeIdentifier Scope { get; set; } = ScopeIdentifier.Public;
        public string Name { get; set; }

        public List<AttributeReference> Attributes { get; set; } = new List<AttributeReference>();
    }
}

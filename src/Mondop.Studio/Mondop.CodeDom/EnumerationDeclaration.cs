using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class EnumerationDeclaration: CodeTypeDeclaration
    {
        public List<EnumMemberDeclaration> Values { get; } = new List<EnumMemberDeclaration>();
    }
}

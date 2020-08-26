using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class InterfaceDeclaration: CodeTypeDeclaration
    {
        public List<InterfaceMemberDeclaration> Members { get; set; } = new List<InterfaceMemberDeclaration>();
        public List<InterfacePropertyDeclaration> Properties { get; set; } = new List<InterfacePropertyDeclaration>();
    }
}

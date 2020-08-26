using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class ClassDeclaration: CodeTypeDeclaration
    {
        public List<PropertyDeclaration> Properties { get; } = new List<PropertyDeclaration>();
        public List<MethodDeclaration> Methods { get; set; } = new List<MethodDeclaration>();
    }
}

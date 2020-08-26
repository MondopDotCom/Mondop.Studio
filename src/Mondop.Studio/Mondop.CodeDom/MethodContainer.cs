using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class MethodContainer: CodeTypeDeclaration
    {
        public List<MethodDeclaration> Methods { get; set; }
    }
}

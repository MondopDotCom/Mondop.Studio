using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class Module: CodeObject
    {
        public string Namespace { get; set; }
        public string Name { get; set; }

        public List<CodeTypeDeclaration> TypeDeclarations { get; set; }
    }
}

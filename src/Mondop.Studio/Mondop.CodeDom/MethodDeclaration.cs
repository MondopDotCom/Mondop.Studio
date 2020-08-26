using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class MethodDeclaration: CodeObject
    {
        public ScopeIdentifier Scope { get; set; }
        public string Name { get; set; }
        public TypeReference ReturnType { get; set; }

        public List<ParameterDeclaration> Parameters { get; set; } = new List<ParameterDeclaration>();
    }
}

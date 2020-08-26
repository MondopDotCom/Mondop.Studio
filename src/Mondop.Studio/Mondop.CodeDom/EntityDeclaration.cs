using System.Collections.Generic;

namespace Mondop.CodeDom
{
    public class EntityDeclaration: CodeTypeDeclaration
    {
        public string Database { get; set; }
        public string Schema { get; set; }
        public string Table { get; set; }
        public List<EntityField> Fields { get; set; }
    }
}

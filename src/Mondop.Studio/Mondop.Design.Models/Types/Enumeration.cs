using System.Collections.Generic;

namespace Mondop.Design.Models.Types
{
    public class Enumeration: TypeDeclaration
    {
        public Enumeration()
        {
            Extends = new TypeReference { ReferencedType = "Mondop.System.Enum" };
        }

        public List<EnumerationMember> Values { get; set; }
        public Scope Scope { get; set; }
    }
}

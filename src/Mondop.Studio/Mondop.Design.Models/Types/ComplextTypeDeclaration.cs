using System.Collections.Generic;

namespace Mondop.Design.Models.Types
{
    public abstract class ComplextTypeDeclaration<TProperty>: TypeDeclaration
    {
        protected ComplextTypeDeclaration()
        {
            
        }

        public Scope Scope { get; set; }
        public List<TProperty> Properties { get; set; } = new List<TProperty>();
    }
}

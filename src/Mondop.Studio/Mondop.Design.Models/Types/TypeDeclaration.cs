using System;

namespace Mondop.Design.Models.Types
{
    public abstract class TypeDeclaration : DesignObject
    {
        private TypeReference _extends;

        private void ValidateTypeReference(TypeReference typeReference)
        {
            if (typeReference != null && !CanExtend())
                throw new InvalidOperationException($"{this.GetType().Name} can not be extended.");
        }

        protected virtual bool CanExtend() => true;

        public TypeReference Extends { 
            get => _extends; 
            set { ValidateTypeReference(value); _extends = value; } 
        }
    }
}

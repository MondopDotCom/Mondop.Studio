using Mondop.CodeDom;

namespace Mondop.Core.Rendering.Renderers
{
    public static class TypeReferenceExtensions
    {
        public static TypeReference Convert(this Design.Models.Types.TypeReference typeReference)
        {
            return new TypeReference
            {
                Namespace = typeReference.Reference.Namespace,
                Type = typeReference.Reference.Name
            };
        }
    }
}

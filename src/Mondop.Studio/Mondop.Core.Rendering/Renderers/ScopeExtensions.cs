using Mondop.CodeDom;
using Mondop.Design.Models.Types;
using System;

namespace Mondop.Core.Rendering.Renderers
{
    public static class ScopeExtensions
    {
        public static ScopeIdentifier Convert(this Scope scope)
        {
            switch(scope)
            {
                case Scope.Private:
                    return ScopeIdentifier.Private;
                case Scope.Protected:
                    return ScopeIdentifier.Protected;
                case Scope.Internal:
                    return ScopeIdentifier.Internal;
                case Scope.Public:
                    return ScopeIdentifier.Public;
                default:
                    throw new InvalidOperationException($"Unable to convert scope {scope}");
            }
        }
    }
}

using Mondop.CodeDom;
using System;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp
{
    public class CSharpTypeReferenceWriter : ICSharpTypeReferenceWriter
    {
        private string ResolveType(TypeReference typeReference)
        {
            if (!typeReference.Namespace.Equals("Mondop.System", StringComparison.OrdinalIgnoreCase))
                return typeReference.QualifiedName;

            switch(typeReference.Type.ToLowerInvariant())
            {
                case "byte":
                    return CSharpKeyword.Byte;
                case "int16":
                    return CSharpKeyword.Short;
                case "int32":
                    return CSharpKeyword.Int;
                case "int64":
                    return CSharpKeyword.Long;
                case "decimal":
                    return CSharpKeyword.Decimal;
                case "string":
                    return CSharpKeyword.String;
                case "boolean":
                    return CSharpKeyword.Bool;
                case "char":
                    return CSharpKeyword.Char;
                case "single":
                    return CSharpKeyword.Single;
                case "double":
                    return CSharpKeyword.Double;
                case "datetime":
                    return "System.DateTime";
                case "guid":
                    return "System.Guid";
                default:
                    return typeReference.QualifiedName;
            }
        }

        public void Write(ICodeWriter writer, TypeReference typeReference, bool nullable)
        {
            var type = ResolveType(typeReference);

            writer.Write(type);
        }
    }
}

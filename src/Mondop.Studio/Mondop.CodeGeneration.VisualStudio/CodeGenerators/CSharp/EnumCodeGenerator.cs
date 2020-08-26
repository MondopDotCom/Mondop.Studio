using System;
using Mondop.CodeDom;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp
{
    public class EnumDeclarationCodeGenerator : ICSharpCodeGenerator
    {
        public Type ForType => typeof(EnumerationDeclaration);

        public void GenerateCode(CodeObject codeObject, ICodeGeneratorFactory factory)
        {
            var writer = factory.Writer;
            var enumerationDeclaration = codeObject as EnumerationDeclaration;

            writer.Indention()
                .Scope(enumerationDeclaration.Scope)
                .Space()
                .Write(CSharpKeyword.Enum)
                .Space()
                .Write(enumerationDeclaration.Name)
                .LineEnd()
                .BlockStart()
                .IncreaseIndention();

            var isFirst = true;
            foreach (var member in enumerationDeclaration.Values)
            {
                if (!isFirst)
                {
                    writer.Write(",");
                    writer.LineEnd();
                }

                writer.Indention().Write(member.Name);
                if (member.Value.HasValue)
                {
                    writer.Write(CSharpOperator.Assignment)
                        .Space()
                        .Write(member.Value.Value.ToString());
                }

                isFirst = false;
            }
            writer.DecreaseIndention()
                .BlockEnd();
        }
    }
}

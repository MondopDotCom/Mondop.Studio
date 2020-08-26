using System;
using Mondop.CodeDom;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp
{
    public class NamespaceCodeGenerator : ICSharpCodeGenerator
    {
        public Type ForType => typeof(NamespaceDeclaration);

        public void GenerateCode(CodeObject codeObject, ICodeGeneratorFactory factory)
        {
            var ns = (NamespaceDeclaration)codeObject;
            var writer = factory.Writer;

            writer.Indention().Write(CSharpKeyword.Namespace).Space().Write(ns.Name)
                .BlockStart().IncreaseIndention();

            ns.Types.ForEach(t => factory.GetCodeGenerator(t).GenerateCode(t, factory));

            writer.DecreaseIndention().BlockEnd();
        }
    }
}

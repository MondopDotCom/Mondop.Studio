using Mondop.Abstractions.IoC;
using System;
using System.Collections.Generic;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp
{
    public class CSharpCodeGeneratorsIoCModule : IIoCModule
    {
        public List<Type> DependsOn => new List<Type> { };

        public void Register(IIoCContainer container)
        {
            var codeGenerators = new Type[] {
                typeof(CompileUnitCodeGenerator),
                typeof(NamespaceCodeGenerator),
                typeof(EnumDeclarationCodeGenerator),
                typeof(ClassDeclarationCodeGenerator)
            };
            container.RegisterCollection<ICSharpCodeGenerator>(codeGenerators);
            container.Register<ICSharpCodeWriter, CSharpCodeWriter>();
            container.Register<ICSharpCodeGeneratorFactory, CSharpCodeGeneratorFactory>();
            container.Register<ICSharpTypeReferenceWriter, CSharpTypeReferenceWriter>();
        }
    }
}

using System;
using Mondop.CodeDom;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp
{
    public class CompileUnitCodeGenerator : ICSharpCodeGenerator
    {
        public Type ForType => typeof(CompileUnit);

        public void GenerateCode(CodeObject codeObject, ICodeGeneratorFactory factory)
        {
            var compileUnit = (CompileUnit)codeObject;

            compileUnit.Namespaces?.ForEach(ns => factory.GetCodeGenerator(ns).GenerateCode(ns, factory));
        }
    }
}

using Mondop.CodeDom;
using System;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators
{
    public interface ICodeGenerator
    {
        void GenerateCode(CodeObject codeObject, ICodeGeneratorFactory factory);

        Type ForType { get; }
    }
}

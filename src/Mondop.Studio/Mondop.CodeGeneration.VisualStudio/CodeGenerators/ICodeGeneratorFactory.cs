using Mondop.CodeDom;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators
{
    public interface ICodeGeneratorFactory
    {
        ICodeWriter Writer { get; }
        ICodeGenerator GetCodeGenerator(CodeObject codeObject);
    }
}

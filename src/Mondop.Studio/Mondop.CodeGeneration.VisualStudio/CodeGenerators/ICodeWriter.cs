using Mondop.CodeDom;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators
{
    public interface ICodeWriter
    {
        ICodeWriter Reset();

        ICodeWriter Space();
        ICodeWriter Write(string data);
        ICodeWriter LineEnd();

        ICodeWriter Indention();
        ICodeWriter IncreaseIndention();
        ICodeWriter DecreaseIndention();

        ICodeWriter Scope(ScopeIdentifier scopeIdentifier);
        ICodeWriter BlockStart(bool inline = false);
        ICodeWriter BlockEnd(bool inline = false);
        ICodeWriter StatementIdentifier();

        string GeneratedCode { get; }
    }
}

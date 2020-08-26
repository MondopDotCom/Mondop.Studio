using System;
using System.IO;
using System.Text;
using Mondop.CodeDom;

/* Implement 
public static bool EndsWith(this StringBuilder sb, string test)
{
    return EndsWith(sb, test, StringComparison.CurrentCulture);
}

public static bool EndsWith(this StringBuilder sb, string test, 
    StringComparison comparison)
{
    if (sb.Length < test.Length)
        return false;

    string end = sb.ToString(sb.Length - test.Length, test.Length);
    return end.Equals(test, comparison);
} 
*/

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp
{
    public class CSharpCodeWriter : ICSharpCodeWriter
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        private int _indention = 0;

        public string GeneratedCode => _stringBuilder.ToString();

        private void StartNewLine()
        {
            if (!_stringBuilder.ToString().EndsWith(Environment.NewLine))
                LineEnd();
            Indention();
        }

        public ICodeWriter BlockEnd(bool inline = false)
        {
            if (!inline)
                StartNewLine();
            _stringBuilder.Append("}");
            if (!inline)
                LineEnd();

            return this;
        }

        public ICodeWriter BlockStart(bool inline = false)
        {
            if (!inline)
                StartNewLine();
            _stringBuilder.Append("{");
            if (!inline)
                LineEnd();

            return this;
        }

        public ICodeWriter DecreaseIndention()
        {
            _indention -= 4;
            if (_indention < 0) _indention = 0;

            return this;
        }

        public ICodeWriter IncreaseIndention()
        {
            _indention += 4;

            return this;
        }

        public ICodeWriter Indention()
        {
            if (_indention > 0)
                _stringBuilder.Append(new string(' ', _indention));

            return this;
        }

        public ICodeWriter LineEnd()
        {
            _stringBuilder.AppendLine();
            return this;
        }

        public ICodeWriter Reset()
        {
            _stringBuilder.Clear();
            _indention = 0;
            return this;
        }

        public ICodeWriter Scope(ScopeIdentifier scopeIdentifier)
        {
            switch (scopeIdentifier)
            {
                case ScopeIdentifier.Public:
                    Write(CSharpKeyword.Public);
                    break;
                case ScopeIdentifier.Internal:
                    Write(CSharpKeyword.Internal);
                    break;
                case ScopeIdentifier.Protected:
                    Write(CSharpKeyword.Protected);
                    break;
                case ScopeIdentifier.Private:
                    Write(CSharpKeyword.Private);
                    break;
                default:
                    throw new InvalidOperationException($"Unimplemented scope identifier {scopeIdentifier}");
            }

            return this;
        }

        public ICodeWriter Space()
        {
            _stringBuilder.Append(" ");

            return this;
        }

        public ICodeWriter Write(string data)
        {
            _stringBuilder.Append(data);

            return this;
        }

        public ICodeWriter StatementIdentifier()
        {
            _stringBuilder.Append(";");
            return this;
        }
    }
}

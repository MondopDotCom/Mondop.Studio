using Mondop.CodeDom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp
{
    public interface ICSharpTypeReferenceWriter
    {
        void Write(ICodeWriter writer, TypeReference typeReference, bool nullable);
    }
}

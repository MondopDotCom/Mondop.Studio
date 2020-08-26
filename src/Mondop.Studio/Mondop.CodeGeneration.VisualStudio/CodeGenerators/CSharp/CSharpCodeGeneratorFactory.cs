using Mondop.CodeDom;
using Mondop.Core;
using Mondop.Guard;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp
{
    public class CSharpCodeGeneratorFactory: ICSharpCodeGeneratorFactory
    {
        private readonly Dictionary<Type,ICSharpCodeGenerator> _codeGenerators;
        private readonly ICSharpCodeWriter _codeWriter;

        public CSharpCodeGeneratorFactory(ICSharpCodeGenerator[] codeGenerators,ICSharpCodeWriter codeWriter)
        {
            _codeGenerators = Ensure.IsNotNull(codeGenerators, nameof(codeGenerators)).ToDictionary(x=> x.ForType);
            _codeWriter = Ensure.IsNotNull(codeWriter, nameof(codeWriter));
        }

        public ICodeWriter Writer => _codeWriter;

        public ICodeGenerator GetCodeGenerator(CodeObject codeObject)
        {
            Ensure.IsNotNull(codeObject, nameof(codeObject));

            return _codeGenerators[codeObject.GetType()];
        }
    }
}

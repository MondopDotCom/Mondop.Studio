using System;
using Mondop.CodeDom;
using Mondop.Guard;

namespace Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp
{
    public class ClassDeclarationCodeGenerator : ICSharpCodeGenerator
    {
        private readonly ICSharpTypeReferenceWriter _typeReferenceWriter;

        public ClassDeclarationCodeGenerator(ICSharpTypeReferenceWriter typeReferenceWriter)
        {
            _typeReferenceWriter = Ensure.IsNotNull(typeReferenceWriter, nameof(typeReferenceWriter));
        }

        public Type ForType => typeof(ClassDeclaration);

        public void GenerateCode(CodeObject codeObject, ICodeGeneratorFactory factory)
        {
            var writer = factory.Writer;
            var classDeclaration = codeObject as ClassDeclaration;

            writer.Indention()
                .Scope(classDeclaration.Scope)
                .Space()
                .Write(CSharpKeyword.Class)
                .Space()
                .Write(classDeclaration.Name);

            writer.LineEnd().BlockStart().IncreaseIndention();

            bool isFirst = true;
            foreach(var property in classDeclaration.Properties)
            {
                if (!isFirst)
                    writer.LineEnd();

                writer.Indention()
                    .Scope(property.Scope)
                    .Space();
                _typeReferenceWriter.Write(writer, property.Type,property.Nullable);

                writer.Space().Write(property.Name);
                writer.Space().BlockStart(true);
                writer.Space().Write(CSharpKeyword.Get).StatementIdentifier();
                if(!property.ReadOnly)
                {
                    writer.Space().Write(CSharpKeyword.Set).StatementIdentifier();
                }
                writer.Space().BlockEnd(true);

                isFirst = false;
            }

            writer.DecreaseIndention();
            writer.BlockEnd();
        }
    }
}

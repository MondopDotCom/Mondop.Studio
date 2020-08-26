using Mondop.Abstractions.IoC;
using Mondop.CodeGeneration.VisualStudio.CodeGenerators.CSharp;
using System;
using System.Collections.Generic;

namespace Mondop.CodeGeneration.VisualStudio
{
    public class VisualStudioCodeGeneratorIoCModule : IIoCModule
    {
        public List<Type> DependsOn => new List<Type> {
            typeof(CSharpCodeGeneratorsIoCModule),
            typeof(Mondop.VisualStudio.Solution.IoCModule),
            typeof(Mondop.Mockables.IocModule)
        };

        public void Register(IIoCContainer container)
        {
            container.Register<IVisualStudioCodeGenerator, VisualStudioCodeGenerator>();
        }
    }
}

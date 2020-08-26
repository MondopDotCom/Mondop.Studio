using Mondop.Abstractions.IoC;
using Mondop.Core.Rendering.Renderers;
using System;
using System.Collections.Generic;

namespace Mondop.Core.Rendering
{
    public class IoCModule : IIoCModule
    {
        public List<Type> DependsOn => new List<Type> { };

        public void Register(IIoCContainer container)
        {
            container.Register<IProjectRenderer, ProjectRenderer>();
            container.Register<IModuleRenderer, ModuleRenderer>();
            container.RegisterCollection<IRenderersRegistar>(new []{ typeof(DefaultRenderersRegistar) });

            container.RegisterSingleton<IRenderersFactory, RenderersFactory>();
            container.RegisterSingleton<IProjectManager, ProjectManager>();
        }
    }
}

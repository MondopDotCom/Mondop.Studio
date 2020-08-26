using Mondop.Core.Rendering.Renderers;
using Mondop.Design.Models;
using Mondop.Guard;
using System.Collections.Generic;

namespace Mondop.Core.Rendering
{
    public interface IModuleRenderer
    {
        void Render(CodeDom.Project target, Module module);
    }

    public class ModuleRenderer: IModuleRenderer
    {
        private readonly IRenderLogger _renderLogger;
        private readonly IRenderersFactory _renderersFactory;

        public ModuleRenderer(IRenderersFactory renderersFactory, IRenderLogger renderLogger)
        {
            _renderLogger = Ensure.IsNotNull( renderLogger,nameof(renderLogger));
            _renderersFactory = Ensure.IsNotNull(renderersFactory, nameof(renderersFactory));
        }

        public void Render(CodeDom.Project target, Module module)
        {
            _renderLogger.Log(LogType.Info, $"Start rendering module: {module.ModuleName}");

            var renderedModule = new CodeDom.Module
            {
                Name = module.ModuleName,
                Namespace = module.Namespace,
                TypeDeclarations = new List<CodeDom.CodeTypeDeclaration>()
            };

            target.Modules.Add(renderedModule);
            
            RenderDesignObjects(renderedModule, module.DataModel.Enumerations);
            RenderDesignObjects(renderedModule,module.DataModel.Classes);
            RenderDesignObjects(renderedModule,module.DataModel.Entities);
            RenderDesignObjects(renderedModule, module.DataModel.Interfaces);

            _renderLogger.Log(LogType.Info, $"Finished rendering module: {module.ModuleName}");
        }

        private void RenderDesignObjects(CodeDom.Module target, IEnumerable<DesignObject> designObjects)
        {
            if (designObjects == null)
                return;

            foreach(var designObject in designObjects)
            {
                var renderer = _renderersFactory.GetRenderer(designObject);
                renderer.Render(target, designObject);
            }
        }
    }
}

using Mondop.Design.Models;
using Mondop.Guard;
using System.Collections.Generic;

namespace Mondop.Core.Rendering
{
    public interface IProjectRenderer
    {
        void RenderProject(Project project);
    }

    public class ProjectRenderer: IProjectRenderer
    {
        private readonly IRenderLogger _renderLogger;
        private readonly IModuleRenderer _moduleRenderer;

        public ProjectRenderer(IModuleRenderer moduleRenderer, IRenderLogger renderLogger)
        {
            _renderLogger = Ensure.IsNotNull(renderLogger,nameof(renderLogger));
            _moduleRenderer = Ensure.IsNotNull(moduleRenderer, nameof(moduleRenderer));
        }

        private void RenderModules(CodeDom.Project target, IEnumerable<Module> modules)
        {
            foreach (var module in modules)
                _moduleRenderer.Render(target, module);
        }

        public void RenderProject(Project project)
        {
            _renderLogger.Log(LogType.Info, $"Start rendering project: {project.Name}");

            var target = new CodeDom.Project
            {

            };

            RenderModules(target, project.Modules);
        }
    }
}

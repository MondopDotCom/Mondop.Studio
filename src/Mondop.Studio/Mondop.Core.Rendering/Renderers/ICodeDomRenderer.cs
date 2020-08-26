using Mondop.Design.Models;

namespace Mondop.Core.Rendering.Renderers
{
    public interface ICodeDomRenderer
    {
        void Render(CodeDom.CodeObject target, DesignObject designObject);
        string Type { get; }
        IRenderLogger RenderLogger { get; set; }
        IProjectManager ProjectManager { get; set; }
    }
}

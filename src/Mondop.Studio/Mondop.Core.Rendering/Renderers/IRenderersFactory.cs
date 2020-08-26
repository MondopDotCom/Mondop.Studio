using Mondop.Design.Models;

namespace Mondop.Core.Rendering.Renderers
{
    public interface IRenderersFactory
    {
        ICodeDomRenderer GetRenderer(DesignObject objectToRender);
        void Register(ICodeDomRenderer renderer, bool replaceExisting = false);
    }
}

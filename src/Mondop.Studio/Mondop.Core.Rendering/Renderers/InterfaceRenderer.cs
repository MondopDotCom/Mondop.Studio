using Mondop.CodeDom;
using Mondop.Design.Models;
using Mondop.Design.Models.Types;

namespace Mondop.Core.Rendering.Renderers
{
    public class InterfaceRenderer : ICodeDomRenderer
    {
        public string Type => $"{RendererTypes.TypeDeclaration}::Mondop.System.Interface";
        public IRenderLogger RenderLogger { get; set; }
        public IProjectManager ProjectManager { get; set; }

        public void Render(CodeObject target, DesignObject designObject)
        {
            var interfaceDeclaration = (Interface)designObject;
            var interfaceCodeObject = new InterfaceDeclaration
            {
                Name = interfaceDeclaration.Name,
                Scope = ScopeIdentifier.Public
            };
            (target as CodeDom.Module).TypeDeclarations.Add(interfaceCodeObject);

            foreach(var member in interfaceDeclaration.Properties)
            {
                var propertyDeclaration = new InterfacePropertyDeclaration
                {
                    Name = member.Name,
                    Type = member.Type.Convert(),
                    Nullable = !member.Required,
                    ReadOnly = member.ReadOnly
                };

                interfaceCodeObject.Properties.Add(propertyDeclaration);
            }
        }
    }
}
